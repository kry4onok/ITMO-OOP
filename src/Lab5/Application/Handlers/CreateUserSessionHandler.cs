using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.CreateUserSession;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public sealed class CreateUserSessionHandler
    : IRequestHandler<CreateUserSessionRequest, HandlerResult<CreateUserSessionResponse>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ISessionRepository _sessionRepository;
    private readonly IPinHash _pinHasher;

    public CreateUserSessionHandler(
        IAccountRepository accountRepository,
        ISessionRepository sessionRepository,
        IPinHash pinHasher)
    {
        _accountRepository = accountRepository;
        _sessionRepository = sessionRepository;
        _pinHasher = pinHasher;
    }

    public async ValueTask<HandlerResult<CreateUserSessionResponse>> Handle(
        CreateUserSessionRequest request,
        CancellationToken cancellationToken)
    {
        var accountNumber = new AccountNumber(request.Data.AccountNumber);
        Account? account = await _accountRepository.GetAccountNumber(accountNumber);

        if (account is null)
        {
            return new HandlerResult<CreateUserSessionResponse>.FailedOperation(
                "Account not found");
        }

        string hashedPin = _pinHasher.Hash(request.Data.PinCode);

        if (account.PinCode.Value != hashedPin)
        {
            return new HandlerResult<CreateUserSessionResponse>.FailedOperation(
                "Invalid PIN code");
        }

        var session = new UserSession(SessionId.New(), accountNumber);
        await _sessionRepository.Save(session);

        var response = new CreateUserSessionResponse(session.Id);
        return new HandlerResult<CreateUserSessionResponse>.SuccessfulOperation(response);
    }
}
