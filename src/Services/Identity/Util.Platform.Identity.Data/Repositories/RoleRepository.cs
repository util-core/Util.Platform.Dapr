namespace Util.Platform.Identity.Data.Repositories;

/// <summary>
/// 角色仓储
/// </summary>
public class RoleRepository : RoleRepositoryBase<IIdentityUnitOfWork,Role,User>, IRoleRepository {
    /// <summary>
    /// 初始化角色仓储
    /// </summary>
    /// <param name="unitOfWork">工作单元</param>
    public RoleRepository( IIdentityUnitOfWork unitOfWork ) : base( unitOfWork ) {
    }
}