namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Tree;

public class DirectoryNode : ITreeNode
{
    public string Name { get; }

    public bool IsDirectory { get; } = true;

    public IEnumerable<ITreeNode> Children { get; }

    public DirectoryNode(string name, IEnumerable<ITreeNode> children)
    {
        Name = name;
        Children = children;
    }
}