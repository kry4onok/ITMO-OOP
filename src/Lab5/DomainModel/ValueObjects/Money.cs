using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

public sealed record Money
{
    public decimal Amount { get; }

    public Currency Currency { get; }

    public Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static HandlerResult<Money> Create(decimal amount, Currency currency)
    {
        if (amount < 0)
            return new HandlerResult<Money>.FailedOperation("Amount cannot be negative");

        if (amount == 0)
            return new HandlerResult<Money>.FailedOperation("Amount must be positive");

        return new HandlerResult<Money>.SuccessfulOperation(new Money(amount, currency));
    }

    public OperationsResult Add(Money right)
    {
        if (Currency != right.Currency)
        {
            return new OperationsResult.FailedOperation(
                $"Cannot add {Currency} and {right.Currency}");
        }

        return new OperationsResult.SuccessfulOperation();
    }

    public OperationsResult Subtract(Money right)
    {
        if (Currency != right.Currency)
        {
            return new OperationsResult.FailedOperation(
                $"Cannot subtract {Currency} and {right.Currency}");
        }

        if (Amount < right.Amount)
            return new OperationsResult.FailedOperation("Insufficient funds");

        return new OperationsResult.SuccessfulOperation();
    }

    public Money AddAmount(Money right)
    {
        return new Money(Amount + right.Amount, Currency);
    }

    public Money SubtractAmount(Money right)
    {
        return new Money(Amount - right.Amount, Currency);
    }

    public static bool operator <(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            return false;

        return left.Amount < right.Amount;
    }

    public static bool operator >(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            return false;

        return left.Amount > right.Amount;
    }

    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }
}