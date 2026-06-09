using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

public sealed record PinHash
{
    public string Value { get; }

    public PinHash(string hash)
    {
        Value = hash;
    }

    public static HandlerResult<PinHash> Create(string hash)
    {
        if (string.IsNullOrEmpty(hash))
            return new HandlerResult<PinHash>.FailedOperation("PinCode cannot be null or empty");

        return new HandlerResult<PinHash>.SuccessfulOperation(new PinHash(hash));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}