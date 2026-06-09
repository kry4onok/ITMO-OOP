using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Mediator;
using static Itmo.ObjectOrientedProgramming.Lab5.Application.Requests.ViewHistory;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public sealed class ViewHistoryHandler
    : IRequestHandler<ViewHistoryRequest, HandlerResult<ViewHistoryResponse>>
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IAccountRepository _accountRepository;

    public ViewHistoryHandler(
        ISessionRepository sessionRepository,
        IAccountRepository accountRepository)
    {
        _sessionRepository = sessionRepository;
        _accountRepository = accountRepository;
    }

    public async ValueTask<HandlerResult<ViewHistoryResponse>> Handle(
        ViewHistoryRequest request,
        CancellationToken cancellationToken)
    {
        ISession? session = await _sessionRepository.GetSessionId(request.SessionId);

        if (session is null || session is AdminSession)
        {
            return new HandlerResult<ViewHistoryResponse>.FailedOperation(
                "Invalid user session");
        }

        var userSession = (UserSession)session;
        Account? account = await _accountRepository.GetAccountNumber(userSession.AccountNumber);

        if (account is null)
        {
            return new HandlerResult<ViewHistoryResponse>.FailedOperation(
                $"Account '{userSession.AccountNumber.Value}' not found");
        }

        IReadOnlyList<OperationHistoryDTO> history = account.History
            .Select(op => new OperationHistoryDTO(
                op.OperationTime,
                op.Type,
                op.Amount.Amount,
                op.Amount.Currency.Code,
                op.IsSuccessful,
                op.ErrorMessage))
            .ToList();

        var response = new ViewHistoryResponse(history);
        return new HandlerResult<ViewHistoryResponse>.SuccessfulOperation(response);
    }
}
