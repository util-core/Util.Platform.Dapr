using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 用户服务
/// </summary>
public interface IUserService : IUserServiceBase<UserDto, CreateUserRequest, UserQuery> {
}