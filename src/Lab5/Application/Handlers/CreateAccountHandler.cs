using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.CreateAccount;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public sealed class CreateAccountHandler
    : IRequestHandler<CreateAccountRequest, HandlerResult<CreateAccountResponse>>
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IPinHash _pinHash;

    public CreateAccountHandler(
        ISessionRepository sessionRepository,
        IAccountRepository accountRepository,
        IPinHash pinHash)
    {
        _sessionRepository = sessionRepository;
        _accountRepository = accountRepository;
        _pinHash = pinHash;
    }

    public async ValueTask<HandlerResult<CreateAccountResponse>> Handle(
        CreateAccountRequest request,
        CancellationToken cancellationToken)
    {
        ISession? session = await _sessionRepository.GetSessionId(request.AdminSessionId);

        if (session is null)
        {
            return new HandlerResult<CreateAccountResponse>.FailedOperation(
                "Invalid session. Admin must be logged in.");
        }

        if (session is not AdminSession)
        {
            return new HandlerResult<CreateAccountResponse>.FailedOperation(
                "Only administrator can create accounts. Current session is not admin.");
        }

        var accountNumber = new AccountNumber(request.Request.AccountNumber);
        bool accountExists = await _accountRepository.ExistsAccount(accountNumber);

        if (accountExists)
        {
            return new HandlerResult<CreateAccountResponse>.FailedOperation(
                $"Account with number '{request.Request.AccountNumber}' already exists.");
        }

        HandlerResult<Currency> currencyResult = Currency.FromCode(request.Request.Currency);
        if (currencyResult is HandlerResult<Currency>.FailedOperation currencyFailed)
        {
            return new HandlerResult<CreateAccountResponse>.FailedOperation(currencyFailed.Reason);
        }

        Currency currency = ((HandlerResult<Currency>.SuccessfulOperation)currencyResult).Value;

        HandlerResult<Money> moneyResult = Money.Create(request.Request.InitialBalance, currency);
        if (moneyResult is HandlerResult<Money>.FailedOperation moneyFailed)
        {
            return new HandlerResult<CreateAccountResponse>.FailedOperation(moneyFailed.Reason);
        }

        Money money = ((HandlerResult<Money>.SuccessfulOperation)moneyResult).Value;

        string hashPin = _pinHash.Hash(request.Request.PinCode);

        var account = new Account(
            accountNumber,
            money,
            new PinHash(hashPin));

        await _accountRepository.Save(account);

        var response = new CreateAccountResponse(
            account.Id.Value,
            account.Balance.Amount,
            account.Balance.Currency.Code);

        return new HandlerResult<CreateAccountResponse>.SuccessfulOperation(response);
    }
}
