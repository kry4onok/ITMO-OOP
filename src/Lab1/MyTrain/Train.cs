namespace Itmo.ObjectOrientedProgramming.Lab1.MyTrain;

public class Train
{
    public decimal Weight { get; private set; }

    public decimal Speed { get; private set; }

    public decimal Boost { get; private set; }

    public decimal MaxAllowableForce { get; private set; }

    public Train(decimal weight, decimal maxAllowableForce)
    {
        Weight = weight;
        MaxAllowableForce = maxAllowableForce;
    }

    public bool AppliedForce(decimal force)
    {
        if (force > MaxAllowableForce)
        {
            return false;
        }

        Boost = force / Weight;
        return true;
    }

    public void ClearBoost()
    {
        Boost = 0m;
    }

    public decimal TimeCalculation(decimal distance, decimal accuracy)
    {
        decimal remainingDistance = distance;
        decimal time = 0m;

        if (Speed <= 0m && Boost <= 0m)
        {
            return -1;
        }

        while (remainingDistance > 0m)
        {
            decimal resultingSpeed = Speed + (Boost * accuracy);
            decimal distanceTraveled = resultingSpeed * accuracy;

            if (resultingSpeed <= 0m)
            {
                return -1;
            }

            Speed = resultingSpeed;
            remainingDistance -= distanceTraveled;
            time += accuracy;
        }

        return time;
    }

    public void ClearSpeed()
    {
        Speed = 0m;
    }

    public void SetSpeed(decimal speed)
    {
        Speed = speed;
    }
}