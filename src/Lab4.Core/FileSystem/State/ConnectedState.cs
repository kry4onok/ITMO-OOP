using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

public sealed class ConnectedState : IFileSystemState
{
    private readonly IWriter _writer;

    public PathManager PathManager { get; }

    public OperationFactory Operation { get; }

    public ConnectedState(PathManager pathManager, IWriter writer)
    {
        PathManager = pathManager;
        _writer = writer;
        Operation = new OperationFactory(pathManager);
    }

    public CommandResult Connect(IFileSystem context, string path, string mode) => new CommandResult.Failure();

    public CommandResult Disconnect(IFileSystem context)
    {
        DisconnectOperation operation = Operation.CreateDisconnect();
        operation.Execute();
        context.SetState(new DisconnectedState(_writer));
        return new CommandResult.Success();
    }

    public CommandResult TreeGoto(IFileSystem context, string path)
    {
        TreeGotoOperation operation = Operation.CreateTreeGoto();
        operation.Execute(path);
        return new CommandResult.Success();
    }

    public CommandResult TreeList(IFileSystem context, int depth)
    {
        TreeListOperation operation = Operation.CreateTreeList();
        foreach (string line in operation.Execute(depth))
        {
            _writer.WriteLine(line);
        }

        return new CommandResult.Success();
    }

    public CommandResult FileShow(IFileSystem context, string path, string mode)
    {
        FileShowOperation operation = Operation.CreateFileShow();
        string content = operation.Execute(path, mode);
        _writer.WriteLine(content);
        return new CommandResult.Success();
    }

    public CommandResult FileMove(IFileSystem context, string sourcePath, string destinationPath)
    {
        FileMoveOperation operation = Operation.CreateFileMove();
        operation.Execute(sourcePath, destinationPath);
        return new CommandResult.Success();
    }

    public CommandResult FileCopy(IFileSystem context, string sourcePath, string destinationPath)
    {
        FileCopyOperation operation = Operation.CreateFileCopy();
        operation.Execute(sourcePath, destinationPath);
        return new CommandResult.Success();
    }

    public CommandResult FileDelete(IFileSystem context, string path)
    {
        FileDeleteOperation operation = Operation.CreateFileDelete();
        operation.Execute(path);
        return new CommandResult.Success();
    }

    public CommandResult FileRename(IFileSystem context, string path, string newName)
    {
        FileRenameOperation operation = Operation.CreateFileRename();
        operation.Execute(path, newName);
        return new CommandResult.Success();
    }
}
