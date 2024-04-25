import { Injectable, inject, Provider, APP_INITIALIZER } from '@angular/core';
import { Router, Routes } from '@angular/router';
import { zip, lastValueFrom } from 'rxjs';
import { catchError, map, } from 'rxjs/operators';
import { getManifest, loadRemoteModule } from '@angular-architects/module-federation';
import { ALAIN_I18N_TOKEN, MenuService, SettingsService, TitleService } from '@delon/theme';
import { ACLService } from '@delon/acl';
import { Util, Result, StateCode, AuthService } from 'util-angular';
import { I18NService } from '../i18n/i18n.service';
import { CustomManifest } from './custom-manifest';
import { urlConfig } from '../../config/url.config';
import { routes } from '../../routes/routes';

/**
 * 启动服务提供器
 */
export function provideStartup(): Provider[] {
    return [
        StartupService,
        {
            provide: APP_INITIALIZER,
            useFactory: (service: StartupService) => () => service.initial(),
            deps: [StartupService],
            multi: true
        }
    ];
}

/**
 * 启动服务
 */
@Injectable()
export class StartupService {
    /**
     * 路由
     */
    private router = inject(Router);
    /**
     * 菜单服务
     */
    private menuService = inject(MenuService);
    /**
     * 设置服务
     */
    private settingService = inject(SettingsService);
    /**
     * 标题服务
     */
    private titleService = inject(TitleService);
    /**
     * 多语言服务
     */
    private i18n = inject<I18NService>(ALAIN_I18N_TOKEN);
    /**
     * 访问控制服务
     */
    private aclService = inject(ACLService);
    /**
     * 授权服务
     */
    private authService = inject(AuthService);
    /**
     * 操作入口
     */
    private util = Util.create();

    /**
     * 启动初始化
     */
    initial() {
        return this.authService.loadDiscoveryDocumentAndTryLogin()
            .then(() => {
                if (this.authService.hasToken()) {
                    this.authService.nextIsDoneLoading();
                    this.initSession();
                    return this.load();
                }
                return Promise.reject();
            })
            .catch((exception) => {
                console.error(exception);
                this.authService.nextIsDoneLoading();
            });
    }

    /**
     * 初始化用户会话
     */
    private initSession() {
        let claims = this.authService.getIdentityClaims();
        this.util.session.setSession({
            isAuthenticated: this.authService.hasToken(),
            userId: claims["sub"]
        })
    }

    /**
     * 加载应用数据
     */
    private load(): Promise<void> {
        this.loadRemotes();
        const defaultLang = this.i18n.defaultLang;
        const result = zip(this.i18n.loadLangData(defaultLang), this.util.webapi.get(urlConfig.appDataUrl).getClient()).pipe(
            catchError(() => {
                setTimeout(() => this.util.router.navigateByUrl(`/exception/500`));
                return [];
            }),
            map(([langData, appResult]: [Record<string, string>, Result<any>]) => {
                this.i18n.use(defaultLang, langData);
                if (appResult.code !== StateCode.Ok)
                    return;
                let appData = appResult.data;
                this.setSetting(appData);
                this.setMenu(appData);
                this.setAcl(appData);
                this.setTitle(appData);
            })
        );
        return lastValueFrom(result);
    }

    /**
     * 加载远程模块
     */
    private loadRemotes() {
        const manifest = getManifest<CustomManifest>();
        const routes = this.buildRoutes(manifest);
        this.router.resetConfig(routes);
    }

    /**
    * 创建带延迟加载的微前端路由参数
    */
    private buildRoutes(options: CustomManifest): Routes {
        const lazyRoutes: Routes = Object.keys(options).map(key => {
            const entry = options[key];
            return {
                path: entry.routePath,
                loadChildren: () =>
                    loadRemoteModule({
                        type: 'manifest',
                        remoteName: key,
                        exposedModule: entry.exposedModule
                    })
                        .then(t => t[entry.ngModuleName])
            }
        });
        routes[0].children && routes[0].children.push(...lazyRoutes);
        return [...routes];
    }

    /**
     * 设置基础信息
     */
    private setSetting(appData) {
        this.settingService.setApp(appData.app);
        this.settingService.setUser(appData.user);
    }

    /**
     * 设置菜单
     */
    private setMenu(appData) {
        this.menuService.add(appData.menu);
        this.menuService.openStrictly = true;
    }

    /**
     * 设置权限
     */
    private setAcl(appData) {
        if (appData.isAdmin) {
            this.aclService.setFull(true);
            return;
        }
        this.aclService.setRole(appData.acl);
    }

    /**
     * 设置标题
     */
    private setTitle(appData) {
        this.titleService.default = '';
        this.titleService.suffix = appData.app.name;
    }
}