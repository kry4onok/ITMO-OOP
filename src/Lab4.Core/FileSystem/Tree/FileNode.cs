namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Tree;

public class FileNode : ITreeNode
{
    public string Name { get; }

    public bool IsDirectory { get; } = false;

    public IEnumerable<ITreeNode> Children => Enumerable.Empty<ITreeNode>();

    public FileNode(string name)
    {
        Name = name;
    }
}