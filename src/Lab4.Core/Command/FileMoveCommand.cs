using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

public sealed class FileMoveCommand : ICommand
{
    private readonly IFileSystem _fileSystem;
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(IFileSystem fileSystem, string sourcePath, string destinationPath)
    {
        _fileSystem = fileSystem;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResult Execute()
    {
        _fileSystem.FileMove(_sourcePath, _destinationPath);
        return new CommandResult.Success();
    }
}
