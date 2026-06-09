using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Clients;

public interface IUser
{
    string Name { get; }

    void Receive(IMessage message);

    ResultStatusMessage MarkTheMessage(string title);

    StatusMessage GetStatus(string title);
}