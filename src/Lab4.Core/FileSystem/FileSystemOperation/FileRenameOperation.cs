using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class FileRenameOperation
{
    private readonly PathManager _pathManager;

    public FileRenameOperation(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public void Execute(string path, string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("New name cannot be empty.");

        if (newName.Contains(System.IO.Path.DirectorySeparatorChar, StringComparison.Ordinal) ||
            newName.Contains(System.IO.Path.AltDirectorySeparatorChar, StringComparison.Ordinal) ||
            newName.Contains('/', StringComparison.Ordinal) ||
            newName.Contains('\\', StringComparison.Ordinal))
        {
            throw new ArgumentException("New name cannot contain path separators.");
        }

        var pathVO = new PathVO(path);
        PathVO resolvedPath = _pathManager.ResolvePath(pathVO);

        if (!File.Exists(resolvedPath.Value))
            throw new FileNotFoundException($"File not found: {resolvedPath.Value}");

        if (!_pathManager.IsWithinConnection(resolvedPath))
            throw new InvalidOperationException("Cannot operate outside connection path.");

        string dir = System.IO.Path.GetDirectoryName(resolvedPath.Value)
            ?? throw new InvalidOperationException("Cannot determine file directory.");

        string newPath = System.IO.Path.Combine(dir, newName);

        File.Move(resolvedPath.Value, newPath, overwrite: true);
    }
}
