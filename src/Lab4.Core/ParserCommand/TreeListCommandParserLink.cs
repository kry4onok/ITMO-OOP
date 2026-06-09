using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public sealed class TreeListCommandParserLink : CommandParserLinkBase
{
    private readonly IFileSystem _fileSystem;

    public TreeListCommandParserLink(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    protected override ICommand? HandleInternal(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2 || parts[0] != "tree" || parts[1] != "list") return null;

        int depth = 1;

        for (int i = 2; i < parts.Length; i++)
        {
            if (parts[i] == "-d" && i + 1 < parts.Length && int.TryParse(parts[i + 1], out int parsed))
            {
                depth = parsed;
                i++;
            }
        }

        return new TreeListCommand(_fileSystem, depth);
    }
}
