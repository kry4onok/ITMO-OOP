using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

public sealed class TreeGotoCommand : ICommand
{
    private readonly IFileSystem _fileSystem;
    private readonly string _path;

    public TreeGotoCommand(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        _path = path;
    }

    public CommandResult Execute()
    {
        _fileSystem.TreeGoto(_path);
        return new CommandResult.Success();
    }
}