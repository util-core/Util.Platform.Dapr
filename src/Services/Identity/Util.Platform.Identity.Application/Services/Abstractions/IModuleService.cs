using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 模块服务
/// </summary>
public interface IModuleService : IModuleServiceBase<ModuleDto, CreateModuleRequest, ResourceQuery> {
}