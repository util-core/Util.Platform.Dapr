using Util.Platform.Identity.Data.Seeds;

namespace Util.Platform.Identity.Data.EntityTypeConfigurations;

/// <summary>
/// 资源类型配置
/// </summary>
public abstract class ResourceConfigurationBase : ResourceConfigurationBase<Resource,Application> {
    /// <summary>
    /// 配置默认数据
    /// </summary>
    protected override void ConfigData( EntityTypeBuilder<Resource> builder ) {
        builder.HasData( ResourceSeed.CreateDefaultResources() );
    }
}