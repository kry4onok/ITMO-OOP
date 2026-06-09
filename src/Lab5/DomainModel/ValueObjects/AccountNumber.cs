using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

public sealed record AccountNumber
{
    public string Value { get; }

    public AccountNumber(string value)
    {
        Value = value;
    }

    public static HandlerResult<AccountNumber> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return new HandlerResult<AccountNumber>.FailedOperation("Account number cannot be empty or null");

        if (value.Length != 8 || !value.All(char.IsDigit))
            return new HandlerResult<AccountNumber>.FailedOperation("Invalid account number format");

        return new HandlerResult<AccountNumber>.SuccessfulOperation(new AccountNumber(value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}