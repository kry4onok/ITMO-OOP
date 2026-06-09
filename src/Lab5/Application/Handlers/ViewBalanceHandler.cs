using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Mediator;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.ViewBalance;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public sealed class ViewBalanceHandler
    : IRequestHandler<ViewBalanceRequest, HandlerResult<ViewBalanceResponse>>
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IAccountRepository _accountRepository;

    public ViewBalanceHandler(
        ISessionRepository sessionRepository,
        IAccountRepository accountRepository)
    {
        _sessionRepository = sessionRepository;
        _accountRepository = accountRepository;
    }

    public async ValueTask<HandlerResult<ViewBalanceResponse>> Handle(
        ViewBalanceRequest request,
        CancellationToken cancellationToken)
    {
        ISession? session = await _sessionRepository.GetSessionId(request.SessionId);

        if (session is null || session is AdminSession)
        {
            return new HandlerResult<ViewBalanceResponse>.FailedOperation(
                "Invalid user session");
        }

        var userSession = (UserSession)session;
        Account? account = await _accountRepository.GetAccountNumber(userSession.AccountNumber);

        if (account is null)
        {
            return new HandlerResult<ViewBalanceResponse>.FailedOperation(
                $"Account '{userSession.AccountNumber.Value}' not found");
        }

        var response = new ViewBalanceResponse(account.Balance.Amount, account.Balance.Currency);
        return new HandlerResult<ViewBalanceResponse>.SuccessfulOperation(response);
    }
}
