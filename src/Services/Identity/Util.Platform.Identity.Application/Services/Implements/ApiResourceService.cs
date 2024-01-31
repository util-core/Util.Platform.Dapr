using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;
using Util.Platform.Identity.Applications.Services.Abstractions;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// Api资源服务
/// </summary>
public class ApiResourceService : ApiResourceServiceBase<IIdentityUnitOfWork,Resource,Application,ApiResource, ApiResourceDto, CreateApiResourceRequest, ResourceQuery>, IApiResourceService {
    /// <summary>
    /// 初始化Api资源服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="resourceRepository">资源仓储</param>
    /// <param name="apiResourceRepository">Api资源仓储</param>
    public ApiResourceService( IServiceProvider serviceProvider, IIdentityUnitOfWork unitOfWork, IResourceRepository resourceRepository,
        IApiResourceRepository apiResourceRepository ) 
        : base( serviceProvider, unitOfWork, resourceRepository, apiResourceRepository ) {
    }
}