using Util.Platform.Identity.Data.Seeds;

namespace Util.Platform.Identity.Data.EntityTypeConfigurations; 

/// <summary>
/// 用户角色类型配置
/// </summary>
public abstract class UserRoleConfigurationBase : UserRoleConfigurationBase<UserRole> {
    /// <summary>
    /// 配置默认数据
    /// </summary>
    protected override void ConfigData( EntityTypeBuilder<UserRole> builder ) {
        builder.HasData( UserSeed.CreateDefaultUserRoles() );
    }
}