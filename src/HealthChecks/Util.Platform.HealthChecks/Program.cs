//创建Web应用程序生成器
var builder = WebApplication.CreateBuilder( args );

//配置健康检查服务
builder.Services.AddHealthChecksUI()
    .AddInMemoryStorage();

//配置日志
builder.Logging.AddJsonConsole();

//创建Web应用程序
var app = builder.Build();

//配置基路径
var pathBase = builder.Configuration["PathBase"];
if ( string.IsNullOrEmpty( pathBase ) == false ) 
    app.UsePathBase( pathBase );

//配置健康检查UI
app.UseHealthChecksUI( config => {
    config.ResourcesPath = string.IsNullOrEmpty( pathBase )
        ? "/ui/resources"
        : $"{pathBase}/ui/resources";
} );
app.MapGet( string.IsNullOrEmpty( pathBase ) ? "/" : pathBase, () => Results.LocalRedirect( "~/healthchecks-ui" ) );
app.MapHealthChecksUI();

//启动应用
app.Run();