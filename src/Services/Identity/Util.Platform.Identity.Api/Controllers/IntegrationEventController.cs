namespace Util.Platform.Identity.Api.Controllers;

/// <summary>
/// 集成事件控制器
/// </summary>
public class IntegrationEventController : IntegrationEventControllerBase {

    [HttpPost( "SignInEvent" )]
    [Topic( nameof( SignInEvent ) )]
    public IActionResult HandleSignInEventAsync( SignInEvent @event ) {
        return Success();
    }
}
