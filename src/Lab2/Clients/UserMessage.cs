using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Clients;

public class UserMessage
{
    public IMessage Message { get; }

    public StatusMessage Status { get; private set; }

    public UserMessage(IMessage message)
    {
        Message = message;
        Status = new StatusMessage.Unread();
    }

    public ResultStatusMessage MarkRead()
    {
        if (Status is StatusMessage.Read)
        {
            return new ResultStatusMessage.AlreadyMarkAsRead();
        }

        Status = new StatusMessage.Read();
        return new ResultStatusMessage.MarkAsRead();
    }
}