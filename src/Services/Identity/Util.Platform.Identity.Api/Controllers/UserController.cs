namespace Util.Platform.Identity.Api.Controllers;

/// <summary>
/// 用户控制器
/// </summary>
[Acl( "user.view" )]
public class UserController : CrudControllerBase<UserDto, CreateUserRequest, UserDto, UserQuery> {
    /// <summary>
    /// 初始化用户控制器
    /// </summary>
    /// <param name="service">用户服务</param>
    public UserController( IUserService service ) : base( service ) {
        UserService = service ?? throw new ArgumentNullException( nameof( service ) );
    }

    /// <summary>
    /// 用户服务
    /// </summary>
    protected IUserService UserService { get; }

    /// <summary>
    /// 获取单个实体
    /// </summary>
    /// <param name="id">标识</param>
    [HttpGet( "{id}" )]
    public new async Task<IActionResult> GetAsync( string id ) {
        return await base.GetAsync( id );
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="query">查询参数</param>
    [HttpGet]
    public new async Task<IActionResult> PageQueryAsync( [FromQuery] UserQuery query ) {
        return await base.PageQueryAsync( query );
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="request">创建参数</param>
    [HttpPost]
    [Acl( "user.create" )]
    public new async Task<IActionResult> CreateAsync( CreateUserRequest request ) {
        return await base.CreateAsync( request );
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="ids">标识列表，多个Id用逗号分隔，范例：1,2,3</param>
    [HttpPost( "delete" )]
    [Acl( "user.delete" )]
    public new async Task<IActionResult> DeleteAsync( [FromBody] string ids ) {
        return await base.DeleteAsync( ids );
    }
}