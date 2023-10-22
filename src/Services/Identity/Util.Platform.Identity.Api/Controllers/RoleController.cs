namespace Util.Platform.Identity.Api.Controllers;

/// <summary>
/// 角色控制器
/// </summary>
[Acl( "role.view" )]
public class RoleController : CrudControllerBase<RoleDto, CreateRoleRequest, UpdateRoleRequest, RoleQuery> {
    /// <summary>
    /// 初始化角色控制器
    /// </summary>
    /// <param name="service">角色服务</param>
    public RoleController( IRoleService service ) : base( service ) {
        RoleService = service ?? throw new ArgumentNullException( nameof( service ) );
    }

    /// <summary>
    /// 角色服务
    /// </summary>
    public IRoleService RoleService { get; }

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
    public new async Task<IActionResult> PageQueryAsync( [FromQuery] RoleQuery query ) {
        return await base.PageQueryAsync( query );
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="request">创建参数</param>
    [HttpPost]
    [Acl( "role.create" )]
    public new async Task<IActionResult> CreateAsync( CreateRoleRequest request ) {
        return await base.CreateAsync( request );
    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="id">标识</param>
    /// <param name="request">修改参数</param>
    [HttpPut( "{id?}" )]
    [Acl( "role.update" )]
    public new async Task<IActionResult> UpdateAsync( string id, UpdateRoleRequest request ) {
        return await base.UpdateAsync( id, request );
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="ids">标识列表，多个Id用逗号分隔，范例：1,2,3</param>
    [HttpPost( "delete" )]
    [Acl( "role.delete" )]
    public new async Task<IActionResult> DeleteAsync( [FromBody] string ids ) {
        return await base.DeleteAsync( ids );
    }

    /// <summary>
    /// 添加用户到角色
    /// </summary>
    /// <param name="request">角色用户参数</param>
    [HttpPost( "AddUsersToRole" )]
    [Acl( "role.userSettings" )]
    public async Task<IActionResult> AddUsersToRoleAsync( RoleUsersRequest request ) {
        await RoleService.AddUsersToRoleAsync( request );
        return Success();
    }

    /// <summary>
    /// 从角色移除用户
    /// </summary>
    /// <param name="request">角色用户参数</param>
    [HttpPost( "RemoveUsersFromRole" )]
    [Acl( "role.userSettings" )]
    public async Task<IActionResult> RemoveUsersFromRoleAsync( RoleUsersRequest request ) {
        await RoleService.RemoveUsersFromRoleAsync( request );
        return Success();
    }
}