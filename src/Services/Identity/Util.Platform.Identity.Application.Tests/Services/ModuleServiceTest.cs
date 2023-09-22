namespace Util.Platform.Identity.Application.Tests.Services;

/// <summary>
/// ģ��������
/// </summary>
public class ModuleServiceTest {
    /// <summary>
    /// Ӧ�÷���
    /// </summary>
    private readonly IApplicationService _applicationService;
    /// <summary>
    /// ģ�����
    /// </summary>
    private readonly IModuleService _service;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    public ModuleServiceTest( IApplicationService applicationService, IModuleService service ) {
        _applicationService = applicationService;
        _service = service;
    }

    /// <summary>
    /// ���Դ������޸�ģ��
    /// </summary>
    [Fact]
    public async Task TestCreateAsync_UpdateAsync() {
        //����Ӧ�ó���
        var application = ApplicationDtoFakeService.GetApplicationDto();
        var applicationId = await _applicationService.CreateAsync( application );

        //�����ģ�����ֵ
        var name = "TestCreateAsync_UpdateAsync";
        var url = "url";
        var icon = "icon";

        //������ģ��
        var rootModuleRequest = new CreateModuleRequest {
            Name = name,
            Uri = url,
            Icon = icon,
            ApplicationId = applicationId.ToGuid()
        };
        var rootId = await _service.CreateAsync( rootModuleRequest );

        //��֤��ģ��
        var rootModule = await _service.GetByIdAsync( rootId );
        Assert.NotNull( rootModule );
        Assert.Equal( rootId, rootModule.Id );
        Assert.Equal( name, rootModule.Name );
        Assert.Equal( url, rootModule.Uri );
        Assert.Equal( icon, rootModule.Icon );
        Assert.Equal( 1, rootModule.Level );
        Assert.Equal( $"{rootId},", rootModule.Path );

        //������ģ�����ֵ
        var childName = "TestCreateAsync_UpdateAsync_Child";
        var childUrl = "childUrl";
        var childIcon = "childIcon";

        //������ģ��1
        var childModuleRequest = new CreateModuleRequest {
            Name = childName,
            Uri = childUrl,
            Icon = childIcon,
            ParentId = rootModule.Id.ToGuid(),
            ApplicationId = applicationId.ToGuid()
        };
        var childId = await _service.CreateAsync( childModuleRequest );

        //��֤��ģ��
        var childModule = await _service.GetByIdAsync( childId );
        Assert.NotNull( childModule );
        Assert.Equal( childId, childModule.Id );
        Assert.Equal( childName, childModule.Name );
        Assert.Equal( childUrl, childModule.Uri );
        Assert.Equal( childIcon, childModule.Icon );
        Assert.Equal( 2, childModule.Level );
        Assert.Equal( $"{rootId},{childId},", childModule.Path );

        //������ģ��2
        var childModuleRequest2 = new CreateModuleRequest {
            Name = $"{childName}2",
            ParentId = rootModule.Id.ToGuid(),
            ApplicationId = applicationId.ToGuid()
        };
        var childId2 = await _service.CreateAsync( childModuleRequest2 );

        //������ģ�����ֵ
        var childName3 = "TestCreateAsync_UpdateAsync_Child3";
        var childUrl3 = "childUrl3";
        var childIcon3 = "childIcon3";

        //�޸���ģ��1
        childModule.Name = childName3;
        childModule.Uri = childUrl3;
        childModule.Icon = childIcon3;
        childModule.ParentId = childId2;
        await _service.UpdateAsync( childModule );

        //��֤��ģ��
        childModule = await _service.GetByIdAsync( childId );
        Assert.Equal( childName3, childModule.Name );
        Assert.Equal( childUrl3, childModule.Uri );
        Assert.Equal( childIcon3, childModule.Icon );
        Assert.Equal( 3, childModule.Level );
        Assert.Equal( $"{rootId},{childId2},{childId},", childModule.Path );
    }

    /// <summary>
    /// ���Դ���ģ�� - ��֤�����ظ�
    /// </summary>
    [Fact]
    public async Task TestCreateAsync_ValidateDuplicateModuleName() {
        //����Ӧ�ó���
        var application = ApplicationDtoFakeService.GetApplicationDto();
        var applicationId = await _applicationService.CreateAsync( application );

        //������ģ��
        var rootModuleRequest = new CreateModuleRequest {
            Name = "TestCreateAsync_ValidateDuplicateModuleName",
            ApplicationId = applicationId.ToGuid()
        };
        var rootId = await _service.CreateAsync( rootModuleRequest );

        //ģ������
        string moduleName = "A";

        //������ģ��A
        var childModuleRequest = new CreateModuleRequest {
            Name = moduleName,
            ParentId = rootId.ToGuid(),
            ApplicationId = applicationId.ToGuid()
        };
        await _service.CreateAsync( childModuleRequest );

        //�ظ�������ģ��A
        childModuleRequest = new CreateModuleRequest {
            Name = moduleName,
            ParentId = rootId.ToGuid(),
            ApplicationId = applicationId.ToGuid()
        };
        await AssertHelper.ThrowsAsync<Warning>( async () => {
            await _service.CreateAsync( childModuleRequest );
        }, "DuplicateModuleName" );
    }

    /// <summary>
    /// �����޸�ģ�� - ��֤�����ظ�
    /// </summary>
    [Fact]
    public async Task TestUpdateAsync_ValidateDuplicateModuleName() {
        //����Ӧ�ó���
        var application = ApplicationDtoFakeService.GetApplicationDto();
        var applicationId = await _applicationService.CreateAsync( application );

        //������ģ��
        var rootModuleRequest = new CreateModuleRequest {
            Name = "TestUpdateAsync_ValidateDuplicateModuleName",
            ApplicationId = applicationId.ToGuid()
        };
        var rootId = await _service.CreateAsync( rootModuleRequest );

        //ģ������
        string moduleNameA = "A";

        //������ģ��A
        var childModuleRequest = new CreateModuleRequest {
            Name = moduleNameA,
            ParentId = rootId.ToGuid(),
            ApplicationId = applicationId.ToGuid()
        };
        await _service.CreateAsync( childModuleRequest );

        //������ģ��B
        childModuleRequest = new CreateModuleRequest {
            Name = "B",
            ParentId = rootId.ToGuid(),
            ApplicationId = applicationId.ToGuid()
        };
        var moduleIdB = await _service.CreateAsync( childModuleRequest );

        //����ģ��B�������޸�ΪA
        var moduleB = await _service.GetByIdAsync( moduleIdB );
        moduleB.Name = moduleNameA;
        await AssertHelper.ThrowsAsync<Warning>( async () => {
            await _service.UpdateAsync( moduleB );
        }, "DuplicateModuleName" );
    }
}