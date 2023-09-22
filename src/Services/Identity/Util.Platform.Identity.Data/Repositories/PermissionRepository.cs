namespace Util.Platform.Identity.Data.Repositories;

/// <summary>
/// 权限仓储
/// </summary>
public class PermissionRepository : PermissionRepositoryBase<IIdentityUnitOfWork,Permission,Application,Resource>, IPermissionRepository {
    /// <summary>
    /// 初始化权限仓储
    /// </summary>
    /// <param name="unitOfWork">工作单元</param>
    public PermissionRepository( IIdentityUnitOfWork unitOfWork ) : base( unitOfWork ) {
    }
}