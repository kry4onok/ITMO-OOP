using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

public sealed class FileDeleteCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _path;

    public FileDeleteCommand(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;

        _path = path;
    }

    public CommandResult Execute()
    {
        _fileSystem.FileDelete(_path);
        return new CommandResult.Success();
    }
}