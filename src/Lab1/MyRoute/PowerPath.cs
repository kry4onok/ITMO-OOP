using Itmo.ObjectOrientedProgramming.Lab1.MyTrain;

namespace Itmo.ObjectOrientedProgramming.Lab1.MyRoute;

public class PowerPath : RouteSegment
{
    public decimal Force { get; private set; }

    public PowerPath(decimal length, decimal force) : base(length)
    {
        Force = force;
    }

    public override SegmentResult Pass(Train train, decimal accuracy)
    {
        if (!train.AppliedForce(Force))
        {
            return new SegmentResult(false, 0m);
        }

        decimal time = train.TimeCalculation(Length, accuracy);

        train.ClearBoost();

        return SegmentResult.ReturnTimeAndSuccess(time);
    }
}