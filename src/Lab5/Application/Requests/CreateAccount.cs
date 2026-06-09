using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Requests;

public static class CreateAccount
{
    public sealed record CreateAccountRequest(
        SessionId AdminSessionId,
        CreateAccountDTO Request)
        : IRequest<HandlerResult<CreateAccountResponse>>;

    public sealed record CreateAccountResponse(string AccountNumber, decimal Balance, string Currency);
}
