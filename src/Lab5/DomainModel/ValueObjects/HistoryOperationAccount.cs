using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

public sealed record HistoryOperationAccount(
        DateTime OperationTime, string Type,
        Money Amount, OperationsResult Status)
{
    public bool IsSuccessful => Status is OperationsResult.SuccessfulOperation;

    public string? ErrorMessage => Status switch
    {
        OperationsResult.FailedOperation failed => failed.Reason,
        _ => null,
    };
}
