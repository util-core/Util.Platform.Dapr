import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Router } from '@angular/router';
import { SettingsService, User } from '@delon/theme';
import { AuthService } from "util-angular";

/**
 * 页头用户
 */
@Component({
    selector: 'header-user',
    template: `
<div class="alain-default__nav-item d-flex align-items-center px-sm" nz-dropdown nzPlacement="bottomRight" [nzDropdownMenu]="userMenu">
<nz-avatar [nzSrc]="user.avatar" nzSize="small" class="mr-sm"></nz-avatar>
{{ user.name }}
</div>
<nz-dropdown-menu #userMenu="nzDropdownMenu">
<div nz-menu class="width-sm">
<div nz-menu-item (click)="logout()">
  <i nz-icon nzType="logout" class="mr-sm"></i>
 {{'util.logout'|i18n}}
 </div>
 </div>
 </nz-dropdown-menu>
`,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderUserComponent {
    /**
     * 初始化页头用户组件
     * @param settings 设置服务
     * @param router 路由服务
     * @param authService 授权服务
     */
    constructor(private settings: SettingsService, private router: Router, private authService: AuthService) {
    }

    /**
     * 获取用户信息
     */
    get user(): User {
        return this.settings.user;
    }

    /**
     * 注销
     */
    logout() {
        this.authService.logout();
    }
}
