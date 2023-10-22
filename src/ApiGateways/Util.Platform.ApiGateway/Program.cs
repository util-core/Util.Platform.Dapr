using Util.Platform.ApiGateway;

//创建Web应用程序生成器
var builder = WebApplication.CreateBuilder( args );

//配置控制器
builder.Services.AddControllers();

//Dapr微服务配置
builder.AddDapr( "api-gateway" );

//Util基础功能配置
builder.AddUtil( ShareConst.ApiGatewayAppName );

//配置Redis缓存
builder.AddRedisCache();

//配置认证方案
builder.AddAuthentication();

//配置Http日志
builder.AddHttpLogging();

//配置Cors
builder.AddCors();

//配置转发头部
builder.AddForwardedHeaders();

//配置健康检查
builder.AddHealthChecks();

//配置反向代理
builder.AddReverseProxy();

//配置Swagger服务
builder.AddSwagger();

//创建Web应用程序
var app = builder.Build();

//===== 配置请求管道 =====//

//配置异常页
app.UseExceptionPage();

//配置Http日志记录
app.UseHttpLogging();

//配置云事件格式
app.UseCustomCloudEvents();

//配置Cors
app.UseCors( "cors" );

//配置基路径
app.UsePathBase();

//配置转发头部
app.UseForwardedHeaders();

//配置路由
app.UseRouting();

//配置Swagger
app.UseCustomSwagger();

//配置认证
app.UseAuthentication();

//加载访问控制列表
app.UseLoadAcl();

//配置授权
app.UseAuthorization();

//配置集成事件订阅
app.MapSubscribeHandler();

//配置控制器
app.MapControllers();

//配置健康检查
app.MapHealthChecks();

//配置反向代理
app.MapReverseProxy();

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