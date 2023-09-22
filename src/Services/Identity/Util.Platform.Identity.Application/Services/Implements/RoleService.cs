using Util.Platform.Identity.Applications.Services.Abstractions;
using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Domain.Services.Abstractions;
using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// 角色服务
/// </summary>
public class RoleService : RoleServiceBase<IIdentityUnitOfWork,Role,User, RoleDto, CreateRoleRequest, UpdateRoleRequest, RoleQuery,RoleUsersRequest>, IRoleService {
    /// <summary>
    /// 初始化角色服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="roleRepository">角色仓储</param>
    /// <param name="roleManager">角色服务</param>
    public RoleService( IServiceProvider serviceProvider, IIdentityUnitOfWork unitOfWork, IRoleRepository roleRepository, IRoleManager roleManager )
        : base( serviceProvider, unitOfWork, roleRepository, roleManager ) {
    }
}