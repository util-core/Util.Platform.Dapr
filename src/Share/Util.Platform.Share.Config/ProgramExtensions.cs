namespace Util.Platform.Share.Config;

/// <summary>
/// 应用配置扩展
/// </summary>
public static class ProgramExtensions {
    /// <summary>
    /// Dapr微服务配置
    /// </summary>
    /// <param name="builder">Web应用生成器</param>
    /// <param name="appId">应用标识</param>
    public static WebApplicationBuilder AddDapr( this WebApplicationBuilder builder, string appId ) {
        builder.AsBuild()
            .AddDapr( options => {
                options.SecretStoreName = ShareConst.SecretStoreName;
                options.AppId = appId;
            } );
        return builder;
    }

    /// <summary>
    /// 配置租户
    /// </summary>
    /// <param name="builder">Web应用生成器</param>
    /// <param name="resolver">租户解析器</param>
    public static WebApplicationBuilder AddTenant( this WebApplicationBuilder builder, ITenantResolver resolver = null ) {
        builder.AsBuild().AddTenant(
            t => {
                t.Resolvers.Add( resolver );
                t.IsEnabled = false;
            }
        );
        return builder;
    }

    /// <summary>
    /// Util基础功能配置
    /// </summary>
    /// <param name="builder">Web应用生成器</param>
    /// <param name="appName">应用名称</param>
    public static WebApplicationBuilder AddUtil( this WebApplicationBuilder builder, string appName ) {
        builder.Environment.ApplicationName = appName;
        builder.AsBuild()
            .AddAop()
            .AddUtc()
            .AddJsonLocalization( options => {
                options.Cultures = new[] { "zh-CN", "en-US" };
            } )
            .AddSerilog( appName )
            .AddUtil();
        return builder;
    }

    /// <summary>
    /// 配置控制器,并注册Dapr
    /// </summary>
    public static WebApplicationBuilder AddControllersWithDapr( this WebApplicationBuilder builder ) {
        builder.Services.AddControllers( options => options.Filters.Add<AclFilter>() ).AddDapr();
        return builder;
    }

    /// <summary>
    /// 配置Redis缓存
    /// </summary>
    public static WebApplicationBuilder AddRedisCache( this WebApplicationBuilder builder ) {
        builder.AsBuild()
            .AddRedisCache( options => {
                options.DBConfig.Endpoints.Add(
                    new ServerEndPoint( builder.Configuration.GetConnectionString( "Redis" ), 6379 ) );
            } );
        return builder;
    }

