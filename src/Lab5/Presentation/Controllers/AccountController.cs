using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.CreateAccount;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.DepositBalance;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.ViewBalance;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.ViewHistory;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.WithdrawBalance;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Controllers;

[Route("api/[controller]")]
public class AccountController : BaseApiController
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateAccount(
        [FromHeader] Guid adminSessionId,
        [FromBody] CreateAccountModel model,
        CancellationToken cancellationToken)
    {
        var dto = new CreateAccountDTO(
        model.AccountNumber,
        model.PinCode,
        model.InitialBalance,
        model.Currency);

        var request = new CreateAccountRequest(
            new SessionId(adminSessionId),
            dto);

        HandlerResult<CreateAccountResponse> result = await _mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpGet("balance")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> ViewBalance(
        [FromHeader] Guid sessionId,
        CancellationToken cancellationToken)
    {
        var request = new ViewBalanceRequest(new SessionId(sessionId));
        HandlerResult<ViewBalanceResponse> result = await _mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpPost("deposit")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Deposit(
        [FromHeader] Guid sessionId,
        [FromBody] DepositModel model,
        CancellationToken cancellationToken)
    {
        var dto = new DepositDTO(model.Amount, model.Currency);

        var request = new DepositBalanceRequest(
            new SessionId(sessionId),
            dto);

        HandlerResult<DepositBalanceResponse> result = await _mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpPost("withdraw")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Withdraw(
        [FromHeader] Guid sessionId,
        [FromBody] WithdrawModel model,
        CancellationToken cancellationToken)
    {
        var dto = new WithdrawDTO(model.Amount, model.Currency);

        var request = new WithdrawBalanceRequest(
            new SessionId(sessionId),
            dto);

        HandlerResult<WithdrawBalanceResponse> result = await _mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpGet("history")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> ViewHistory(
        [FromHeader] Guid sessionId,
        CancellationToken cancellationToken)
    {
        var request = new ViewHistoryRequest(new SessionId(sessionId));
        HandlerResult<ViewHistoryResponse> result = await _mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }
}
