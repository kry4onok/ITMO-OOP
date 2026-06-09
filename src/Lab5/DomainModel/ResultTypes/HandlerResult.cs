namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;

public abstract record HandlerResult<TValue>
{
    private HandlerResult() { }

    public sealed record SuccessfulOperation(TValue Value) : HandlerResult<TValue>;

    public sealed record FailedOperation(string Reason) : HandlerResult<TValue>;
}
