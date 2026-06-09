namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

public abstract record CommandResult()
{
    public bool IsSuccess => this is Success;

    public bool IsFailure => this is Failure;

    public sealed record Success() : CommandResult();

    public sealed record Failure() : CommandResult();
}
