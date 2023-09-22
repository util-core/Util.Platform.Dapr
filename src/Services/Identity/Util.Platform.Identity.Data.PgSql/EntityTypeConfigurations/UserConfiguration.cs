namespace Util.Platform.Identity.Data.PgSql.EntityTypeConfigurations;

/// <summary>
/// 用户类型配置
/// </summary>
public class UserConfiguration : UserConfigurationBase {
    /// <summary>
    /// 配置索引
    /// </summary>
    protected override void ConfigIndex( EntityTypeBuilder<User> builder ) {
        builder.HasIndex( t => t.Id ).IsUnique();
    }
}