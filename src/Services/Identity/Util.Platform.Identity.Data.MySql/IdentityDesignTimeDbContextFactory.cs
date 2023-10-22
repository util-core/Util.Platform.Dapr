using Util.Helpers;

namespace Util.Platform.Identity.Data.MySql; 

/// <summary>
/// 设计时数据上下文工厂
/// </summary>
public class IdentityDesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityUnitOfWork> {
    /// <summary>
    /// 创建数据上下文
    /// </summary>
    public IdentityUnitOfWork CreateDbContext( string[] args ) {
        var connectionString = GetConnectionString();
        var services = Ioc.GetServices();
        services.AddDbContext<IdentityUnitOfWork>( t => t.UseMySql( connectionString, ServerVersion.AutoDetect( connectionString ) ) );
        return Ioc.Create<IdentityUnitOfWork>();
    }

    /// <summary>
    /// 获取连接字符串
    /// </summary>
    private string GetConnectionString() {
        var config = Util.Helpers.Config.CreateConfiguration( GetConfigPath(), "secrets.json" );
        var result = config.GetConnectionString( "Identity:MySql" );
        return result?.Replace( "mysql", "127.0.0.1" );
    }

    /// <summary>
    /// 获取配置目录路径
    /// </summary>
    private string GetConfigPath() {
        var path = Directory.GetCurrentDirectory();
        path = path.Substring( 0, path.IndexOf( "src", StringComparison.OrdinalIgnoreCase ) );
        return $@"{path}\dapr\components";
    }
}