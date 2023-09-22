namespace Util.Platform.Identity.Data.PgSql.EntityTypeConfigurations;

/// <summary>
/// 权限类型配置
/// </summary>
public class PermissionConfiguration : PermissionConfigurationBase {
    /// <summary>
    /// 配置索引
    /// </summary>
    protected override void ConfigIndex( EntityTypeBuilder<Permission> builder ) {
        builder.HasIndex( t => t.Id ).IsUnique();
    }
}