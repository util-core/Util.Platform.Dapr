import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { GlobalFooterModule } from '@delon/abc/global-footer';
import { NoticeIconModule } from '@delon/abc/notice-icon';
import { AlainThemeModule } from '@delon/theme';
import { LayoutDefaultModule } from '@delon/theme/layout-default';
import { SettingDrawerModule } from '@delon/theme/setting-drawer';
import { ThemeBtnModule } from '@delon/theme/theme-btn';
import { NzAutocompleteModule } from 'ng-zorro-antd/auto-complete';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { ReuseTabModule } from '@delon/abc/reuse-tab';

import { LayoutBasicComponent } from './basic/basic.component';
import { HeaderI18nComponent } from './basic/widgets/i18n.component';
import { HeaderSearchComponent } from './basic/widgets/search.component';
import { HeaderUserComponent } from './basic/widgets/user.component';

const COMPONENTS = [LayoutBasicComponent];

const HEADERCOMPONENTS = [
    HeaderSearchComponent,
    HeaderI18nComponent,
    HeaderUserComponent
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        RouterModule,
        AlainThemeModule.forChild(),
        ThemeBtnModule,
        SettingDrawerModule,
        LayoutDefaultModule,
        NoticeIconModule,
        GlobalFooterModule,
        NzDropDownModule,
        NzInputModule,
        NzAutocompleteModule,
        NzGridModule,
        NzFormModule,
        NzSpinModule,
        NzBadgeModule,
        NzAvatarModule,
        NzIconModule,
        ReuseTabModule
    ],
    declarations: [...COMPONENTS, ...HEADERCOMPONENTS],
    exports: [...COMPONENTS],
})
export class LayoutModule { }

