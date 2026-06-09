namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;

public record OperationsResult
{
    public sealed record SuccessfulOperation() : OperationsResult { }

    public sealed record FailedOperation(string Reason) : OperationsResult { }
}