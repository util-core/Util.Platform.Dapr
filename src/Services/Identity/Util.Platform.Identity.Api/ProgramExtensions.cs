﻿using Util.Platform.Identity.Applications;

namespace Util.Platform.Identity.Api;

/// <summary>
/// 应用配置扩展
/// </summary>
public static class ProgramExtensions {
    /// <summary>
    /// 配置健康检查
    /// </summary>
    public static WebApplicationBuilder AddHealthChecks( this WebApplicationBuilder builder ) {
        builder.Services.AddHealthChecks()
            .AddCheck( "self", () => HealthCheckResult.Healthy() )
            .AddUnitOfWork<IIdentityUnitOfWork>()
            .AddDapr();
        return builder;
    }

    /// <summary>
    /// 配置Identity工作单元
    /// </summary>
    public static WebApplicationBuilder AddIdentityUnitOfWork( this WebApplicationBuilder builder ) {
        var dbType = builder.GetDatabaseType();
        builder.AsBuild()
            .AddSqlServerUnitOfWork<IIdentityUnitOfWork, Data.SqlServer.IdentityUnitOfWork>(
                builder.GetIdentitySqlServerConnectionString(),
                condition: dbType == DatabaseType.SqlServer )
            .AddPgSqlUnitOfWork<IIdentityUnitOfWork, Data.PgSql.IdentityUnitOfWork>(
                builder.GetIdentityPgSqlConnectionString(),
                condition: dbType == DatabaseType.PgSql )
            .AddMySqlUnitOfWork<IIdentityUnitOfWork, Data.MySql.IdentityUnitOfWork>(
                builder.GetIdentityMySqlConnectionString(),
                condition: dbType == DatabaseType.MySql );
        return builder;
    }

    /// <summary>
    /// 配置身份标识服务
    /// </summary>
    /// <param name="builder">Web应用生成器</param>
    /// <param name="setupAction">权限配置</param>
    public static WebApplicationBuilder AddIdentity( this WebApplicationBuilder builder, Action<PermissionOptions> setupAction = null ) {
        builder.Services.AddIdentity( setupAction );
        return builder;
    }
}