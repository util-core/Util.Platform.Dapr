using Util.Platform.Identity.Data.Seeds;

namespace Util.Platform.Identity.Data.EntityTypeConfigurations; 

/// <summary>
/// 权限类型配置
/// </summary>
public abstract class PermissionConfigurationBase : PermissionConfigurationBase<Permission,Resource> {
    /// <summary>
    /// 配置默认数据
    /// </summary>
    protected override void ConfigData( EntityTypeBuilder<Permission> builder ) {
        builder.HasData( PermissionSeed.CreateDefaultPermissions() );
    }
}