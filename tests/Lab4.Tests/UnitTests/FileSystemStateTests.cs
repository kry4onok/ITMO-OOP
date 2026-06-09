using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Path;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writer;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.UnitTests;

public class FileSystemStateTests
{
    [Fact]
    public void DisconnectedState_Disconnect_ReturnsFailure()
    {
        IWriter writer = Substitute.For<IWriter>();
        var state = new DisconnectedState(writer);
        IFileSystem fileSystem = Substitute.For<IFileSystem>();

        CommandResult result = state.Disconnect(fileSystem);

        Assert.IsType<CommandResult.Failure>(result);
    }

    [Fact]
    public void DisconnectedState_TreeList_ReturnsFailure()
    {
        IWriter writer = Substitute.For<IWriter>();
        var state = new DisconnectedState(writer);
        IFileSystem fileSystem = Substitute.For<IFileSystem>();

        CommandResult result = state.TreeList(fileSystem, 1);

        Assert.IsType<CommandResult.Failure>(result);
    }

    [Fact]
    public void DisconnectedState_TreeGoto_ReturnsFailure()
    {
        IWriter writer = Substitute.For<IWriter>();
        var state = new DisconnectedState(writer);
        IFileSystem fileSystem = Substitute.For<IFileSystem>();

        CommandResult result = state.TreeGoto(fileSystem, "/path");

        Assert.IsType<CommandResult.Failure>(result);
    }

    [Fact]
    public void DisconnectedState_FileShow_ReturnsFailure()
    {
        IWriter writer = Substitute.For<IWriter>();
        var state = new DisconnectedState(writer);
        IFileSystem fileSystem = Substitute.For<IFileSystem>();

        CommandResult result = state.FileShow(fileSystem, "file.txt", "console");

        Assert.IsType<CommandResult.Failure>(result);
    }

    [Fact]
    public void ConnectedState_Disconnect_SwitchesToDisconnectedState()
    {
        IWriter writer = Substitute.For<IWriter>();
        var pathManager = new PathManager();
        var state = new ConnectedState(pathManager, writer);
        IFileSystem fileSystem = Substitute.For<IFileSystem>();

        CommandResult result = state.Disconnect(fileSystem);

        Assert.IsType<CommandResult.Success>(result);
        fileSystem.Received(1).SetState(Arg.Any<DisconnectedState>());
    }

    [Fact]
    public void ConnectedState_Connect_ReturnsFailure()
    {
        IWriter writer = Substitute.For<IWriter>();
        var pathManager = new PathManager();
        var state = new ConnectedState(pathManager, writer);
        IFileSystem fileSystem = Substitute.For<IFileSystem>();

        CommandResult result = state.Connect(fileSystem, "/path", "local");

        Assert.IsType<CommandResult.Failure>(result);
    }
}
