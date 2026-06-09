using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Session;

public sealed class UserSession : ISession
{
    public SessionId Id { get; }

    public DateTime CreatedIn { get; }

    public AccountNumber AccountNumber { get; private set; }

    public UserSession(SessionId id, AccountNumber accountNumber)
    {
        Id = id;
        CreatedIn = DateTime.UtcNow;
        AccountNumber = accountNumber;
    }
}