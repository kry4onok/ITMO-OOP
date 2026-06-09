using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class FileDeleteOperation
{
    private readonly PathManager _pathManager;

    public FileDeleteOperation(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public void Execute(string path)
    {
        var pathVO = new PathVO(path);
        PathVO resolvedPath = _pathManager.ResolvePath(pathVO);

        if (!File.Exists(resolvedPath.Value))
            throw new FileNotFoundException($"File not found: {resolvedPath.Value}");

        if (!_pathManager.IsWithinConnection(resolvedPath))
            throw new InvalidOperationException("Cannot operate outside connection path.");

        File.Delete(resolvedPath.Value);
    }
}
