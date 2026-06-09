using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class TreeGotoOperation
{
    private readonly PathManager _pathManager;

    public TreeGotoOperation(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public void Execute(string path)
    {
        var pathVo = new PathVO(path);
        PathVO resolvedPath = _pathManager.ResolvePath(pathVo);

        if (!Directory.Exists(resolvedPath.Value))
            throw new DirectoryNotFoundException($"Directory not found: {resolvedPath.Value}");

        if (!_pathManager.IsWithinConnection(resolvedPath))
            throw new InvalidOperationException("Cannot navigate outside connection path.");

        _pathManager.SetCurrentLocalPath(resolvedPath);
    }
}
