using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// Api资源服务
/// </summary>
public interface IApiResourceService : IApiResourceServiceBase<ApiResourceDto, CreateApiResourceRequest, ResourceQuery> {
}