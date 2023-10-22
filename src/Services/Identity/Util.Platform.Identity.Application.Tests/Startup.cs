using Util.Helpers;

namespace Util.Platform.Identity.Application.Tests; 

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
            .AsBuild()
            .AddAop()
            .AddUtc()
            .AddDapr()
            .AddJsonLocalization()
            .AddRedisCache( t => {
                t.DBConfig.Configuration = Config.GetConnectionString( "Redis" );
                t.DBConfig.KeyPrefix = "Util.Platform.Identity.Application.Tests";
            } )
            .AddSqlServerUnitOfWork<IIdentityUnitOfWork, Data.SqlServer.IdentityUnitOfWork>(
                Config.GetConnectionString( "SqlServer" ),
                condition: false )
            .AddPgSqlUnitOfWork<IIdentityUnitOfWork, Data.PgSql.IdentityUnitOfWork>(
                Config.GetConnectionString( "PgSql" ),
                condition: false )
            .AddMySqlUnitOfWork<IIdentityUnitOfWork, Data.MySql.IdentityUnitOfWork>(
                Config.GetConnectionString( "MySql" ),
                condition: true )
            .AddUtil();
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
        services.AddIdentity();
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