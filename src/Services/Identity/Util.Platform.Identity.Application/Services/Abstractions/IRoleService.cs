using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 角色服务
/// </summary>
public interface IRoleService : IRoleServiceBase<RoleDto, CreateRoleRequest, UpdateRoleRequest, RoleQuery, RoleUsersRequest> {
}