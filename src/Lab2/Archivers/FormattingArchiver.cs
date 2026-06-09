using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters.Writers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class FormattingArchiver : IMessageArchiver
{
    private readonly IMessageFormatter _formatter;

    private readonly IMessageWriter _writer;

    public FormattingArchiver(IMessageFormatter formatter, IMessageWriter writer)
    {
        _formatter = formatter;
        _writer = writer;
    }

    public void Archive(IMessage message)
    {
        string formattedMessage = _formatter.Format(message);
        _writer.Write(formattedMessage);
    }
}