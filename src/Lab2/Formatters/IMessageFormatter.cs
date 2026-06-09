using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public interface IMessageFormatter
{
    string Format(IMessage message);
}