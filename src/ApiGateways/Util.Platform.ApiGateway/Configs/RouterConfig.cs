namespace Util.Platform.ApiGateway.Configs;

/// <summary>
/// 路由配置
/// </summary>
public class RouterConfig {
    /// <summary>
    /// 获取路由配置
    /// </summary>
    public static IReadOnlyList<RouteConfig> GetRouteConfigs() {
        var toolsConfig = new RouteConfig {
            RouteId = "route_tools_api",
            ClusterId = "cluster_tools_api",
            Order = 1,
            Match = new RouteMatch {
                Path = "tools/{**catch-all}"
            }
        };
        var identityConfig = new RouteConfig {
            RouteId = "route_identity_api",
            ClusterId = "cluster_identity_api",
            Order = 2,
            Match = new RouteMatch {
                Path = "identity/{**catch-all}"
            }
        };
        return new List<RouteConfig> {
            toolsConfig.WithTransformPathRemovePrefix( "/tools" ),
            identityConfig.WithTransformPathRemovePrefix( "/identity" )
        };
    }

    /// <summary>
    /// 获取集群配置
    /// </summary>
    public static IReadOnlyList<ClusterConfig> GetClusterConfigs() {
        return new List<ClusterConfig> {
            new() {
                ClusterId = "cluster_tools_api",
                Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase) {
                    { "host_1", new DestinationConfig { Address = "http://tools-api" } }
                }
            },
            new() {
                ClusterId = "cluster_identity_api",
                Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase) {
                    { "host_1", new DestinationConfig { Address = "http://identity-api" } }
                }
            }
        };
    }
}