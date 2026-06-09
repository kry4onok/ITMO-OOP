using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using NSubstitute;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.WithdrawBalance;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class WithdrawBalanceHandlerTests
{
    [Fact]
    public async Task Withdraw_WithSufficientBalance_UpdatesAccountAndReturnsSuccess()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new WithdrawBalanceHandler(sessionRepository, accountRepository);

        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(1000, Currency.Rub);
        var withdrawAmount = new Money(500, Currency.Rub);

        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);

        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);

        var request = new WithdrawBalanceRequest(
            sessionId,
            new WithdrawDTO(withdrawAmount.Amount, withdrawAmount.Currency.Code));

        HandlerResult<WithdrawBalanceResponse> result = await handler.Handle(request, CancellationToken.None);

        Assert.IsType<HandlerResult<WithdrawBalanceResponse>.SuccessfulOperation>(result);
        await accountRepository.Received(1).Save(Arg.Is<Account>(a => a.Balance.Amount == 500));
    }

    [Fact]
    public async Task Withdraw_WithInsufficientBalance_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new WithdrawBalanceHandler(sessionRepository, accountRepository);

        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(300, Currency.Rub);
        var withdrawAmount = new Money(500, Currency.Rub);

        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);

        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);

        var request = new WithdrawBalanceRequest(
            sessionId,
            new WithdrawDTO(withdrawAmount.Amount, withdrawAmount.Currency.Code));

        HandlerResult<WithdrawBalanceResponse> result = await handler.Handle(request, CancellationToken.None);

        Assert.IsType<HandlerResult<WithdrawBalanceResponse>.FailedOperation>(result);

        var failedResult = (HandlerResult<WithdrawBalanceResponse>.FailedOperation)result;
        Assert.Contains(
            "Insufficient funds",
            failedResult.Reason,
            StringComparison.OrdinalIgnoreCase);

        await accountRepository.DidNotReceive().Save(Arg.Any<Account>());
    }

    [Fact]
    public async Task Withdraw_WithDifferentCurrency_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new WithdrawBalanceHandler(sessionRepository, accountRepository);

        var sessionId = new SessionId(Guid.NewGuid());
        var accountNumber = new AccountNumber("12345678");
        var initialBalance = new Money(1000, Currency.Rub);

        var account = new Account(accountNumber, initialBalance, new PinHash("hashed_pin"));
        var userSession = new UserSession(sessionId, accountNumber);

        sessionRepository.GetSessionId(sessionId).Returns(userSession);
        accountRepository.GetAccountNumber(accountNumber).Returns(account);

        var request = new WithdrawBalanceRequest(
            sessionId,
            new WithdrawDTO(500, Currency.Usd.Code));

        HandlerResult<WithdrawBalanceResponse> result = await handler.Handle(request, CancellationToken.None);

        Assert.IsType<HandlerResult<WithdrawBalanceResponse>.FailedOperation>(result);

        var failedResult = (HandlerResult<WithdrawBalanceResponse>.FailedOperation)result;
        Assert.Contains(
            "Cannot withdraw",
            failedResult.Reason,
            StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Withdraw_InvalidSession_ReturnsFailedOperation()
    {
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var handler = new WithdrawBalanceHandler(sessionRepository, accountRepository);

        var sessionId = new SessionId(Guid.NewGuid());
        sessionRepository.GetSessionId(sessionId).Returns((ISession?)null);

        var request = new WithdrawBalanceRequest(
            sessionId,
            new WithdrawDTO(500, Currency.Rub.Code));

        HandlerResult<WithdrawBalanceResponse> result = await handler.Handle(request, CancellationToken.None);

        Assert.IsType<HandlerResult<WithdrawBalanceResponse>.FailedOperation>(result);
    }
}
