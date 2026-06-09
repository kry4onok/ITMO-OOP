namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public abstract record ImportanceLevel
{
    public string Name { get; }

    public int Priorety { get; }

    protected ImportanceLevel(string name, int priorety)
    {
        Name = name;
        Priorety = priorety;
    }

    public sealed record LowImportance() : ImportanceLevel("Low", 1);

    public sealed record NormalImportance() : ImportanceLevel("Normal", 2);

    public sealed record HighImportance() : ImportanceLevel("High", 3);

    public override string ToString()
    {
        return $"{Name} (Priority: {Priorety})";
    }
}