using Util.Platform.Identity.Applications.Services.Abstractions;
using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// 常用操作资源服务
/// </summary>
public class CommonOperationService : CommonOperationServiceBase<IIdentityUnitOfWork,CommonOperation, CommonOperationDto, CommonOperationQuery>, ICommonOperationService {
    /// <summary>
    /// 初始化常用操作资源服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="repository">仓储</param>
    public CommonOperationService( IServiceProvider serviceProvider, IIdentityUnitOfWork unitOfWork, ICommonOperationRepository repository ) 
        : base( serviceProvider, unitOfWork, repository ) {
    }
}