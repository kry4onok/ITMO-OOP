namespace Itmo.ObjectOrientedProgramming.Lab1.MyRoute;

public abstract record RouteResult
{
    public decimal TotalTime { get; }

    protected RouteResult(decimal totalTime)
    {
        TotalTime = totalTime;
    }

    public sealed record Success(decimal TotalTime) : RouteResult(TotalTime);

    public sealed record Failure(decimal TotalTime) : RouteResult(TotalTime);
}