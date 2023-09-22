namespace Util.Platform.Identity.Data.SqlServer.EntityTypeConfigurations; 

/// <summary>
/// 权限类型配置
/// </summary>
public class PermissionConfiguration : PermissionConfigurationBase {
    /// <summary>
    /// 配置索引
    /// </summary>
    protected override void ConfigIndex( EntityTypeBuilder<Permission> builder ) {
        builder.HasKey( t => t.Id ).IsClustered( false );
        builder.HasIndex( t => t.CreationTime ).IsClustered();
    }
}