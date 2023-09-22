namespace Util.Platform.Identity.Data.Seeds; 

/// <summary>
/// 应用程序数据种子
/// </summary>
public static class ApplicationSeed {
    /// <summary>
    /// 创建默认应用程序
    /// </summary>
    public static IEnumerable<Application> CreateDefaultApplications() {
        return new[] {
            new Application( SeedConst.ApplicationId ) {
                Code = "admin-ui",
                Name = "管理系统后台",
                Enabled = true,
                IsClient = true,
                AccessTokenLifetime = 3600,
                AllowOfflineAccess = true,
                AllowedCorsOrigins = "https://localhost:16003",
                RedirectUri = "https://localhost:16003/",
                CreationTime = DateTime.UtcNow,
                LastModificationTime = DateTime.UtcNow,
                CreatorId = SeedConst.UserId,
                LastModifierId = SeedConst.UserId,
                Version = "53c89d04-d5e7-43ea-860e-7fafa7cfc380"u8.ToArray()
            },
            new Application( SeedConst.ApiApplicationId ) {
                Code = "admin-api",
                Name = "管理系统Api",
                Enabled = true,
                IsApi = true,
                CreationTime = DateTime.UtcNow,
                LastModificationTime = DateTime.UtcNow,
                CreatorId = SeedConst.UserId,
                LastModifierId = SeedConst.UserId,
                Version = "9ca734db-c97c-4454-acdb-80e8ddf0ed41"u8.ToArray()
            },
            new Application( SeedConst.ApiGatewaySwaggerId ) {
                Code = "api-gateway-swagger",
                Name = "Swagger UI - Api网关",
                Enabled = true,
                IsClient = true,
                AccessTokenLifetime = 3600,
                AllowOfflineAccess = true,
                AllowedCorsOrigins = "http://localhost:30101",
                RedirectUri = "http://localhost:30101/swagger/oauth2-redirect.html",
                CreationTime = DateTime.UtcNow,
                LastModificationTime = DateTime.UtcNow,
                CreatorId = SeedConst.UserId,
                LastModifierId = SeedConst.UserId,
                Version = "f9f88b4b-ebca-4815-8c6e-6c701fac65da"u8.ToArray()
            },
            new Application( SeedConst.IdentityApiSwaggerId ) {
                Code = "identity-api-swagger",
                Name = "Swagger UI - Identity Api",
                Enabled = true,
                IsClient = true,
                AccessTokenLifetime = 3600,
                AllowOfflineAccess = true,
                AllowedCorsOrigins = "http://localhost:30102",
                RedirectUri = "http://localhost:30102/swagger/oauth2-redirect.html",
                CreationTime = DateTime.UtcNow,
                LastModificationTime = DateTime.UtcNow,
                CreatorId = SeedConst.UserId,
                LastModifierId = SeedConst.UserId,
                Version = "a13ca9b4-99eb-4f0d-a230-bcd1eada2cdf"u8.ToArray()
            }
        };
    }
}