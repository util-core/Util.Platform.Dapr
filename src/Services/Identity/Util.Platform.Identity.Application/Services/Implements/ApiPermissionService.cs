using Util.Platform.Identity.Applications.Services.Abstractions;
using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Dtos;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// Api权限服务
/// </summary>
public class ApiPermissionService : ApiPermissionServiceBase<IIdentityUnitOfWork,Permission,Resource,Application,User,Role,ApiResourceDto,PermissionRequest>, IApiPermissionService {
    /// <summary>
    /// 初始化Api权限服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="permissionRepository">权限仓储</param>
    /// <param name="userRepository">用户仓储</param>
    /// <param name="roleRepository">角色仓储</param>
    /// <param name="resourceRepository">资源仓储</param>
    public ApiPermissionService( IServiceProvider serviceProvider, IIdentityUnitOfWork unitOfWork, IPermissionRepository permissionRepository,
        IUserRepository userRepository, IRoleRepository roleRepository, IResourceRepository resourceRepository ) 
        : base( serviceProvider, unitOfWork, permissionRepository, userRepository, roleRepository, resourceRepository ) {
    }
}