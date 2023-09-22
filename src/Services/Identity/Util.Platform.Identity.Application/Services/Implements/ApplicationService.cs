using Util.Platform.Identity.Applications.Services.Abstractions;
using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// 应用程序服务
/// </summary>
public class ApplicationService : ApplicationServiceBase<IIdentityUnitOfWork,Application,IdentityResource,ApiResource, ApplicationDto, ApplicationQuery>, IApplicationService {
    /// <summary>
    /// 初始化应用程序服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="cache">缓存服务</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="applicationRepository">应用程序仓储</param>
    /// <param name="identityResourceRepository">身份资源仓储</param>
    /// <param name="apiResourceRepository">Api资源仓储</param>
    /// <param name="localizer">本地化查找器</param>
    public ApplicationService( IServiceProvider serviceProvider, ICache cache, IIdentityUnitOfWork unitOfWork,
        IApplicationRepository applicationRepository, IIdentityResourceRepository identityResourceRepository,
        IApiResourceRepository apiResourceRepository, IStringLocalizer localizer ) 
        : base( serviceProvider, cache, unitOfWork, applicationRepository, identityResourceRepository, apiResourceRepository, localizer ) {
    }
}