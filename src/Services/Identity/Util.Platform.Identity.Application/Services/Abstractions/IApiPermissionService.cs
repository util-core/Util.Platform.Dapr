using Util.Platform.Identity.Dtos;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// Api权限服务
/// </summary>
public interface IApiPermissionService : IApiPermissionServiceBase<ApiResourceDto,PermissionRequest> {
}