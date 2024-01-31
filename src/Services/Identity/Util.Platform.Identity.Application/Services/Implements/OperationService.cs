using Util.Platform.Identity.Applications.Services.Abstractions;
using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// 操作资源服务
/// </summary>
public class OperationService : OperationServiceBase<IIdentityUnitOfWork,Resource,Application,Operation, OperationDto, ResourceQuery,CreateOperationRequest>, IOperationService {
    /// <summary>
    /// 初始化操作资源服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="resourceRepository">资源仓储</param>
    /// <param name="operationRepository">操作资源仓储</param>
    public OperationService( IServiceProvider serviceProvider, IIdentityUnitOfWork unitOfWork, IResourceRepository resourceRepository,
        IOperationRepository operationRepository ) 
        : base( serviceProvider, unitOfWork, resourceRepository, operationRepository ) {
    }
}