using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkdownFormatter : IMessageFormatter
{
    public string Format(IMessage message)
    {
        return $"# {message.Title}\n" + $"{message.Body}\n";
    }
}