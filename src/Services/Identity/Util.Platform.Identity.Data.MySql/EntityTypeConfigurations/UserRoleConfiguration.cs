namespace Util.Platform.Identity.Data.MySql.EntityTypeConfigurations;

/// <summary>
/// 用户角色类型配置
/// </summary>
public class UserRoleConfiguration : UserRoleConfigurationBase {
    /// <summary>
    /// 配置表
    /// </summary>
    protected override void ConfigTable( EntityTypeBuilder<UserRole> builder ) {
        builder.ToTable( "UserRole", t => t.HasComment( "用户角色" ) );
    }
}