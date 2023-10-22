import { NgModule, Optional, SkipSelf, ModuleWithProviders, APP_INITIALIZER } from '@angular/core';
import { AuthConfig, OAuthModuleConfig, OAuthModule } from 'angular-oauth2-oidc';
import { authConfig } from '../config/auth-config';
import { authModuleConfig } from '../config/auth-module-config';
import { StartupService } from './startup/startup.service';

/**
 * 启动服务工厂
 * @param startupService 启动服务
 */
export function StartupServiceFactory(startupService: StartupService): () => Promise<void> {
    return () => startupService.initial();
}

/**
* 核心模块
*/
@NgModule({
    imports: [OAuthModule.forRoot()]
})
export class CoreModule {
    /**
    * 初始化核心模块
    */
    constructor(@Optional() @SkipSelf() parent: CoreModule) {
        if (parent) {
            throw new Error('核心模块已加载！');
        }
    }

    /**
    * 核心模块
    */
    static forRoot(): ModuleWithProviders<CoreModule> {
        return {
            ngModule: CoreModule,
            providers: [
                StartupService,
                { provide: AuthConfig, useValue: authConfig },
                { provide: OAuthModuleConfig, useValue: authModuleConfig },
                { provide: APP_INITIALIZER, useFactory: StartupServiceFactory, deps: [StartupService], multi: true }
            ]
        };
    }
}