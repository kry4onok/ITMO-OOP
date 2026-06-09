using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.Decorator;

public interface ILogging
{
    void Log(IMessage message);
}