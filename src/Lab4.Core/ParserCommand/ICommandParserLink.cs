using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public interface ICommandParserLink
{
    ICommand? Handle(string input);
}
