using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystem;

public interface INotificationSystem
{
    void Notification(IMessage message);
}