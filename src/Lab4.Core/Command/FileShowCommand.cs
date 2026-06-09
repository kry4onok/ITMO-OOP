using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

public sealed class FileShowCommand : ICommand
{
    private readonly IFileSystem _fileSystem;
    private readonly string _path;
    private readonly string _mode;

    public FileShowCommand(IFileSystem fileSystem, string path, string mode)
    {
        _fileSystem = fileSystem;
        _path = path;
        _mode = mode;
    }

    public CommandResult Execute()
    {
        _fileSystem.FileShow(_path, _mode);
        return new CommandResult.Success();
    }
}
