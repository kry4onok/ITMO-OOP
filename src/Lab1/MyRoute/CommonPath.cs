using Itmo.ObjectOrientedProgramming.Lab1.MyTrain;

namespace Itmo.ObjectOrientedProgramming.Lab1.MyRoute;

public class CommonPath : RouteSegment
{
    public CommonPath(decimal length) : base(length) { }

    public override SegmentResult Pass(Train train, decimal accuracy)
    {
        decimal time = train.TimeCalculation(Length, accuracy);
        return SegmentResult.ReturnTimeAndSuccess(time);
    }
}