using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Session;

public sealed class AdminSession : ISession
{
    public SessionId Id { get; private set; }

    public DateTime CreatedIn { get; }

    public AdminSession(SessionId id)
    {
        Id = id;
        CreatedIn = DateTime.UtcNow;
    }
}