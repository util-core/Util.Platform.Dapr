using Util.Platform.Identity.Domain.Models;

namespace Util.Platform.Identity.Domain.Services.Abstractions; 

/// <summary>
/// 用户服务
/// </summary>
public interface IUserManager : IUserManagerBase<User,Role> {
}