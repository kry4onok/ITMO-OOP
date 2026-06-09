using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public sealed class DisconnectCommandParserLink : CommandParserLinkBase
{
    private readonly IFileSystem _fileSystem;

    public DisconnectCommandParserLink(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    protected override ICommand? HandleInternal(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 1 || parts[0] != "disconnect") return null;

        return new DisconnectCommand(_fileSystem);
    }
}
