using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Abstractions;

/// <summary>
/// 声明服务
/// </summary>
public interface IClaimService : IClaimServiceBase<ClaimDto, ClaimQuery> {
}