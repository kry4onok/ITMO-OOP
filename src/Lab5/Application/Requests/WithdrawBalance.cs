using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Requests;

public static class WithdrawBalance
{
    public sealed record WithdrawBalanceRequest(
        SessionId SessionId,
        WithdrawDTO Data)
        : IRequest<HandlerResult<WithdrawBalanceResponse>>;

    public sealed record WithdrawBalanceResponse(decimal NewBalance, Currency Currency);
}
