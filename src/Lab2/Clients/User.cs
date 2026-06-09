using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Clients;

public class User : IUser
{
    private readonly List<UserMessage> _messages = new List<UserMessage>();

    public string Name { get; }

    public User(string name)
    {
        Name = name;
    }

    public void Receive(IMessage message)
    {
        _messages.Add(new UserMessage(message));
    }

    public ResultStatusMessage MarkTheMessage(string title)
    {
        UserMessage? foundMessage = null;

        foreach (UserMessage message in _messages)
        {
            if (message.Message.Title == title)
            {
                foundMessage = message;
                break;
            }
        }

        if (foundMessage == null)
        {
            return new ResultStatusMessage.NotFound();
        }

        return foundMessage.MarkRead();
    }

    public StatusMessage GetStatus(string title)
    {
        foreach (UserMessage message in _messages)
        {
            if (message.Message.Title == title)
            {
                return message.Status;
            }
        }

        return new StatusMessage.NotFound();
    }
}