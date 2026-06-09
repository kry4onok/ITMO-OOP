using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public interface ITopic
{
    string Name { get; }

    void Send(IMessage message);
}