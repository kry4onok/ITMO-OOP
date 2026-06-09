using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Microsoft.AspNetCore.Mvc;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Controllers;

[ApiController]
public abstract class BaseApiController : ControllerBase
{
    protected ActionResult HandleResult<TSuccess>(HandlerResult<TSuccess> result)
    {
        return result switch
        {
            HandlerResult<TSuccess>.SuccessfulOperation success => Ok(success.Value),
            HandlerResult<TSuccess>.FailedOperation failure => BadRequest(new { error = failure.Reason }),
            _ => StatusCode(500, new { error = "Unknown error" }),
        };
    }
}
