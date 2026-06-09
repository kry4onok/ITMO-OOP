using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public sealed class FileShowCommandParserLink : CommandParserLinkBase
{
    private readonly IFileSystem _fileSystem;

    public FileShowCommandParserLink(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    protected override ICommand? HandleInternal(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3 || parts[0] != "file" || parts[1] != "show") return null;

        string path = parts[2];
        string? mode = null;

        for (int i = 3; i < parts.Length; i++)
        {
            if (parts[i] == "-m" && i + 1 < parts.Length)
            {
                mode = parts[i + 1];
                i++;
            }
        }

        if (mode is null)
            throw new ArgumentException("file show requires -m Mode parameter");

        return new FileShowCommand(_fileSystem, path, mode);
    }
}
