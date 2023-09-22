namespace Util.Platform.Identity.Data.Repositories; 

/// <summary>
/// 应用程序仓储
/// </summary>
public class ApplicationRepository : ApplicationRepositoryBase<IIdentityUnitOfWork,Application>, IApplicationRepository {
    /// <summary>
    /// 初始化应用程序仓储
    /// </summary>
    /// <param name="unitOfWork">工作单元</param>
    public ApplicationRepository( IIdentityUnitOfWork unitOfWork ) : base( unitOfWork ) {
    }
}