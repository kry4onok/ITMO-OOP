namespace Itmo.ObjectOrientedProgramming.Lab1.MyRoute;

public class SegmentResult
{
    public bool Success { get; }

    public decimal Time { get; }

    public SegmentResult(bool success, decimal time)
    {
        Success = success;
        Time = time;
    }

    public static SegmentResult ReturnTimeAndSuccess(decimal time)
    {
        return time <= 0 ? new SegmentResult(false, 0m) : new SegmentResult(true, time);
    }
}