using Itmo.ObjectOrientedProgramming.Lab1.MyTrain;

namespace Itmo.ObjectOrientedProgramming.Lab1.MyRoute;

public class Station : RouteSegment
{
    public decimal PermissibleSpeedStation { get; }

    public Station(decimal length, decimal permissibleSpeedStation) : base(length)
    {
        PermissibleSpeedStation = permissibleSpeedStation;
    }

    public override SegmentResult Pass(Train train, decimal accuracy)
    {
        decimal currentSpeed = train.Speed;
        if (currentSpeed > PermissibleSpeedStation)
        {
            return new SegmentResult(false, 0m);
        }

        train.ClearSpeed();

        train.SetSpeed(currentSpeed);

        decimal time = train.TimeCalculation(Length, accuracy);

        return SegmentResult.ReturnTimeAndSuccess(time);
    }
}