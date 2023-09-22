namespace Util.Platform.Identity.Data.Repositories; 

/// <summary>
/// 声明仓储
/// </summary>
public class ClaimRepository : ClaimRepositoryBase<IIdentityUnitOfWork,Claim>, IClaimRepository {
    /// <summary>
    /// 初始化声明仓储
    /// </summary>
    /// <param name="unitOfWork">工作单元</param>
    public ClaimRepository( IIdentityUnitOfWork unitOfWork ) : base( unitOfWork ) {
    }
}