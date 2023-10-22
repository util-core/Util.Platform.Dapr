namespace Util.Platform.Identity.Data.MySql.EntityTypeConfigurations;

/// <summary>
/// 用户类型配置
/// </summary>
public class UserConfiguration : UserConfigurationBase {
    /// <summary>
    /// 配置表
    /// </summary>
    protected override void ConfigTable( EntityTypeBuilder<User> builder ) {
        builder.ToTable( "User", t => t.HasComment( "用户" ) );
    }

    /// <summary>
    /// 配置索引
    /// </summary>
    protected override void ConfigIndex( EntityTypeBuilder<User> builder ) {
        builder.HasIndex( t => t.Id ).IsUnique();
    }
}