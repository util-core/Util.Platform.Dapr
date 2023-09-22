//创建Web应用程序生成器
var builder = WebApplication.CreateBuilder( args );

//配置控制器
builder.Services.AddControllers();

//Util基础功能配置
builder.AsBuild()
    .AddSerilog( "Util.Platform.Tools.Api" )
    .AddUtil();

//创建Web应用程序
var app = builder.Build();

//===== 配置请求管道 =====//
//配置异常页
if ( app.Environment.IsDevelopment() )
    app.UseDeveloperExceptionPage();

//配置静态文件
app.UseStaticFiles();

//配置路由
app.UseRouting();

//配置控制器
app.MapControllers();

try {
    //启动应用
    app.Logger.LogInformation( "准备启动应用 ..." );
    await app.RunAsync();
    return 0;
}
catch ( Exception ex ) {
    app.Logger.LogCritical( ex, "应用启动失败 ..." );
    return 1;
}
finally {
    Serilog.Log.CloseAndFlush();
}