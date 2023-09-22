//����WebӦ�ó���������
var builder = WebApplication.CreateBuilder( args );

//���ÿ�����
builder.Services.AddControllers();

//Util������������
builder.AsBuild()
    .AddSerilog( "Util.Platform.Tools.Api" )
    .AddUtil();

//����WebӦ�ó���
var app = builder.Build();

//===== ��������ܵ� =====//
//�����쳣ҳ
if ( app.Environment.IsDevelopment() )
    app.UseDeveloperExceptionPage();

//���þ�̬�ļ�
app.UseStaticFiles();

//����·��
app.UseRouting();

//���ÿ�����
app.MapControllers();

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