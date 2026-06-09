using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.CreateAdminSession;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.CreateUserSession;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Controllers;

[Route("api/[controller]")]
public class SessionController : BaseApiController
{
    private readonly IMediator _mediator;

    public SessionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("admin")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateAdminSession(
        [FromBody] CreateAdminSessionModel model,
        CancellationToken cancellationToken)
    {
        var request = new CreateAdminSessionRequest(model.Password);
        HandlerResult<CreateAdminSessionResponse> result = await _mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpPost("user")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateUserSession(
        [FromBody] CreateUserSessionModel model,
        CancellationToken cancellationToken)
    {
        var dto = new CreateUserSessionDTO(
            model.AccountNumber,
            model.PinCode);

        var request = new CreateUserSessionRequest(dto);
        HandlerResult<CreateUserSessionResponse> result = await _mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }
}
