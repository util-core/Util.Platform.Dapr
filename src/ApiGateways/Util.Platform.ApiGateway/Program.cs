using Util.Platform.ApiGateway;

//����WebӦ�ó���������
var builder = WebApplication.CreateBuilder( args );

//���ÿ�����
builder.Services.AddControllers();

//Dapr΢��������
builder.AddDapr( "api-gateway" );

//Util������������
builder.AddUtil( ShareConst.ApiGatewayAppName );

//����Redis����
builder.AddRedisCache();

//������֤����
builder.AddAuthentication();

//����Http��־
builder.AddHttpLogging();

//����Cors
builder.AddCors();

//����ת��ͷ��
builder.AddForwardedHeaders();

//���ý������
builder.AddHealthChecks();

//���÷������
builder.AddReverseProxy();

//����Swagger����
builder.AddSwagger();

//����WebӦ�ó���
var app = builder.Build();

//===== ��������ܵ� =====//

//�����쳣ҳ
app.UseExceptionPage();

//����Http��־��¼
app.UseHttpLogging();

//�������¼���ʽ
app.UseCustomCloudEvents();

//����Cors
app.UseCors( "cors" );

//���û�·��
app.UsePathBase();

//����ת��ͷ��
app.UseForwardedHeaders();

//����·��
app.UseRouting();

//����Swagger
app.UseCustomSwagger();

//������֤
app.UseAuthentication();

//���ط��ʿ����б�
app.UseLoadAcl();

//������Ȩ
app.UseAuthorization();

//���ü����¼�����
app.MapSubscribeHandler();

//���ÿ�����
app.MapControllers();

//���ý������
app.MapHealthChecks();

//���÷������
app.MapReverseProxy();

try {
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