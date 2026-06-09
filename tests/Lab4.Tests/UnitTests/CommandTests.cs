using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.UnitTests;

public class CommandTests
{
    [Fact]
    public void ConnectCommand_Execute_CallsFileSystemConnect()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new ConnectCommand(fileSystem, "/path", "local");

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).Connect("/path", "local");
    }

    [Fact]
    public void DisconnectCommand_Execute_CallsFileSystemDisconnect()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new DisconnectCommand(fileSystem);

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).Disconnect();
    }

    [Fact]
    public void TreeListCommand_Execute_CallsFileSystemTreeList()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new TreeListCommand(fileSystem, 2);

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).TreeList(2);
    }

    [Fact]
    public void TreeGotoCommand_Execute_CallsFileSystemTreeGoto()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new TreeGotoCommand(fileSystem, "/home");

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).TreeGoto("/home");
    }

    [Fact]
    public void FileShowCommand_Execute_CallsFileSystemFileShow()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new FileShowCommand(fileSystem, "file.txt", "console");

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).FileShow("file.txt", "console");
    }

    [Fact]
    public void FileCopyCommand_Execute_CallsFileSystemFileCopy()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new FileCopyCommand(fileSystem, "src.txt", "dst.txt");

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).FileCopy("src.txt", "dst.txt");
    }

    [Fact]
    public void FileMoveCommand_Execute_CallsFileSystemFileMove()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new FileMoveCommand(fileSystem, "src.txt", "dst.txt");

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).FileMove("src.txt", "dst.txt");
    }

    [Fact]
    public void FileDeleteCommand_Execute_CallsFileSystemFileDelete()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new FileDeleteCommand(fileSystem, "file.txt");

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).FileDelete("file.txt");
    }

    [Fact]
    public void FileRenameCommand_Execute_CallsFileSystemFileRename()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var command = new FileRenameCommand(fileSystem, "old.txt", "new.txt");

        CommandResult result = command.Execute();

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).FileRename("old.txt", "new.txt");
    }
}
