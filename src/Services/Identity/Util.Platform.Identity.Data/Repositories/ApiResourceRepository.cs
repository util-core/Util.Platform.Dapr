namespace Util.Platform.Identity.Data.Repositories; 

/// <summary>
/// Api资源仓储
/// </summary>
public class ApiResourceRepository : ApiResourceRepositoryBase<ApiResource,Resource,Application>, IApiResourceRepository {
    /// <summary>
    /// 初始化Api资源仓储
    /// </summary>
    /// <param name="resourceRepository">资源仓储</param>
    public ApiResourceRepository( IResourceRepository resourceRepository ) :base( resourceRepository ) {
    }
}