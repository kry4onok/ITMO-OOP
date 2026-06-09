using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.ProxyProtection;

public class AddresseeFilter : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly IFilter _filter;

    public AddresseeFilter(IAddressee addressee, IFilter filter)
    {
        _addressee = addressee;
        _filter = filter;
    }

    public void Receive(IMessage message)
    {
        if (_filter.FilterPriorety(message))
        {
            _addressee.Receive(message);
        }
    }
}