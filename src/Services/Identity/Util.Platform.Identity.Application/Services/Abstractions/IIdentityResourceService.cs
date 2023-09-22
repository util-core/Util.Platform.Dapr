using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 身份资源服务
/// </summary>
public interface IIdentityResourceService : IIdentityResourceServiceBase<IdentityResourceDto, ResourceQuery> {
}