using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;

public sealed class OperationFactory
{
    private readonly PathManager _pathManager;

    public OperationFactory(PathManager pathManager)
    {
        _pathManager = pathManager;
    }

    public ConnectOperation CreateConnect() => new ConnectOperation(_pathManager);

    public DisconnectOperation CreateDisconnect() => new DisconnectOperation(_pathManager);

    public TreeGotoOperation CreateTreeGoto() => new TreeGotoOperation(_pathManager);

    public TreeListOperation CreateTreeList() => new TreeListOperation(_pathManager);

    public FileShowOperation CreateFileShow() => new FileShowOperation(_pathManager);

    public FileMoveOperation CreateFileMove() => new FileMoveOperation(_pathManager);

    public FileCopyOperation CreateFileCopy() => new FileCopyOperation(_pathManager);

    public FileDeleteOperation CreateFileDelete() => new FileDeleteOperation(_pathManager);

    public FileRenameOperation CreateFileRename() => new FileRenameOperation(_pathManager);
}
