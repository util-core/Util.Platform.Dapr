using Util.Platform.ApiGateway.Services.Abstractions;

namespace Util.Platform.ApiGateway.Services.Implements {
    /// <summary>
    /// 身份标识服务
    /// </summary>
    public class IdentityService : IIdentityService {
        /// <summary>
        /// 初始化身份标识服务
        /// </summary>
        /// <param name="serviceInvocation">服务调用操作</param>
        public IdentityService( IServiceInvocation serviceInvocation ) {
            ServiceInvocation = serviceInvocation ?? throw new ArgumentNullException( nameof( serviceInvocation ) );
            ServiceInvocation.Service( ShareConfig.GetIdentityAppId() );
        }

        /// <summary>
        /// 服务调用操作
        /// </summary>
        protected IServiceInvocation ServiceInvocation { get; }

        /// <inheritdoc />
        public async Task<ApplicationDto> GetApplicationByIdAsync( Guid applicationId, CancellationToken cancellationToken = default ) {
            return await ServiceInvocation.InvokeAsync<ApplicationDto>( $"application/{applicationId}", cancellationToken );
        }

        /// <inheritdoc />
        public async Task<UserDto> GetUserByIdAsync( Guid userId, CancellationToken cancellationToken = default ) {
            return await ServiceInvocation.InvokeAsync<UserDto>( $"user/{userId}", cancellationToken );
        }

        /// <inheritdoc />
        public async Task<AppResources> GetAppResourcesAsync() {
            return await ServiceInvocation.InvokeAsync<AppResources>( "Permission/AppResources" );
        }
    }
}
