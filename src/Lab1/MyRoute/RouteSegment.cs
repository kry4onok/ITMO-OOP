using Itmo.ObjectOrientedProgramming.Lab1.MyTrain;

namespace Itmo.ObjectOrientedProgramming.Lab1.MyRoute;

public abstract class RouteSegment
{
    public decimal Length { get; }

    protected RouteSegment(decimal length)
    {
        Length = length;
    }

    public abstract SegmentResult Pass(Train train, decimal accuracy);
}