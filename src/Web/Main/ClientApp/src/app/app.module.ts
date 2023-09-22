import { HttpClientModule } from '@angular/common/http';
import { Injector, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgEventBus } from 'ng-event-bus';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzNotificationModule } from 'ng-zorro-antd/notification';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { GlobalConfigModule } from './global-config.module';
import { LayoutModule } from './layout/layout.module';
import { RoutesModule } from './routes/routes.module';
import { SharedModule } from './shared/shared.module';

// #region 语言设置
import { registerLocaleData } from '@angular/common';
import { default as ngLang } from '@angular/common/locales/zh';
import { zhCN as dateLang } from 'date-fns/locale';
import { NZ_DATE_LOCALE, NZ_I18N, zh_CN as zorroLang } from 'ng-zorro-antd/i18n';
import { DELON_LOCALE, zh_CN as delonLang, ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from './core/i18n/i18n.service';
const LANG = {
    abbr: 'zh',
    ng: ngLang,
    zorro: zorroLang,
    date: dateLang,
    delon: delonLang,
};
const I18NSERVICE_PROVIDES = [{ provide: ALAIN_I18N_TOKEN, useClass: I18NService, multi: false }];
registerLocaleData(LANG.ng, LANG.abbr);
const LANG_PROVIDES = [
    { provide: LOCALE_ID, useValue: LANG.abbr },
    { provide: NZ_I18N, useValue: LANG.zorro },
    { provide: NZ_DATE_LOCALE, useValue: LANG.date },
    { provide: DELON_LOCALE, useValue: LANG.delon }
];
// #endregion

// #region 图标设置
import { IconDefinition } from '@ant-design/icons-angular';
import { NzIconModule } from 'ng-zorro-antd/icon';
import * as AllIcons from '@ant-design/icons-angular/icons';

const antDesignIcons = AllIcons as {
    [key: string]: IconDefinition;
};
const icons: IconDefinition[] = Object.keys(antDesignIcons).map(key => antDesignIcons[key])
// #endregion

// #region ngx-tinymce(富文本设置)
import { NgxTinymceModule, TinymceOptions } from 'ngx-tinymce';
const tinymceOptions: TinymceOptions = {
    baseURL: '/assets/tinymce/'
};
// #endregion

// #region util(util设置)
import { Util, AppConfig } from 'util-angular';
import { appConfig } from './app-config';
// #endregion

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        NzIconModule.forRoot(icons),
        GlobalConfigModule.forRoot(),
        CoreModule.forRoot(),
        SharedModule,
        LayoutModule,
        RoutesModule,
        NzMessageModule,
        NzNotificationModule,
        NgxTinymceModule.forRoot(tinymceOptions)
    ],
    providers: [
        ...LANG_PROVIDES,
        ...I18NSERVICE_PROVIDES,
        NgEventBus,
        { provide: AppConfig, useValue: appConfig }
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
    /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        Util.init(injector);
    }
}