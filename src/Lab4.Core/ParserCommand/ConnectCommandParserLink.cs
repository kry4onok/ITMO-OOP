using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public sealed class ConnectCommandParserLink : CommandParserLinkBase
{
    private readonly IFileSystem _fileSystem;

    public ConnectCommandParserLink(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    protected override ICommand? HandleInternal(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0 || parts[0] != "connect") return null;

        if (parts.Length < 2)
            throw new ArgumentException("connect requires Address");

        string path = parts[1];
        string mode = "local";

        for (int i = 2; i < parts.Length; i++)
        {
            if (parts[i] == "-m" && i + 1 < parts.Length)
            {
                mode = parts[i + 1];
                i++;
            }
        }

        return new ConnectCommand(_fileSystem, path, mode);
    }
}
