using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class FileCopyOperation
{
    private readonly PathManager _pathManager;

    public FileCopyOperation(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public void Execute(string sourcePath, string destinationPath)
    {
        var sourceVO = new PathVO(sourcePath);
        var destVO = new PathVO(destinationPath);

        PathVO resolvedSource = _pathManager.ResolvePath(sourceVO);
        PathVO resolvedDest = _pathManager.ResolvePath(destVO);

        if (!File.Exists(resolvedSource.Value))
            throw new FileNotFoundException($"Source file not found: {resolvedSource.Value}");

        if (!Directory.Exists(resolvedDest.Value))
            throw new DirectoryNotFoundException($"Destination directory not found: {resolvedDest.Value}");

        if (!_pathManager.IsWithinConnection(resolvedSource) ||
            !_pathManager.IsWithinConnection(resolvedDest))
        {
            throw new InvalidOperationException("Cannot operate outside connection path.");
        }

        string fileName = System.IO.Path.GetFileName(resolvedSource.Value);
        string finalDest = System.IO.Path.Combine(resolvedDest.Value, fileName);

        File.Copy(resolvedSource.Value, finalDest);
    }
}
