using Microsoft.AspNetCore.Authorization;

namespace Util.Platform.Identity.Api.Controllers;

/// <summary>
/// 系统控制器
/// </summary>
public class SystemController : WebApiControllerBase {
    /// <summary>
    /// 初始化系统控制器
    /// </summary>
    /// <param name="service">系统服务</param>
    public SystemController( ISystemService service ) {
        SystemService = service ?? throw new ArgumentNullException( nameof( service ) );
    }

    /// <summary>
    /// 系统服务
    /// </summary>
    public ISystemService SystemService { get; }

    /// <summary>
    /// 设置访问控制列表
    /// </summary>
    [HttpGet( "SetAcl" )]
    [AllowAnonymous]
    public async Task<IActionResult> SetAclAsync() {
        await SystemService.SetAclCacheAsync( Session.GetApplicationId(), Session.GetUserId() );
        return Success();
    }
}