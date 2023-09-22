namespace Util.Platform.ApiGateway.Services.Abstractions;

/// <summary>
/// 身份标识服务
/// </summary>
public interface IIdentityService : IService {
    /// <summary>
    /// 通过标识获取应用程序
    /// </summary>
    /// <param name="applicationId">应用程序标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<ApplicationDto> GetApplicationByIdAsync( Guid applicationId, CancellationToken cancellationToken = default );
    /// <summary>
    /// 通过标识获取用户
    /// </summary>
    /// <param name="userId">用户标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<UserDto> GetUserByIdAsync( Guid userId, CancellationToken cancellationToken = default );
    /// <summary>
    /// 获取授予当前用户的前端应用资源
    /// </summary>
    Task<AppResources> GetAppResourcesAsync();
}