using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

public interface IFileSystemState
{
    PathManager PathManager { get; }

    OperationFactory Operation { get; }

    CommandResult Connect(IFileSystem context, string path, string mode);

    CommandResult Disconnect(IFileSystem context);

    CommandResult TreeGoto(IFileSystem context, string path);

    CommandResult TreeList(IFileSystem context, int depth);

    CommandResult FileShow(IFileSystem context, string path, string mode);

    CommandResult FileMove(IFileSystem context, string sourcePath, string destinationPath);

    CommandResult FileCopy(IFileSystem context, string sourcePath, string destinationPath);

    CommandResult FileDelete(IFileSystem context, string path);

    CommandResult FileRename(IFileSystem context, string path, string newName);
}
