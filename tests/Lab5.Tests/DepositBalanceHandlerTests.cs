using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using NSubstitute;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.DepositBalance;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class DepositBalanceHandlerTests
{
    [Fact]
    public async Task Deposit_WithValidAmount_UpdatesAccountAndReturnsSuccess()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);
        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(1000, Currency.Rub);
        var depositAmount = new Money(500, Currency.Rub);
        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);
        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);
        var request = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(depositAmount.Amount, depositAmount.Currency.Code));
        HandlerResult<DepositBalanceResponse> result = await handler.Handle(request, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.SuccessfulOperation>(result);
        await accountRepository.Received(1).Save(
            Arg.Is<Account>(a => a.Balance.Amount == 1500));
    }

    [Fact]
    public async Task Deposit_WithNegativeAmount_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);

        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(1000, Currency.Rub);

        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);

        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);

        var request = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(-500, Currency.Rub.Code));

        HandlerResult<DepositBalanceResponse> result = await handler.Handle(request, CancellationToken.None);

        Assert.IsType<HandlerResult<DepositBalanceResponse>.FailedOperation>(result);
        var failedResult = (HandlerResult<DepositBalanceResponse>.FailedOperation)result;
        Assert.Contains(
            "Amount cannot be negative",
            failedResult.Reason,
            StringComparison.OrdinalIgnoreCase);
        await accountRepository.DidNotReceive().Save(Arg.Any<Account>());
    }

    [Fact]
    public async Task Deposit_WithZeroAmount_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);
        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(1000, Currency.Rub);
        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);
        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);
        var request = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(0, Currency.Rub.Code));
        HandlerResult<DepositBalanceResponse> result = await handler.Handle(request, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.FailedOperation>(result);
        await accountRepository.DidNotReceive().Save(Arg.Any<Account>());
    }

    [Fact]
    public async Task Deposit_WithDifferentCurrency_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);
        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(1000, Currency.Rub);
        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);
        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);
        var request = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(500, Currency.Usd.Code));
        HandlerResult<DepositBalanceResponse> result = await handler.Handle(request, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.FailedOperation>(result);
        var failedResult = (HandlerResult<DepositBalanceResponse>.FailedOperation)result;
        Assert.Contains(
            "Cannot deposit",
            failedResult.Reason,
            StringComparison.OrdinalIgnoreCase);
        await accountRepository.DidNotReceive().Save(Arg.Any<Account>());
    }

    [Fact]
    public async Task Deposit_InvalidSession_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);
        var sessionId = new SessionId(Guid.NewGuid());
        sessionRepository.GetSessionId(sessionId).Returns((ISession?)null);
        var request = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(500, Currency.Rub.Code));
        HandlerResult<DepositBalanceResponse> result = await handler.Handle(request, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.FailedOperation>(result);
    }

    [Fact]
    public async Task Deposit_AdminSessionInvalid_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);
        var sessionId = new SessionId(Guid.NewGuid());
        var adminSession = new AdminSession(sessionId);
        sessionRepository.GetSessionId(sessionId).Returns(adminSession);
        var request = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(500, Currency.Rub.Code));
        HandlerResult<DepositBalanceResponse> result = await handler.Handle(request, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.FailedOperation>(result);
    }

    [Fact]
    public async Task Deposit_AccountNotFound_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);
        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var userSession = new UserSession(sessionId, accountNumber);
        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns((Account?)null);
        var request = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(500, Currency.Rub.Code));
        HandlerResult<DepositBalanceResponse> result = await handler.Handle(request, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.FailedOperation>(result);
    }

    [Fact]
    public async Task Deposit_LargeAmount_UpdatesAccountCorrectly()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);
        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(1000, Currency.Rub);
        var depositAmount = new Money(999999, Currency.Rub);
        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);
        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);
        var request = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(depositAmount.Amount, depositAmount.Currency.Code));
        HandlerResult<DepositBalanceResponse> result = await handler.Handle(request, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.SuccessfulOperation>(result);
        await accountRepository.Received(1).Save(
            Arg.Is<Account>(a => a.Balance.Amount == 1000999));
    }

    [Fact]
    public async Task Deposit_MultipleDeposits_BalanceAccumulates()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new DepositBalanceHandler(sessionRepository, accountRepository);
        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(1000, Currency.Rub);
        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);
        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);
        var request1 = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(500, Currency.Rub.Code));
        HandlerResult<DepositBalanceResponse> result1 = await handler.Handle(request1, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.SuccessfulOperation>(result1);
        account = new Account(accountNumber, new Money(1500, Currency.Rub), new PinHash("hashed_pin"));
        accountRepository.GetAccountNumber(accountNumber).Returns(account);
        var request2 = new DepositBalanceRequest(
            sessionId,
            new DepositDTO(300, Currency.Rub.Code));
        HandlerResult<DepositBalanceResponse> result2 = await handler.Handle(request2, CancellationToken.None);
        Assert.IsType<HandlerResult<DepositBalanceResponse>.SuccessfulOperation>(result2);
        await accountRepository.Received(2).Save(Arg.Any<Account>());
    }
}
