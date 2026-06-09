namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters.Writers;

public class ConsoleMessageWriter : IMessageWriter
{
    public void Write(string formattedMessage)
    {
        Console.WriteLine(formattedMessage);
    }
}