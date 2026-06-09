using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public abstract class CommandParserLinkBase : ICommandParserLink
{
    private ICommandParserLink? _next;

    public void SetNext(ICommandParserLink next)
    {
        _next = next;
    }

    public ICommand? Handle(string input)
    {
        ICommand? result = HandleInternal(input);
        if (result is not null)
        {
            return result;
        }

        if (_next is not null)
        {
            return _next.Handle(input);
        }

        return null;
    }

    protected abstract ICommand? HandleInternal(string input);
}