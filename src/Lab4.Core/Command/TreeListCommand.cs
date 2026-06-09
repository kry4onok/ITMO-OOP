using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Command;

public sealed class TreeListCommand : ICommand
{
    private readonly IFileSystem _fileSystem;
    private readonly int _depth;

    public TreeListCommand(IFileSystem fileSystem, int depth)
    {
        _fileSystem = fileSystem;
        _depth = depth;
    }

    public CommandResult Execute()
    {
        _fileSystem.TreeList(_depth);
        return new CommandResult.Success();
    }
}
