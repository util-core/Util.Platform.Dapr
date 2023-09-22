using Util.Platform.Identity.Applications.Services.Abstractions;
using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// 身份资源服务
/// </summary>
public class IdentityResourceService : IdentityResourceServiceBase<IIdentityUnitOfWork,Resource,Application,IdentityResource, IdentityResourceDto, ResourceQuery>, IIdentityResourceService {
    /// <summary>
    /// 初始化身份资源服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="resourceRepository">资源仓储</param>
    /// <param name="identityResourceRepository">身份资源仓储</param>
    /// <param name="localizer">本地化查找器</param>
    public IdentityResourceService( IServiceProvider serviceProvider, IIdentityUnitOfWork unitOfWork, IResourceRepository resourceRepository,
        IIdentityResourceRepository identityResourceRepository, IStringLocalizer localizer ) 
        : base( serviceProvider, unitOfWork, resourceRepository, identityResourceRepository, localizer ) {
    }
}