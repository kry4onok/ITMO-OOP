using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystem;

public class SoundNotification
{
    public void Notification(IMessage message)
    {
        Console.Beep();
    }
}