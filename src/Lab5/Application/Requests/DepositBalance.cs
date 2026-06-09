using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Requests;

public static class DepositBalance
{
    public sealed record DepositBalanceRequest(
        SessionId SessionId,
        DepositDTO Data)
        : IRequest<HandlerResult<DepositBalanceResponse>>;

    public sealed record DepositBalanceResponse(decimal NewBalance, Currency Currency);
}
