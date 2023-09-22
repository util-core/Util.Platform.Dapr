namespace Util.Platform.Identity.Data.Repositories;

/// <summary>
/// 资源仓储
/// </summary>
public class ResourceRepository : ResourceRepositoryBase<IIdentityUnitOfWork,Resource,Application>, IResourceRepository {
    /// <summary>
    /// 初始化资源仓储
    /// </summary>
    /// <param name="unitOfWork">工作单元</param>
    public ResourceRepository( IIdentityUnitOfWork unitOfWork ) : base( unitOfWork ) {
    }
}