    /// <summary>
    /// 配置认证方案 - Identity项目使用
    /// </summary>
    public static WebApplicationBuilder AddIdentityAuthentication( this WebApplicationBuilder builder ) {
        builder.Services
            .AddAuthentication( options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            } )
            .AddJwtBearer( JwtBearerDefaults.AuthenticationScheme, options => {
                options.Authority = builder.GetIdentityUrl();
                options.Audience = builder.GetAudience();
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters.ValidateIssuer = false;
            } );
        return builder;
    }

    /// <summary>
    /// 配置认证方案
    /// </summary>
    /// <param name="builder">Web应用生成器</param>
    public static WebApplicationBuilder AddAuthentication( this WebApplicationBuilder builder ) {
        builder.Services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme )
            .AddJwtBearer( options => {
                options.Authority = builder.GetIdentityUrl();
                options.Audience = builder.GetAudience();
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters.ValidateIssuer = false;
            } );
        return builder;
    }

    /// <summary>
    /// 配置Http日志
    /// </summary>
    public static WebApplicationBuilder AddHttpLogging( this WebApplicationBuilder builder ) {
        builder.Services.AddHttpLogging( options => options.LoggingFields = HttpLoggingFields.All );
        return builder;
    }

    /// <summary>
    /// 配置Cors
    /// </summary>
    public static void AddCors( this WebApplicationBuilder builder ) {
        builder.Services.AddCors( options => options.AddPolicy( "cors", policy => {
            policy.SetIsOriginAllowed( _ => true );
            policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        } ) );
    }

    /// <summary>
    /// 配置转发头部
    /// </summary>
    public static void AddForwardedHeaders( this WebApplicationBuilder builder ) {
        builder.Services.Configure<ForwardedHeadersOptions>( options => {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        } );
    }

    /// <summary>
    /// 配置Swagger服务
    /// </summary>
    public static WebApplicationBuilder AddSwagger( this WebApplicationBuilder builder ) {
        if ( builder.Environment.IsDevelopment() == false )
            return builder;
        var openApi = builder.Configuration.GetSection( "OpenApi" );
        if ( openApi.Exists() == false )
            return builder;
        var version = openApi.GetValue<string>( "Version" );
        var document = openApi.GetRequiredSection( "Document" );
        var title = document.GetValue<string>( "Title" );
        var description = document.GetValue<string>( "Description" );
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen( options => {
            options.SwaggerDoc( version, new OpenApiInfo {
                Title = title,
                Description = description,
                Version = version
            } );
            var identityUrl = builder.GetIdentityUrlExternal();
            options.AddSecurityDefinition( "oauth2", new OpenApiSecurityScheme {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows {
                    AuthorizationCode = new OpenApiOAuthFlow {
                        AuthorizationUrl = new Uri( $"{identityUrl}/connect/authorize" ),
                        TokenUrl = new Uri( $"{identityUrl}/connect/token" )
                    }
                }
            } );
            var oAuthScheme = new OpenApiSecurityScheme {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            };
            options.AddSecurityRequirement( new() {
                [oAuthScheme] = new List<string>()
            } );
        } );
        return builder;
    }

    /// <summary>
    /// 配置异常页
    /// </summary>
    public static void UseExceptionPage( this WebApplication app ) {
        if ( app.Environment.IsDevelopment() == false )
            return;
        app.UseDeveloperExceptionPage();
    }

    /// <summary>
    /// 配置本地化
    /// </summary>
    public static void UseLocalization( this WebApplication app ) {
        app.UseRequestLocalization();
    }

    /// <summary>
    /// 配置基路径
    /// </summary>
    public static void UsePathBase( this WebApplication app ) {
        var pathBase = app.GetPathBase();
        if ( pathBase.IsEmpty() )
            return;
        app.UsePathBase( pathBase );
    }

    /// <summary>
    /// 配置Swagger
    /// </summary>
    public static void UseCustomSwagger( this WebApplication app ) {
        if ( app.Environment.IsDevelopment() == false )
            return;
        var openApi = app.Configuration.GetSection( "OpenApi" );
        if ( openApi.Exists() == false )
            return;
        var version = openApi.GetValue<string>( "Version" );
        var endpoint = openApi.GetRequiredSection( "Endpoint" );
        var name = endpoint.GetValue<string>( "Name" );
        var clientId = endpoint.GetValue<string>( "ClientId" );
        var appName = endpoint.GetValue<string>( "AppName" );
        app.UseSwagger();
        app.UseSwaggerUI( options => {
            options.SwaggerEndpoint( $"/swagger/{version}/swagger.json", name );
            options.OAuthClientId( clientId );
            options.OAuthAppName( appName );
            options.OAuthScopes( "openid" );
            options.OAuthUsePkce();
            options.OAuthConfigObject.ClientSecret = "secret";
        } );
        app.MapGet( "/", () => Results.LocalRedirect( "~/swagger" ) );
    }

    /// <summary>
    /// 配置云事件格式
    /// </summary>
    public static void UseCustomCloudEvents( this WebApplication app ) {
        app.UseCloudEventHeaders();
        app.UseCloudEvents();
    }

    /// <summary>
    /// 配置健康检查
    /// </summary>
    public static void MapHealthChecks( this WebApplication app ) {
        app.MapHealthChecks( "/healthz/ready", new HealthCheckOptions {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        } );
        app.MapHealthChecks( "/healthz/live", new HealthCheckOptions {
            Predicate = r => r.Name.Contains( "self" )
        } );
    }
}