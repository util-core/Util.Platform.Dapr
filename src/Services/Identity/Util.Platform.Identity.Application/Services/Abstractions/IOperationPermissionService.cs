using Util.Platform.Identity.Dtos;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 操作权限服务
/// </summary>
public interface IOperationPermissionService : IOperationPermissionServiceBase<OperationPermissionDto, PermissionRequest> {
}