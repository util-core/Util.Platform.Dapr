using Util.Platform.Identity.Domain.Models;

namespace Util.Platform.Identity.Domain.Services.Abstractions; 

/// <summary>
/// 登录服务
/// </summary>
public interface ISignInManager : ISignInManagerBase<User,Role> {
}