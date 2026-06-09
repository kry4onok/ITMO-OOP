using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public interface IAddressee
{
    void Receive(IMessage message);
}