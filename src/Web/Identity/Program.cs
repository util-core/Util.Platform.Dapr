using Util;
using Util.Logging.Serilog;
using Util.Ui.NgZorro;

//创建Web应用程序生成器
var builder = WebApplication.CreateBuilder( args );

//配置Util服务
builder.AsBuild()
    .AddSerilog()
    .AddNgZorro( t => {
        t.EnableTableSort = true;
    } )
    .AddUtil();

//构建Web应用程序
var app = builder.Build();

//配置请求管道
app.UseNgZorro( 6003 );

//运行应用
app.Run();