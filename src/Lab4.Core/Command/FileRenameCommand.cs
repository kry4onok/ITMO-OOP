using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

public sealed class FileRenameCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _path;

    private readonly string _newName;

    public FileRenameCommand(IFileSystem fileSystem, string path, string newName)
    {
        _fileSystem = fileSystem;
        _path = path;
        _newName = newName;
    }

    public CommandResult Execute()
    {
        _fileSystem.FileRename(_path, _newName);
        return new CommandResult.Success();
    }
}