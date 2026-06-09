namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public interface IMessage
{
    string Title { get; }

    string Body { get; }

    ImportanceLevel Importance { get; }
}