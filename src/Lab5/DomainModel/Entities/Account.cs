using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;

public sealed class Account
{
    public AccountNumber Id { get; }

    public PinHash PinCode { get; }

    public Money Balance { get; private set; }

    private readonly List<HistoryOperationAccount> _history = new();

    public IReadOnlyCollection<HistoryOperationAccount> History => _history.AsReadOnly();

    public Account(
        AccountNumber id,
        Money initialBalance,
        PinHash pinCode)
    {
        Id = id;
        Balance = initialBalance;
        PinCode = pinCode;
    }

    public OperationsResult Withdraw(Money amount)
    {
        if (amount.Currency != Balance.Currency)
        {
            return new OperationsResult.FailedOperation(
                $"Cannot withdraw {amount.Currency}. Account is in {Balance.Currency}");
        }

        if (amount.Amount <= 0)
        {
            var result = new OperationsResult.FailedOperation("Amount must be positive");
            AddOperation("Withdraw", amount, result);
            return result;
        }

        if (Balance < amount)
        {
            var result = new OperationsResult.FailedOperation("Insufficient funds");
            AddOperation("Withdraw", amount, result);
            return result;
        }

        Balance = Balance.SubtractAmount(amount);
        var successResult = new OperationsResult.SuccessfulOperation();
        AddOperation("Withdraw", amount, successResult);
        return successResult;
    }

    public OperationsResult Deposit(Money amount)
    {
        if (amount.Currency != Balance.Currency)
        {
            return new OperationsResult.FailedOperation(
                $"Cannot deposit {amount.Currency}. Account is in {Balance.Currency}");
        }

        if (amount.Amount <= 0)
        {
            var result = new OperationsResult.FailedOperation("Amount must be positive");
            AddOperation("Deposit", amount, result);
            return result;
        }

        Balance = Balance.AddAmount(amount);
        var successResult = new OperationsResult.SuccessfulOperation();
        AddOperation("Deposit", amount, successResult);
        return successResult;
    }

    private void AddOperation(string type, Money amount, OperationsResult status)
    {
        OperationsResult opStatus = status is OperationsResult.FailedOperation failed
            ? new OperationsResult.FailedOperation(failed.Reason)
            : new OperationsResult.SuccessfulOperation();

        _history.Add(new HistoryOperationAccount(
            DateTime.UtcNow,
            type,
            amount,
            opStatus));
    }
}
