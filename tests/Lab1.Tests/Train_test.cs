using Itmo.ObjectOrientedProgramming.Lab1.MyRoute;
using Itmo.ObjectOrientedProgramming.Lab1.MyTrain;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Train_test
{
    [Fact]
    public void PowerRouteAcceleratingTheTrainToThePermissibleRouteSpeed()
    {
        var train = new Train(weight: 1000m, maxAllowableForce: 10000m);

        var segments = new List<RouteSegment>
        {
            new PowerPath(length: 100m, force: 5000m),
            new CommonPath(length: 500m),
        };

        var route = new Route(segments, permissibleFinalSpeed: 300m);

        RouteResult result = route.CalculateRoute(train, accuracy: 1m);

        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void PowerRouteAcceleratingTrainOverThePermissibleRouteSpeed()
    {
        var train = new Train(weight: 1000m, maxAllowableForce: 10000m);

        var segments = new List<RouteSegment>
        {
            new PowerPath(length: 100m, force: 1000m),
            new CommonPath(length: 300),
        };

        var route = new Route(segments, permissibleFinalSpeed: 10m);

        RouteResult result = route.CalculateRoute(train, accuracy: 1m);

        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void PowerRouteAcceleratingTheTrainToThePermissibleSpeedOfTheRouteAndStation()
    {
        var train = new Train(weight: 1000m, maxAllowableForce: 10000m);

        var segments = new List<RouteSegment>
        {
            new PowerPath(length: 100m, force: 5000m),
            new CommonPath(length: 300m),
            new Station(length: 150m, permissibleSpeedStation: 1000m),
            new CommonPath(length: 200m),
        };

        var route = new Route(segments, permissibleFinalSpeed: 1000m);

        RouteResult result = route.CalculateRoute(train, accuracy: 1m);

        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void PowerRouteAcceleratingTrainOverThePermissibleStationSpeed()
    {
        var train = new Train(weight: 1000m, maxAllowableForce: 10000m);

        var segments = new List<RouteSegment>
        {
            new PowerPath(length: 100m, force: 5000m),
            new Station(length: 150m, permissibleSpeedStation: 10m),
            new CommonPath(length: 200m),
        };

        var route = new Route(segments, permissibleFinalSpeed: 1000m);

        RouteResult result = route.CalculateRoute(train, accuracy: 1m);

        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void PowerRouteAcceleratingTrainOverThePermissibleRouteSpeedButUpToThePermissibleStationSpeed()
    {
        var train = new Train(weight: 1000m, maxAllowableForce: 10000m);

        var segments = new List<RouteSegment>
        {
            new PowerPath(length: 100m, force: 5000m),
            new CommonPath(length: 200m),
            new Station(length: 150m, permissibleSpeedStation: 1000m),
            new CommonPath(length: 300m),
        };

        var route = new Route(segments, permissibleFinalSpeed: 10m);

        RouteResult result = route.CalculateRoute(train, accuracy: 1m);

        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void FourPowerRoute()
    {
        var train = new Train(weight: 1000m, maxAllowableForce: 10000m);

        var segments = new List<RouteSegment>
        {
            new PowerPath(length: 100m, force: 5000m),
            new CommonPath(length: 150m),
            new PowerPath(length: 100m, force: -3000m),
            new Station(length: 150m, permissibleSpeedStation: 20m),
            new CommonPath(length: 300m),
            new PowerPath(length: 100m, force: 3000m),
            new CommonPath(length: 250m),
            new PowerPath(length: 100m, force: -1000m),
        };

        var route = new Route(segments, permissibleFinalSpeed: 27m);

        RouteResult result = route.CalculateRoute(train, accuracy: 1m);

        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void BasicRoute()
    {
        var train = new Train(weight: 1000m, maxAllowableForce: 10000m);

        var segments = new List<RouteSegment>
        {
            new CommonPath(length: 200m),
        };

        var route = new Route(segments, permissibleFinalSpeed: 1000m);

        RouteResult result = route.CalculateRoute(train, accuracy: 1m);

        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void TwoPowerRouteLengthX()
    {
        var train = new Train(weight: 1000m, maxAllowableForce: 10000m);

        decimal x = 100m;
        decimal y = 4000m;

        var segments = new List<RouteSegment>
        {
            new PowerPath(length: x, force: y),
            new PowerPath(length: x, force: -2 * y),
        };

        var route = new Route(segments, permissibleFinalSpeed: 300m);

        RouteResult result = route.CalculateRoute(train, accuracy: 0.1m);

        Assert.IsType<RouteResult.Failure>(result);
    }
}