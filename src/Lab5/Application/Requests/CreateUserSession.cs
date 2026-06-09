using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Requests;

public static class CreateUserSession
{
    public sealed record CreateUserSessionRequest(CreateUserSessionDTO Data)
        : IRequest<HandlerResult<CreateUserSessionResponse>>;

    public sealed record CreateUserSessionResponse(SessionId SessionId);
}
