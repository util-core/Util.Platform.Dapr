namespace Util.Platform.Share.Services.Implements;

/// <summary>
/// 访问控制列表服务
/// </summary>
public class AclService : IAclService {
    /// <summary>
    /// 初始化访问控制列表服务
    /// </summary>
    /// <param name="serviceInvocation">服务调用操作</param>
    public AclService( IServiceInvocation serviceInvocation ) {
        ServiceInvocation = serviceInvocation ?? throw new ArgumentNullException( nameof( serviceInvocation ) );
    }

    /// <summary>
    /// 服务调用操作
    /// </summary>
    protected IServiceInvocation ServiceInvocation { get; }

    /// <inheritdoc />
    public async Task SetAclAsync( string userId, string applicationId ) {
        await ServiceInvocation.Service( ShareConfig.GetIdentityAppId() ).InvokeAsync( "System/SetAcl" );
    }
}