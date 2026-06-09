using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.Decorator;

public class ConsoleLogging : ILogging
{
    public void Log(IMessage message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy:MM:dd HH:mm:ss} {message}]");
    }
}