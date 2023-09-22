using Util.Platform.ApiGateway.Services.Abstractions;

namespace Util.Platform.ApiGateway.Services.Implements;

/// <summary>
/// 前端应用服务
/// </summary>
public class AppService : ServiceBase, IAppService {

    #region 构造方法

    /// <summary>
    /// 初始化前端应用服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="cache">缓存服务</param>
    /// <param name="identityService">身份标识服务</param>
    public AppService( IServiceProvider serviceProvider, ICache cache, IIdentityService identityService ) : base( serviceProvider ) {
        CacheService = cache ?? throw new ArgumentNullException( nameof( cache ) );
        IdentityService = identityService ?? throw new ArgumentNullException( nameof( identityService ) );
    }

    #endregion

    #region 属性

    /// <summary>
    /// 缓存服务
    /// </summary>
    protected ICache CacheService { get; }
    /// <summary>
    /// 身份标识服务
    /// </summary>
    protected IIdentityService IdentityService { get; }

    #endregion

    #region GetAppDataAsync

    /// <inheritdoc />
    public async Task<AppData> GetAppDataAsync( Guid applicationId, Guid userId, CancellationToken cancellationToken = default ) {
        var result = new AppData();
        if ( applicationId.IsEmpty() || userId.IsEmpty() )
            return result;
        var application = await IdentityService.GetApplicationByIdAsync( applicationId );
        if ( application == null )
            return result;
        var user = await IdentityService.GetUserByIdAsync( userId );
        if ( user == null )
            return result;
        var appResources = await IdentityService.GetAppResourcesAsync();
        result.App = new AppInfo { Name = application.Name, Description = application.Remark };
        result.Menu = new MenuResult( appResources.Modules ).GetResult();
        result.Acl = appResources.Acl;
        result.IsAdmin = appResources.IsAdmin;
        result.User = new UserInfo { Name = user.UserName, Avatar = "/assets/tmp/img/avatar.jpg", Email = user.Email };
        return result;
    }

    #endregion

    #region GetAppDataByCacheAsync

    /// <inheritdoc />
    public async Task<AppData> GetAppDataByCacheAsync( Guid applicationId, Guid userId, CancellationToken cancellationToken = default ) {
        var result = new AppData();
        if ( applicationId.IsEmpty() || userId.IsEmpty() )
            return result;
        var cacheKey = new GetAppDataCacheKey( userId, applicationId );
        return await CacheService.GetAsync( cacheKey, async () => await GetAppDataAsync( applicationId, userId, cancellationToken ),cancellationToken: cancellationToken );
    }

    #endregion
}