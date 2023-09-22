namespace Util.Platform.Identity.Data.PgSql.EntityTypeConfigurations;

/// <summary>
/// 声明类型配置
/// </summary>
public class ClaimConfiguration : ClaimConfigurationBase {
    /// <summary>
    /// 配置索引
    /// </summary>
    protected override void ConfigIndex( EntityTypeBuilder<Claim> builder ) {
        builder.HasIndex( t => t.Id ).IsUnique();
    }
}