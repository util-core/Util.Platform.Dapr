using Util.Platform.Identity;

//����WebӦ�ó���������
var builder = WebApplication.CreateBuilder( args );

//���ÿ�����
builder.AddControllers();

//��������Ǩ�Ʒ���
builder.Services.AddHostedService<MigrationHostedService>();

//Dapr΢��������
builder.AddDapr( "identity" );

//�����⻧
builder.AddTenant( new IdentityTenantResolver() );

//Util������������
builder.AddUtil( ShareConst.IdentityAppName );

//����Redis����
builder.AddRedisCache();

//���ù�����Ԫ
builder.AddIdentityUnitOfWork();

//������ݱ�ʶ����
builder.AddIdentity();

//���������֤������
builder.AddIdentityServer();

//������֤
builder.Services.AddAuthentication();

//����Cors
builder.AddCors();

//����ת��ͷ��
builder.AddForwardedHeaders();

//����Http��־
builder.AddHttpLogging();

//���ý������
builder.AddHealthChecks();

//����WebӦ�ó���
var app = builder.Build();

//===== ��������ܵ� =====//

//����Http��־��¼
app.UseHttpLogging();

//�����쳣ҳ
app.UseCustomExceptionPage();

//���û�·��
app.UsePathBase();

//����ת��ͷ��
app.UseForwardedHeaders();

//�������¼���ʽ
app.UseCustomCloudEvents();

//����Cors
app.UseCors( "cors" );

//���þ�̬�ļ�
app.UseStaticFiles();

//���ñ��ػ�
app.UseLocalization();

//����Cookie����
app.UseCookiePolicy();

//����·��
app.UseRouting();

//������ݷ�����
app.UseCustomIdentityServer();

//������֤
app.UseAuthentication();

//�����⻧
app.UseTenant();

//������Ȩ
app.UseAuthorization();

//���ÿ�����
app.MapDefaultControllerRoute();

//���ü����¼�����
app.MapSubscribeHandler();

//���ý������
app.MapHealthChecks();

try {
    //Ǩ������
    await app.MigrateAsync();

    //����Ӧ��
    app.Logger.LogInformation( "׼������Ӧ�� ..." );
    await app.RunAsync();
    return 0;
}
catch ( Exception ex ) {
    app.Logger.LogCritical( ex, "Ӧ������ʧ�� ..." );
    return 1;
}
finally {
    Serilog.Log.CloseAndFlush();
}