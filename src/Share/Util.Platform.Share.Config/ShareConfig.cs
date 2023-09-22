﻿namespace Util.Platform.Share.Config; 

/// <summary>
/// 共享配置
/// </summary>
public static class ShareConfig {
    /// <summary>
    /// 获取Identity SqlServer数据库连接字符串
    /// </summary>
    public static string GetIdentitySqlServerConnectionString( this WebApplicationBuilder builder ) {
        return builder.Configuration.GetConnectionString( "Identity:SqlServer" );
    }

    /// <summary>
    /// 获取Identity PgSql数据库连接字符串
    /// </summary>
    public static string GetIdentityPgSqlConnectionString( this WebApplicationBuilder builder ) {
        return builder.Configuration.GetConnectionString( "Identity:PgSql" );
    }

    /// <summary>
    /// 获取数据库类型
    /// </summary>
    public static DatabaseType GetDatabaseType( this WebApplicationBuilder builder ) {
        try {
            var dbType = builder.Configuration["DatabaseType"];
            return dbType.IsEmpty() ? DatabaseType.SqlServer : Util.Helpers.Enum.Parse<DatabaseType>( dbType );
        }
        catch {
            return DatabaseType.SqlServer;
        }
    }

    /// <summary>
    /// 获取身份认证服务器地址
    /// </summary>
    public static string GetIdentityUrl( this WebApplicationBuilder builder ) {
        return builder.Configuration["IdentityUrl"];
    }

    /// <summary>
    /// 获取外部身份认证服务器地址
    /// </summary>
    public static string GetIdentityUrlExternal( this WebApplicationBuilder builder ) {
        return builder.Configuration["IdentityUrlExternal"];
    }

    /// <summary>
    /// 获取令牌接收方
    /// </summary>
    public static string GetAudience( this WebApplicationBuilder builder ) {
        return builder.Configuration["Audience"];
    }

    /// <summary>
    /// 获取Identity Api健康检查Url
    /// </summary>
    public static string GetIdentityApiHealthCheckUrl( this WebApplicationBuilder builder ) {
        return builder.Configuration["IdentityApiHealthCheckUrl"];
    }

    /// <summary>
    /// 获取基路径
    /// </summary>
    public static string GetPathBase( this WebApplication app ) {
        return app.Configuration["PathBase"];
    }
}