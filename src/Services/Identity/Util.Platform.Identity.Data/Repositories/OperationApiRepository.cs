namespace Util.Platform.Identity.Data.Repositories;

/// <summary>
/// 操作Api仓储
/// </summary>
public class OperationApiRepository : OperationApiRepositoryBase<IIdentityUnitOfWork,OperationApi,Resource,Application>, IOperationApiRepository {
    /// <summary>
    /// 初始化操作Api仓储
    /// </summary>
    /// <param name="unitOfWork">工作单元</param>
    public OperationApiRepository( IIdentityUnitOfWork unitOfWork ) : base( unitOfWork ) {
    }
}