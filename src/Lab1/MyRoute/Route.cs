using Itmo.ObjectOrientedProgramming.Lab1.MyTrain;

namespace Itmo.ObjectOrientedProgramming.Lab1.MyRoute;

public class Route
{
    public IEnumerable<RouteSegment> Segments { get; }

    public decimal PermissibleFinalSpeed { get; }

    public Route(IEnumerable<RouteSegment> segments, decimal permissibleFinalSpeed)
    {
        Segments = segments.ToList().AsReadOnly();
        PermissibleFinalSpeed = permissibleFinalSpeed;
    }

    public RouteResult CalculateRoute(Train train, decimal accuracy)
    {
        decimal totalTime = 0m;

        foreach (RouteSegment segment in Segments)
        {
            SegmentResult result = segment.Pass(train, accuracy);

            if (!result.Success)
            {
                return new RouteResult.Failure(totalTime);
            }

            totalTime += result.Time;
        }

        if (train.Speed > PermissibleFinalSpeed)
        {
            return new RouteResult.Failure(totalTime);
        }

        if (train.Speed > 0)
        {
            train.ClearSpeed();
        }

        return new RouteResult.Success(totalTime);
    }
}