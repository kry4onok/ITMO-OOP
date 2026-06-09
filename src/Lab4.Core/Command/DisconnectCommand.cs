using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

public sealed class DisconnectCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    public DisconnectCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public CommandResult Execute()
    {
        _fileSystem.Disconnect();

        return new CommandResult.Success();
    }
}
