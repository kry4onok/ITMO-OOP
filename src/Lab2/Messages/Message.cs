namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class Message : IMessage
{
    public string Title { get; }

    public string Body { get; }

    public ImportanceLevel Importance { get; }

    public Message(string title, string body, ImportanceLevel importance)
    {
        Title = title;
        Body = body;
        Importance = importance;
    }

    public override string ToString()
    {
        return $"{Title} | {Body} | Importance: {Importance}";
    }
}