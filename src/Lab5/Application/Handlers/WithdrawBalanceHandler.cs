using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.WithdrawBalance;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public sealed class WithdrawBalanceHandler
    : IRequestHandler<WithdrawBalanceRequest, HandlerResult<WithdrawBalanceResponse>>
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IAccountRepository _accountRepository;

    public WithdrawBalanceHandler(
        ISessionRepository sessionRepository,
        IAccountRepository accountRepository)
    {
        _sessionRepository = sessionRepository;
        _accountRepository = accountRepository;
    }

    public async ValueTask<HandlerResult<WithdrawBalanceResponse>> Handle(
        WithdrawBalanceRequest request,
        CancellationToken cancellationToken)
    {
        ISession? session = await _sessionRepository.GetSessionId(request.SessionId);

        if (session is null || session is AdminSession)
        {
            return new HandlerResult<WithdrawBalanceResponse>.FailedOperation(
                "Invalid user session");
        }

        var userSession = (UserSession)session;
        Account? account = await _accountRepository.GetAccountNumber(userSession.AccountNumber);

        if (account is null)
        {
            return new HandlerResult<WithdrawBalanceResponse>.FailedOperation(
                $"Account '{userSession.AccountNumber.Value}' not found");
        }

        HandlerResult<Currency> currencyResult = Currency.FromCode(request.Data.Currency);
        if (currencyResult is HandlerResult<Currency>.FailedOperation currencyFailed)
        {
            return new HandlerResult<WithdrawBalanceResponse>.FailedOperation(currencyFailed.Reason);
        }

        Currency currency = ((HandlerResult<Currency>.SuccessfulOperation)currencyResult).Value;
        HandlerResult<Money> moneyResult = Money.Create(request.Data.NewBalance, currency);
        if (moneyResult is HandlerResult<Money>.FailedOperation moneyFailed)
        {
            return new HandlerResult<WithdrawBalanceResponse>.FailedOperation(moneyFailed.Reason);
        }

        Money money = ((HandlerResult<Money>.SuccessfulOperation)moneyResult).Value;
        OperationsResult withdrawResult = account.Withdraw(money);

        if (withdrawResult is OperationsResult.FailedOperation failed)
        {
            return new HandlerResult<WithdrawBalanceResponse>.FailedOperation(failed.Reason);
        }

        await _accountRepository.Save(account);

        var response = new WithdrawBalanceResponse(account.Balance.Amount, account.Balance.Currency);
        return new HandlerResult<WithdrawBalanceResponse>.SuccessfulOperation(response);
    }
}