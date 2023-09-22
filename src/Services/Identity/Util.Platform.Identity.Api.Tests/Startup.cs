namespace Util.Platform.Identity.Api.Tests; 

/// <summary>
/// 启动配置
/// </summary>
public class Startup {
    /// <summary>
    /// 配置主机
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        Util.Helpers.Environment.SetDevelopment();
        hostBuilder.ConfigureDefaults( null )
            .ConfigureWebHostDefaults( webHostBuilder => {
                webHostBuilder.UseTestServer()
                    .Configure( t => {
                        t.UseRouting();
                        t.UseEndpoints( endpoints => {
                            endpoints.MapControllers();
                        } );
                    } );
            } )
            .AsBuild()
            .AddAop()
            .AddUtc()
            .AddDapr()
            .AddJsonLocalization()
            .AddRedisCache( t => {
                t.DBConfig.Endpoints.Add( new ServerEndPoint( Config.GetConnectionString( "RedisTestConnection" ), 6379 ) );
                t.DBConfig.KeyPrefix = "Util.Platform.Systems.Api.Tests";
            } )
            .AddSqlServerUnitOfWork<IIdentityUnitOfWork, Data.SqlServer.IdentityUnitOfWork>(
                Config.GetConnectionString( "SqlServerTestConnection" ),
                condition: true )
            .AddPgSqlUnitOfWork<IIdentityUnitOfWork, Data.PgSql.IdentityUnitOfWork>(
                Config.GetConnectionString( "PgSqlTestConnection" ),
                condition: false )
            .AddUtil();
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
        services.AddControllers();
        services.AddTransient<IHttpClient>( t => {
            var client = new HttpClientService();
            client.SetHttpClient( t.GetService<IHost>().GetTestClient() );
            return client;
        } );
        InitDatabase( services );
    }

    /// <summary>
    /// 初始化数据库
    /// </summary>
    private void InitDatabase( IServiceCollection services ) {
        var unitOfWork = services.BuildServiceProvider().GetService<IIdentityUnitOfWork>();
        unitOfWork.EnsureDeleted();
        unitOfWork.EnsureCreated();
    }
}