namespace Itmo.ObjectOrientedProgramming.Lab2.Clients;

public abstract record ResultStatusMessage
{
    private ResultStatusMessage() { }

    public sealed record AlreadyMarkAsRead() : ResultStatusMessage();

    public sealed record NotFound() : ResultStatusMessage();

    public sealed record MarkAsRead() : ResultStatusMessage();
}