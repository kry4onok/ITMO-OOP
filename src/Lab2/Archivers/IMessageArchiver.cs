using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public interface IMessageArchiver
{
    void Archive(IMessage message);
}