namespace Util.Platform.Identity.Controllers;

/// <summary>
/// ��������
/// </summary>
[AllowAnonymous]
public class HomeController : HomeControllerBase {
    /// <summary>
    /// ��ʼ����������
    /// </summary>
    /// <param name="interaction">��������</param>
    /// <param name="environment">��������</param>
    public HomeController( IIdentityServerInteractionService interaction, IWebHostEnvironment environment ) 
        : base( interaction, environment ) {
    }
}