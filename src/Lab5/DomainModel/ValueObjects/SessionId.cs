using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

public sealed record SessionId
{
    public Guid Value { get; }

    public SessionId(Guid value)
    {
        Value = value;
    }

    public static HandlerResult<SessionId> Create(Guid value)
    {
        if (value == Guid.Empty)
            return new HandlerResult<SessionId>.FailedOperation("Session id cannot be null or empty");

        return new HandlerResult<SessionId>.SuccessfulOperation(new SessionId(value));
    }

    public static SessionId New()
    {
        return new(Guid.NewGuid());
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}