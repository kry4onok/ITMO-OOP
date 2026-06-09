namespace Itmo.ObjectOrientedProgramming.Lab1.MyRoute;

public class RouteResultSuccess : IRouteResult
{
    public decimal TotalTime { get; }

    public RouteResultSuccess(decimal totalTime)
    {
        TotalTime = totalTime;
    }
}