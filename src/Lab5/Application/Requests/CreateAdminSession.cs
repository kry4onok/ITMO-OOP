using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Requests;

public static class CreateAdminSession
{
    public sealed record CreateAdminSessionRequest(string SystemPassword)
        : IRequest<HandlerResult<CreateAdminSessionResponse>>;

    public sealed record CreateAdminSessionResponse(SessionId SessionId);
}
