using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;
using Itmo.ObjectOrientedProgramming.Lab4.Core.TreeOutput;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class TreeListOperation
{
    private readonly PathManager _pathManager;

    public TreeListOperation(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public IEnumerable<string> Execute(int depth)
    {
        if (_pathManager.CurrentLocalPath is null)
            throw new InvalidOperationException("Not connected.");

        if (depth <= 0)
            yield break;

        var renderer = new ConsoleOutput();
        foreach (string line in renderer.Render(GetTreeNodes(_pathManager.CurrentLocalPath.Value, depth)))
        {
            yield return line;
        }
    }

    private IEnumerable<ITreeNode> GetTreeNodes(string dirPath, int remainingDepth)
    {
        if (remainingDepth <= 0)
            yield break;

        foreach (string dir in Directory.EnumerateDirectories(dirPath))
        {
            string dirName = System.IO.Path.GetFileName(dir);
            yield return new DirectoryNode(dirName, GetTreeNodes(dir, remainingDepth - 1));
        }

        foreach (string file in Directory.EnumerateFiles(dirPath))
        {
            string fileName = System.IO.Path.GetFileName(file);
            yield return new FileNode(fileName);
        }
    }
}
