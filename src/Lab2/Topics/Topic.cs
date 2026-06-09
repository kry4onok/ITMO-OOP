using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic : ITopic
{
    public string Name { get; }

    private readonly List<IAddressee> _addressees;

    public Topic(string name, IEnumerable<IAddressee> addressees)
    {
        Name = name;
        _addressees = new List<IAddressee>(addressees);
    }

    public void Send(IMessage message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.Receive(message);
        }
    }
}