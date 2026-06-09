using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class DisconnectOperation
{
    private readonly PathManager _pathManager;

    public DisconnectOperation(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public void Execute()
    {
        _pathManager.ClearPaths();
    }
}
