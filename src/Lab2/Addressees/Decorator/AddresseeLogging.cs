using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.Decorator;

public class AddresseeLogging : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly ILogging _logger;

    public AddresseeLogging(IAddressee addressee, ILogging logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void Receive(IMessage message)
    {
        _logger.Log(message);
        _addressee.Receive(message);
    }
}