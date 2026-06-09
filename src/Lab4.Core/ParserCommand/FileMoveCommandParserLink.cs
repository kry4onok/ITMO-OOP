using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public sealed class FileMoveCommandParserLink : CommandParserLinkBase
{
    private readonly IFileSystem _fileSystem;

    public FileMoveCommandParserLink(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    protected override ICommand? HandleInternal(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "move") return null;

        string sourcePath = parts[2];
        string destinationPath = parts[3];

        return new FileMoveCommand(_fileSystem, sourcePath, destinationPath);
    }
}
