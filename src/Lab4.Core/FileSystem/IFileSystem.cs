using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    CommandResult Connect(string path, string mode);

    CommandResult Disconnect();

    CommandResult TreeGoto(string path);

    CommandResult TreeList(int depth);

    CommandResult FileShow(string path, string mode);

    CommandResult FileMove(string sourcePath, string destinationPath);

    CommandResult FileDelete(string path);

    CommandResult FileCopy(string sourcePath, string destinationPath);

    CommandResult FileRename(string path, string newName);

    void SetState(IFileSystemState state);
}
