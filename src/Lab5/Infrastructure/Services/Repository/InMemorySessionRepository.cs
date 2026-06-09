using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Services.Repository;

public sealed class InMemorySessionRepository : ISessionRepository
{
    private readonly Dictionary<SessionId, ISession> _sessions = new();

    public Task Save(ISession session)
    {
        _sessions[session.Id] = session;
        return Task.CompletedTask;
    }

    public Task DeleteSession(SessionId sessionId)
    {
        _sessions.Remove(sessionId);
        return Task.CompletedTask;
    }

    public Task<ISession?> GetSessionId(SessionId sessionId)
    {
        _sessions.TryGetValue(sessionId, out ISession? session);
        return Task.FromResult(session);
    }

    public Task<bool> ExistsSession(SessionId sessionId)
    {
        return Task.FromResult(_sessions.ContainsKey(sessionId));
    }
}