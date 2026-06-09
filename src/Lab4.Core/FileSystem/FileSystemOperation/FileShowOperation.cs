using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class FileShowOperation
{
    private readonly PathManager _pathManager;

    public FileShowOperation(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public string Execute(string path, string mode)
    {
        if (mode != "console")
            throw new ArgumentException($"Unknown mode: {mode}. Only 'console' is supported.");

        var pathVO = new PathVO(path);
        PathVO resolvedPath = _pathManager.ResolvePath(pathVO);

        if (!File.Exists(resolvedPath.Value))
            throw new FileNotFoundException($"File not found: {resolvedPath.Value}");

        if (!_pathManager.IsWithinConnection(resolvedPath))
            throw new InvalidOperationException("Cannot access file outside connection path.");

        return File.ReadAllText(resolvedPath.Value);
    }
}
