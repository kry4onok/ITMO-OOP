using Itmo.ObjectOrientedProgramming.Lab2.Addressees.FilterSuspiciousWords;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.NotificationSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeNotification : IAddressee
{
    private readonly INotificationSystem _system;
    private readonly IFilterMessageNotification _filter;

    public AddresseeNotification(INotificationSystem system, IFilterMessageNotification filter)
    {
        _system = system;
        _filter = filter;
    }

    public void Receive(IMessage message)
    {
        if (_filter.CheckSuspicious(message))
        {
            _system.Notification(message);
        }
    }
}