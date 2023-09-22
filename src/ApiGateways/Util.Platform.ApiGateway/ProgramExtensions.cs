using Microsoft.Extensions.Hosting;
using Util.Microservices.HealthChecks;
using Util.Platform.ApiGateway.Configs;

namespace Util.Platform.ApiGateway;

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
            .AddDapr()
            .AddUrl( builder.GetIdentityApiHealthCheckUrl(), "identity-api",new []{ "identity-api" } );
        return builder;
    }

    /// <summary>
    /// 配置反向代理
    /// </summary>
    public static WebApplicationBuilder AddReverseProxy( this WebApplicationBuilder builder ) {
        var reverseProxyBuilder = builder.Services.AddReverseProxy();
        if ( builder.Environment.IsDevelopment() )
            reverseProxyBuilder.LoadFromMemory( RouterConfig.GetRouteConfigs(), RouterConfig.GetClusterConfigs() );
        else
            reverseProxyBuilder.LoadFromConfig( builder.Configuration.GetSection( "ReverseProxy" ) );
        return builder;
    }
}