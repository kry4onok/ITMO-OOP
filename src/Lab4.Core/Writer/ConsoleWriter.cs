namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}