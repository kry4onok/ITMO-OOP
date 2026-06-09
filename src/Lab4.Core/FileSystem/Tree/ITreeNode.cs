namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Tree;

public interface ITreeNode
{
    string Name { get; }

    bool IsDirectory { get; }

    IEnumerable<ITreeNode> Children { get; }
}