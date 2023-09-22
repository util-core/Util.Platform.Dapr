using Util.Helpers;

namespace Util.Platform.Identity;

/// <summary>
/// Identity数据迁移服务,开发阶段使用
/// </summary>
public class MigrationHostedService : IHostedService {
    /// <summary>
    /// 主机环境
    /// </summary>
    private readonly IWebHostEnvironment _environment;
    /// <summary>
    /// 迁移服务
    /// </summary>
    private readonly IMigrationService _migrationService;

    /// <summary>
    /// 初始化迁移服务
    /// </summary>
    /// <param name="environment">主机环境</param>
    /// <param name="migrationService">迁移服务</param>
    public MigrationHostedService( IWebHostEnvironment environment, IMigrationService migrationService ) {
        _environment = environment ?? throw new ArgumentNullException( nameof( environment ) );
        _migrationService = migrationService ?? throw new ArgumentNullException( nameof( migrationService ) );
    }

    /// <summary>
    /// 启动
    /// </summary>
    public Task StartAsync( CancellationToken cancellationToken ) {
        if ( _environment.IsDevelopment() == false )
            return Task.CompletedTask;
        if ( Common.IsLinux )
            return Task.CompletedTask;
        if ( IsEnabled() == false )
            return Task.CompletedTask;
        InstallEfTool();
        MigrateSqlServer();
        MigratePgSql();
        return Task.CompletedTask;
    }

    /// <summary>
    /// 是否启用EF迁移
    /// </summary>
    private bool IsEnabled() {
        return Config.GetValue<bool>( "Migration:Enabled" );
    }

    /// <summary>
    /// 安装和更新 dotnet-ef 工具
    /// </summary>
    private void InstallEfTool() {
        _migrationService.InstallEfTool().UpdateEfTool();
    }

    /// <summary>
    /// 迁移Sql Server
    /// </summary>
    private void MigrateSqlServer() {
        var path = Common.JoinPath( Common.GetParentDirectory(), "Util.Platform.Identity.Data.SqlServer" );
        _migrationService.AddMigration( GetMigrationName(), path );
    }

    /// <summary>
    /// 获取迁移名称
    /// </summary>
    private string GetMigrationName() {
        return Config.GetValue( "Migration:Name" );
    }

    /// <summary>
    /// 迁移PgSql
    /// </summary>
    private void MigratePgSql() {
        var path = Common.JoinPath( Common.GetParentDirectory(), "Util.Platform.Identity.Data.PgSql" );
        _migrationService.AddMigration( GetMigrationName(), path );
    }

    /// <summary>
    /// 停止
    /// </summary>
    public Task StopAsync( CancellationToken cancellationToken ) {
        return Task.CompletedTask;
    }
}