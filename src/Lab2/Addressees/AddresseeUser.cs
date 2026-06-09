using Itmo.ObjectOrientedProgramming.Lab2.Clients;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeUser : IAddressee
{
    private readonly IUser _user;

    public AddresseeUser(IUser user)
    {
        _user = user;
    }

    public void Receive(IMessage message)
    {
        _user.Receive(message);
    }
}