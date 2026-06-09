using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeArchiver : IAddressee
{
    private readonly IMessageArchiver _archiver;

    public AddresseeArchiver(IMessageArchiver archiver)
    {
        _archiver = archiver;
    }

    public void Receive(IMessage message)
    {
        _archiver.Archive(message);
    }
}