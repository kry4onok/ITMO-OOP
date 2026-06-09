namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

public sealed record PathVO
{
    public string Value { get; }

    public bool IsAbsolute { get; }

    public PathVO(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty("Path cannot be empty or null.", nameof(value));

        Value = value;

        IsAbsolute = System.IO.Path.IsPathFullyQualified(value);
    }
}