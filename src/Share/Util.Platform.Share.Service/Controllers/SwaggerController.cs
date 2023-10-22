using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Util.Platform.Share.Services.Controllers;

/// <summary>
/// Swagger������
/// </summary>
[AllowAnonymous]
public class SwaggerController : ControllerBase {
    /// <summary>
    /// �˳���¼
    /// </summary>
    [HttpGet]
    [Route( "/api/logout" )]
    public async Task Logout() {
        await HttpContext.SignOutAsync( IdentityConstants.ApplicationScheme );
        await HttpContext.SignOutAsync( IdentityConstants.ExternalScheme );
        await HttpContext.SignOutAsync( IdentityConstants.TwoFactorUserIdScheme );
    }
}