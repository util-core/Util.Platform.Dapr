using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 应用程序服务
/// </summary>
public interface IApplicationService : IApplicationServiceBase<ApplicationDto, ApplicationQuery> {
}