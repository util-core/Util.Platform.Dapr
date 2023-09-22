namespace Util.Platform.Identity.Data.SqlServer.EntityTypeConfigurations;

/// <summary>
/// 常用操作资源类型配置
/// </summary>
public class CommonOperationConfiguration : CommonOperationConfigurationBase {
    /// <summary>
    /// 配置索引
    /// </summary>
    protected override void ConfigIndex( EntityTypeBuilder<CommonOperation> builder ) {
        builder.HasKey( t => t.Id ).IsClustered( false );
        builder.HasIndex( t => t.CreationTime ).IsClustered();
    }
}