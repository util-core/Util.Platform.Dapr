using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 操作资源服务
/// </summary>
public interface IOperationService : IOperationServiceBase<OperationDto, ResourceQuery, CreateOperationRequest, ApiResourceDto> {
}