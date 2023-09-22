using Util.Platform.Identity.Domain.Identity;
using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Domain.Services.Abstractions;

namespace Util.Platform.Identity.Domain.Services.Implements; 

/// <summary>
/// 登录服务
/// </summary>
public class SignInManager : SignInManagerBase<User,Role>,ISignInManager {
    /// <summary>
    /// 初始化登录服务
    /// </summary>
    /// <param name="signInManager">Identity登录服务</param>
    /// <param name="userManager">用户服务</param>
    /// <param name="localizer">本地化查找器</param>
    public SignInManager( IdentitySignInManager signInManager, IUserManager userManager, IStringLocalizer localizer )
        : base(signInManager, userManager, localizer){
    }
}