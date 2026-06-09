using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

public sealed class ConnectCommand : ICommand
{
    private readonly IFileSystem _fileSystem;
    private readonly string _path;
    private readonly string _mode;

    public ConnectCommand(IFileSystem fileSystem, string path, string mode)
    {
        _fileSystem = fileSystem;
        _path = path;
        _mode = mode;
    }

    public CommandResult Execute()
    {
        if (_mode is not "local")
        {
            return new CommandResult.Failure();
        }

        _fileSystem.Connect(_path, _mode);
        return new CommandResult.Success();
    }
}
