using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class ConnectOperation
{
    private readonly PathManager _pathManager;

    public ConnectOperation(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public void Execute(string path, string mode)
    {
        if (mode != "local")
            throw new ArgumentException($"Unknown mode: {mode}. Only 'local' is supported.");

        var pathVo = new PathVO(path);

        if (!pathVo.IsAbsolute)
            throw new ArgumentException("Connection path must be absolute.");

        if (!Directory.Exists(pathVo.Value))
            throw new DirectoryNotFoundException($"Path does not exist: {pathVo.Value}");

        _pathManager.SetConnectionPath(pathVo);
    }
}
