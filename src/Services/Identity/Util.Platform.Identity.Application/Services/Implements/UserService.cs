using Util.Platform.Identity.Applications.Services.Abstractions;
using Util.Platform.Identity.Data;
using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Domain.Repositories;
using Util.Platform.Identity.Domain.Services.Abstractions;
using Util.Platform.Identity.Dtos;
using Util.Platform.Identity.Queries;

namespace Util.Platform.Identity.Applications.Services.Implements;

/// <summary>
/// 用户服务
/// </summary>
public class UserService : UserServiceBase<IIdentityUnitOfWork,User,Role, UserDto, CreateUserRequest, UserQuery>, IUserService {
    /// <summary>
    /// 初始化用户服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="unitOfWork">工作单元</param>
    /// <param name="userRepository">用户仓储</param>
    /// <param name="userManager">用户服务</param>
    public UserService( IServiceProvider serviceProvider, IIdentityUnitOfWork unitOfWork, IUserRepository userRepository, IUserManager userManager )
        : base( serviceProvider, unitOfWork, userRepository, userManager ) {
    }
}