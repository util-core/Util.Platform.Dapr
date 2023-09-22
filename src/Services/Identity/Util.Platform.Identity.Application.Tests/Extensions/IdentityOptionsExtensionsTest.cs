namespace Util.Platform.Identity.Application.Tests.Extensions; 

/// <summary>
/// Identity������չ����
/// </summary>
public class IdentityOptionsExtensionsTest {
    /// <summary>
    /// Ȩ������
    /// </summary>
    private readonly PermissionOptions _permissionOptions;
    /// <summary>
    /// ��ʶ����
    /// </summary>
    private readonly IdentityOptions _identityOptions;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    public IdentityOptionsExtensionsTest() {
        _permissionOptions = new PermissionOptions();
        _identityOptions = new IdentityOptions();
    }

    /// <summary>
    /// ���Լ���
    /// </summary>
    [Fact]
    public void TestLoad() {
        var emailClaimType = "EmailClaimType_1";
        var allowedUserNameCharacters = "abc";
        _permissionOptions.ClaimsIdentity.EmailClaimType = emailClaimType;
        _permissionOptions.User.AllowedUserNameCharacters = allowedUserNameCharacters;
        _identityOptions.Load( _permissionOptions );
        Assert.Equal( emailClaimType, _identityOptions.ClaimsIdentity.EmailClaimType );
        Assert.Equal( allowedUserNameCharacters, _identityOptions.User.AllowedUserNameCharacters );
    }
}