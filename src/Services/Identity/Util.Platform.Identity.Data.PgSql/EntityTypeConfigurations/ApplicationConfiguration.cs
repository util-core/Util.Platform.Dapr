namespace Util.Platform.Identity.Data.PgSql.EntityTypeConfigurations;

/// <summary>
/// 应用程序类型配置
/// </summary>
public class ApplicationConfiguration : ApplicationConfigurationBase {
    /// <summary>
    /// 配置索引
    /// </summary>
    protected override void ConfigIndex( EntityTypeBuilder<Application> builder ) {
        builder.HasIndex( t => t.Id ).IsUnique();
    }
}