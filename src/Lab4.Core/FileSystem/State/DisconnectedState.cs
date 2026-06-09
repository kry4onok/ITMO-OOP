using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.FileSystemOperation;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;

public sealed class DisconnectedState : IFileSystemState
{
    public PathManager PathManager { get; } = new PathManager();

    public OperationFactory Operation { get; }

    private readonly IWriter _writer;

    public DisconnectedState(IWriter writer)
    {
        Operation = new OperationFactory(PathManager);

        _writer = writer;
    }

    public CommandResult Connect(IFileSystem context, string path, string mode)
    {
        if (mode is not "local")
        {
            return new CommandResult.Failure();
        }

        ConnectOperation operation = Operation.CreateConnect();
        operation.Execute(path, mode);
        context.SetState(new ConnectedState(PathManager, _writer));
        return new CommandResult.Success();
    }

    public CommandResult Disconnect(IFileSystem context)
    {
        return new CommandResult.Failure();
    }

    public CommandResult TreeGoto(IFileSystem context, string path)
    {
        return new CommandResult.Failure();
    }

    public CommandResult TreeList(IFileSystem context, int depth)
    {
        return new CommandResult.Failure();
    }

    public CommandResult FileShow(IFileSystem context, string path, string mode)
    {
        return new CommandResult.Failure();
    }

    public CommandResult FileMove(IFileSystem context, string sourcePath, string destinationPath)
    {
        return new CommandResult.Failure();
    }

    public CommandResult FileCopy(IFileSystem context, string sourcePath, string destinationPath)
    {
        return new CommandResult.Failure();
    }

    public CommandResult FileDelete(IFileSystem context, string path)
    {
        return new CommandResult.Failure();
    }

    public CommandResult FileRename(IFileSystem context, string path, string newName)
    {
        return new CommandResult.Failure();
    }
}
