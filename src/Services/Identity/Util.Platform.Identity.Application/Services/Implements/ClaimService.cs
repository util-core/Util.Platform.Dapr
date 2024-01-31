using Util.Platform.Identity.Applications.Services.Abstractions;
using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// 声明服务
/// </summary>
public class ClaimService : ClaimServiceBase<IIdentityUnitOfWork,Claim, ClaimDto, ClaimQuery>, IClaimService {
    /// <summary>
    /// 初始化声明服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="repository">声明仓储</param>
    public ClaimService( IServiceProvider serviceProvider, IIdentityUnitOfWork unitOfWork, IClaimRepository repository) 
        : base( serviceProvider, unitOfWork, repository ) {
    }
}