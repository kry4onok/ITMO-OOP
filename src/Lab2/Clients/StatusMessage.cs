namespace Itmo.ObjectOrientedProgramming.Lab2.Clients;

public abstract record StatusMessage
{
    private StatusMessage() { }

    public sealed record Read() : StatusMessage();

    public sealed record NotFound() : StatusMessage();

    public sealed record Unread() : StatusMessage();
}