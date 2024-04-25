import { Provider, importProvidersFrom, EnvironmentProviders, makeEnvironmentProviders } from '@angular/core';
import { NgxTinymceModule, TinymceOptions } from 'ngx-tinymce';
import { NgEventBus } from 'ng-event-bus';

/**
 * ngx-tinymce富文本设置
 */
const tinymceOptions: TinymceOptions = {
    baseURL: '/assets/tinymce/'
};

/**
 * 共享配置提供器
 */
export const provideShared = (): EnvironmentProviders => {
    const provides: Array<Provider | EnvironmentProviders> = [];
    provides.push(importProvidersFrom(NgxTinymceModule.forRoot(tinymceOptions)));
    provides.push(NgEventBus);
    return makeEnvironmentProviders(provides);
}