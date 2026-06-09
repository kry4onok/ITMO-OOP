using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeGroup : IAddressee
{
    private readonly List<IAddressee> _addressees;

    public AddresseeGroup(IEnumerable<IAddressee> addressees)
    {
        _addressees = new List<IAddressee>(addressees);
    }

    public void Receive(IMessage message)
    {
        foreach (IAddressee addressees in _addressees)
        {
            addressees.Receive(message);
        }
    }
}