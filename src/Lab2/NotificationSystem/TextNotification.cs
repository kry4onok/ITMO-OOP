using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystem;

public class TextNotification : INotificationSystem
{
    public void Notification(IMessage message)
    {
        Console.WriteLine($"[ALERT] Message detected: {message.Title}");
    }
}