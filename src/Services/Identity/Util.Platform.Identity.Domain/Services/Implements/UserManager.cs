using Util.Platform.Identity.Domain.Identity;
using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Domain.Services.Abstractions;

namespace Util.Platform.Identity.Domain.Services.Implements; 

/// <summary>
/// 用户服务
/// </summary>
public class UserManager : UserManagerBase<User,Role>,IUserManager {
    /// <summary>
    /// 初始化用户服务
    /// </summary>
    /// <param name="userManager">Identity用户服务</param>
    /// <param name="userRepository">用户仓储</param>
    public UserManager( IdentityUserManager userManager, IUserRepository userRepository ) 
        : base(userManager, userRepository){
    }
}