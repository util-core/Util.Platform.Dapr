using Util.Data;
using Util.Helpers;
using Util.Platform.Identity.Applications;
using Util.Platform.Identity.Domain.Models;

namespace Util.Platform.Identity;

/// <summary>
/// 应用配置扩展
/// </summary>
public static class ProgramExtensions {
    /// <summary>
    /// 配置控制器
    /// </summary>
    public static WebApplicationBuilder AddControllers( this WebApplicationBuilder builder ) {
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        return builder;
    }

    /// <summary>
    /// 配置Identity工作单元
    /// </summary>
    public static WebApplicationBuilder AddIdentityUnitOfWork( this WebApplicationBuilder builder ) {
        var dbType = builder.GetDatabaseType();
        builder.AsBuild()
            .AddSqlServerUnitOfWork<IIdentityUnitOfWork, Util.Platform.Identity.Data.SqlServer.IdentityUnitOfWork>(
                builder.GetIdentitySqlServerConnectionString(),
                condition: dbType == DatabaseType.SqlServer )
            .AddPgSqlUnitOfWork<IIdentityUnitOfWork, Util.Platform.Identity.Data.PgSql.IdentityUnitOfWork>(
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

    /// <summary>
    /// 配置身份验证服务器
    /// </summary>
    public static WebApplicationBuilder AddIdentityServer( this WebApplicationBuilder builder ) {
        builder.Services.AddIdentityServer( options => {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
        } )
            .AddAspNetIdentity<User>()
            .AddDeveloperSigningCredential()
            .AddResourceStore<ResourceStore>()
            .AddClientStore<ClientStore>()
            .AddCorsPolicyService<CorsPolicyService>()
            .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
            .AddProfileService<ProfileService>();
        return builder;
    }

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
    /// 配置异常页
    /// </summary>
    public static void UseCustomExceptionPage( this WebApplication app ) {
        if ( app.Environment.IsDevelopment() ) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseExceptionHandler( "/Error" );
            app.UseHsts();
        }
    }

    /// <summary>
    /// 配置Cookie策略
    /// </summary>
    public static void UseCookiePolicy( this WebApplication app ) {
        app.UseCookiePolicy( new CookiePolicyOptions {
            MinimumSameSitePolicy = SameSiteMode.Lax
        } );
    }

    /// <summary>
    /// 配置身份服务器
    /// </summary>
    public static void UseCustomIdentityServer( this WebApplication app ) {
        try {
            app.UseIdentityServer();
        }
        catch ( Exception ) {
            if( Common.IsLinux )
                throw;
        }
    }

    /// <summary>
    /// 数据迁移
    /// </summary>
    public static async Task MigrateAsync( this WebApplication app ) {
        if ( app.Environment.IsDevelopment() == false )
            return;
        if ( Common.IsWindows )
            return;
        var enabled = app.Configuration.GetValue<bool>( "Migration:Enabled" );
        if ( enabled == false )
            return;
        app.Logger.LogInformation( "准备迁移数据..." );
        using var scope = app.Services.CreateScope();
        var policy = scope.ServiceProvider.GetRequiredService<IPolicy>();
        await policy.Retry().HandleException<Exception>().Forever().Wait()
            .OnRetry( ( exception, retry ) => {
                var message = "迁移数据发生异常：{Message},已重试 {retry} 次.";
                app.Logger.LogWarning( exception, message, exception.Message, retry );
            } )
            .ExecuteAsync( async () => {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IIdentityUnitOfWork>();
                await unitOfWork.MigrateAsync();
            } );
        app.Logger.LogInformation( "迁移数据成功..." );
    }
}