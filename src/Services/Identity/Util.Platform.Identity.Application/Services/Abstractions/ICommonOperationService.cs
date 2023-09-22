using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 常用操作资源服务
/// </summary>
public interface ICommonOperationService : ICommonOperationServiceBase<CommonOperationDto, CommonOperationQuery> {
}