namespace Util.Platform.Identity.Data.SqlServer.EntityTypeConfigurations; 

/// <summary>
/// 角色类型配置
/// </summary>
public class RoleConfiguration : RoleConfigurationBase {
    /// <summary>
    /// 配置索引
    /// </summary>
    protected override void ConfigIndex( EntityTypeBuilder<Role> builder ) {
        builder.HasKey( t => t.Id ).IsClustered( false );
        builder.HasIndex( t => t.CreationTime ).IsClustered();
    }
}