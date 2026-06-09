using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Requests;

public static class ViewHistory
{
    public sealed record ViewHistoryRequest(SessionId SessionId)
        : IRequest<HandlerResult<ViewHistoryResponse>>;

    public sealed record ViewHistoryResponse(IReadOnlyList<OperationHistoryDTO> History);
}
