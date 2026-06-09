using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.DepositBalance;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public sealed class DepositBalanceHandler
    : IRequestHandler<DepositBalanceRequest, HandlerResult<DepositBalanceResponse>>
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IAccountRepository _accountRepository;

    public DepositBalanceHandler(
        ISessionRepository sessionRepository,
        IAccountRepository accountRepository)
    {
        _sessionRepository = sessionRepository;
        _accountRepository = accountRepository;
    }

    public async ValueTask<HandlerResult<DepositBalanceResponse>> Handle(
        DepositBalanceRequest request,
        CancellationToken cancellationToken)
    {
        ISession? session = await _sessionRepository.GetSessionId(request.SessionId);

        if (session is null || session is AdminSession)
        {
            return new HandlerResult<DepositBalanceResponse>.FailedOperation(
                "Invalid user session");
        }

        var userSession = (UserSession)session;
        Account? account = await _accountRepository.GetAccountNumber(userSession.AccountNumber);

        if (account is null)
        {
            return new HandlerResult<DepositBalanceResponse>.FailedOperation(
                $"Account '{userSession.AccountNumber.Value}' not found");
        }

        HandlerResult<Currency> currencyResult = Currency.FromCode(request.Data.Currency);
        if (currencyResult is HandlerResult<Currency>.FailedOperation currencyFailed)
        {
            return new HandlerResult<DepositBalanceResponse>.FailedOperation(currencyFailed.Reason);
        }

        Currency currency = ((HandlerResult<Currency>.SuccessfulOperation)currencyResult).Value;
        HandlerResult<Money> moneyResult = Money.Create(request.Data.NewBalance, currency);
        if (moneyResult is HandlerResult<Money>.FailedOperation moneyFailed)
        {
            return new HandlerResult<DepositBalanceResponse>.FailedOperation(moneyFailed.Reason);
        }

        Money money = ((HandlerResult<Money>.SuccessfulOperation)moneyResult).Value;
        OperationsResult depositResult = account.Deposit(money);

        if (depositResult is OperationsResult.FailedOperation failed)
        {
            return new HandlerResult<DepositBalanceResponse>.FailedOperation(failed.Reason);
        }

        await _accountRepository.Save(account);

        var response = new DepositBalanceResponse(account.Balance.Amount, account.Balance.Currency);
        return new HandlerResult<DepositBalanceResponse>.SuccessfulOperation(response);
    }
}