namespace Util.Platform.Identity.Controllers; 

/// <summary>
/// �û���֤������
/// </summary>
[AllowAnonymous]
public class AccountController : AccountControllerBase<ISystemService,LoginRequest> {
    /// <summary>
    /// ��ʼ���û���֤������
    /// </summary>
    /// <param name="interaction">��������</param>
    /// <param name="schemeProvider">��֤�����ṩ��</param>
    /// <param name="events">�¼�����</param>
    /// <param name="systemService">ϵͳ����</param>
    public AccountController( IIdentityServerInteractionService interaction, IAuthenticationSchemeProvider schemeProvider, 
        IEventService events, ISystemService systemService  ) 
        : base( interaction, schemeProvider, events, systemService ) {
    }
}