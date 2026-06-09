using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;
using Mediator;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.CreateAdminSession;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public sealed class CreateAdminSessionHandler
    : IRequestHandler<CreateAdminSessionRequest, HandlerResult<CreateAdminSessionResponse>>
{
    private readonly IAdminPasswordValidator _validator;
    private readonly ISessionRepository _sessionRepository;

    public CreateAdminSessionHandler(
        IAdminPasswordValidator validator,
        ISessionRepository sessionRepository)
    {
        _validator = validator;
        _sessionRepository = sessionRepository;
    }

    public async ValueTask<HandlerResult<CreateAdminSessionResponse>> Handle(
        CreateAdminSessionRequest request,
        CancellationToken cancellationToken)
    {
        bool isValid = await _validator.ValidateAsync(request.SystemPassword);

        if (!isValid)
        {
            return new HandlerResult<CreateAdminSessionResponse>.FailedOperation(
                "Invalid admin password");
        }

        var session = new AdminSession(SessionId.New());
        await _sessionRepository.Save(session);

        var response = new CreateAdminSessionResponse(session.Id);
        return new HandlerResult<CreateAdminSessionResponse>.SuccessfulOperation(response);
    }
}
