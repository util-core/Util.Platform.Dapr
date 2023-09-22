namespace Util.Platform.Identity.Data.Repositories;

/// <summary>
/// 用户仓储
/// </summary>
public class UserRepository : UserRepositoryBase<IIdentityUnitOfWork, User, Role>, IUserRepository {
    /// <summary>
    /// 初始化用户仓储
    /// </summary>
    /// <param name="unitOfWork">工作单元</param>
    public UserRepository( IIdentityUnitOfWork unitOfWork ) : base( unitOfWork ) {
    }
}