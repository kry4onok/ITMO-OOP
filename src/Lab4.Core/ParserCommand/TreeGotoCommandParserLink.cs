using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public sealed class TreeGotoCommandParserLink : CommandParserLinkBase
{
    private readonly IFileSystem _fileSystem;

    public TreeGotoCommandParserLink(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    protected override ICommand? HandleInternal(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3 || parts[0] != "tree" || parts[1] != "goto") return null;

        string path = parts[2];

        return new TreeGotoCommand(_fileSystem, path);
    }
}
