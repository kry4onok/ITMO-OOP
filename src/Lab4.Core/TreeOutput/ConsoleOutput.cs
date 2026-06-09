using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.TreeOutput;

public sealed class ConsoleOutput
{
    public IEnumerable<string> Render(IEnumerable<ITreeNode> entries)
    {
        return Render(entries, prefix: " ", isLast: true);
    }

    private IEnumerable<string> Render(
        IEnumerable<ITreeNode> entries,
        string prefix,
        bool isLast)
    {
        ITreeNode[] array = entries.ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            bool childIsLast = i == array.Length - 1;
            string branch = childIsLast ? "└── " : "├── ";
            string icon = array[i].IsDirectory ? "📁 " : "📄 ";
            string line = prefix + branch + icon + array[i].Name;

            yield return line;

            if (array[i].IsDirectory)
            {
                string childPrefix = prefix + (childIsLast ? "    " : "│   ");
                foreach (string childLine in Render(array[i].Children, childPrefix, childIsLast))
                    yield return childLine;
            }
        }
    }
}
