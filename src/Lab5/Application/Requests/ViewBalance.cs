using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Requests;

public static class ViewBalance
{
    public sealed record ViewBalanceRequest(SessionId SessionId)
        : IRequest<HandlerResult<ViewBalanceResponse>>;

    public sealed record ViewBalanceResponse(decimal Balance, Currency Currency);
}
