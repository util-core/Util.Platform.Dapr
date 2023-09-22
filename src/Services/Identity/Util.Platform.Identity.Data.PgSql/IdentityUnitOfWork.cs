namespace Util.Platform.Identity.Data.PgSql;

/// <summary>
/// Identity工作单元
/// </summary>
public class IdentityUnitOfWork : PgSqlUnitOfWorkBase, IIdentityUnitOfWork {
    /// <summary>
    /// 初始化Identity工作单元
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="options">配置项</param>
    public IdentityUnitOfWork( IServiceProvider serviceProvider,DbContextOptions<IdentityUnitOfWork> options ) : base( serviceProvider,options ) {
    }
}