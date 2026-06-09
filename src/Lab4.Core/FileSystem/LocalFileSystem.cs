using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public sealed class LocalFileSystem : IFileSystem
{
    private IFileSystemState _state;

    public LocalFileSystem()
    {
        var writer = new ConsoleWriter();
        _state = new DisconnectedState(writer);
    }

    public CommandResult Connect(string path, string mode)
    {
        CommandResult result = _state.Connect(this, path, mode);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public CommandResult Disconnect()
    {
        CommandResult result = _state.Disconnect(this);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public CommandResult TreeGoto(string path)
    {
        CommandResult result = _state.TreeGoto(this, path);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public CommandResult TreeList(int depth)
    {
        CommandResult result = _state.TreeList(this, depth);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public CommandResult FileShow(string path, string mode)
    {
        CommandResult result = _state.FileShow(this, path, mode);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public CommandResult FileMove(string sourcePath, string destinationPath)
    {
        CommandResult result = _state.FileMove(this, sourcePath, destinationPath);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public CommandResult FileCopy(string sourcePath, string destinationPath)
    {
        CommandResult result = _state.FileCopy(this, sourcePath, destinationPath);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public CommandResult FileDelete(string path)
    {
        CommandResult result = _state.FileDelete(this, path);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public CommandResult FileRename(string path, string newName)
    {
        CommandResult result = _state.FileRename(this, path, newName);

        return result.IsFailure ? new CommandResult.Failure() : new CommandResult.Success();
    }

    public void SetState(IFileSystemState state)
    {
        _state = state;
    }
}
