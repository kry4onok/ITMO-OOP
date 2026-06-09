using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class InMemoryArchiver : IMessageArchiver
{
    private readonly List<IMessage> _messages = new List<IMessage>();

    public void Archive(IMessage message)
    {
        _messages.Add(message);
    }

    public IReadOnlyList<IMessage> Messages => _messages.AsReadOnly();
}