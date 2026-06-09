using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public interface ICommandParserService
{
    ICommand Parse(string input);
}
