using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;

public interface ISessionRepository
{
    Task Save(ISession session);

    Task DeleteSession(SessionId sessionId);

    Task<ISession?> GetSessionId(SessionId sessionId);

    Task<bool> ExistsSession(SessionId sessionId);
}