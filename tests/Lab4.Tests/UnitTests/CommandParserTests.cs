using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.UnitTests;

public class CommandParserTests
{
    [Fact]
    public void Parse_ConnectCommand_ReturnsConnectCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("connect /path -m local");

        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void Parse_DisconnectCommand_ReturnsDisconnectCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("disconnect");

        Assert.IsType<DisconnectCommand>(command);
    }

    [Fact]
    public void Parse_TreeListCommand_ReturnsTreeListCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("tree list -d 2");

        Assert.IsType<TreeListCommand>(command);
    }

    [Fact]
    public void Parse_TreeListCommand_WithDefaultDepth_ReturnsTreeListCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("tree list");

        Assert.IsType<TreeListCommand>(command);
    }

    [Fact]
    public void Parse_TreeGotoCommand_ReturnsTreeGotoCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("tree goto /home");

        Assert.IsType<TreeGotoCommand>(command);
    }

    [Fact]
    public void Parse_FileShowCommand_ReturnsFileShowCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("file show file.txt -m console");

        Assert.IsType<FileShowCommand>(command);
    }

    [Fact]
    public void Parse_FileCopyCommand_ReturnsFileCopyCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("file copy src.txt dst.txt");

        Assert.IsType<FileCopyCommand>(command);
    }

    [Fact]
    public void Parse_FileMoveCommand_ReturnsFileMoveCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("file move src.txt dst.txt");

        Assert.IsType<FileMoveCommand>(command);
    }

    [Fact]
    public void Parse_FileDeleteCommand_ReturnsFileDeleteCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("file delete file.txt");

        Assert.IsType<FileDeleteCommand>(command);
    }

    [Fact]
    public void Parse_FileRenameCommand_ReturnsFileRenameCommand()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        ICommand command = parser.Parse("file rename old.txt new.txt");

        Assert.IsType<FileRenameCommand>(command);
    }

    [Fact]
    public void Parse_UnknownCommand_ThrowsArgumentException()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        Assert.Throws<ArgumentException>(() => parser.Parse("unknown command"));
    }

    [Fact]
    public void Parse_ConnectWithoutPath_ThrowsArgumentException()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        Assert.Throws<ArgumentException>(() => parser.Parse("connect"));
    }

    [Fact]
    public void Parse_TreeGotoWithoutPath_ThrowsArgumentException()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        Assert.Throws<ArgumentException>(() => parser.Parse("tree goto"));
    }

    [Fact]
    public void Parse_FileShowWithoutPath_ThrowsArgumentException()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        Assert.Throws<ArgumentException>(() => parser.Parse("file show"));
    }

    [Fact]
    public void Parse_FileCopyWithoutDestination_ThrowsArgumentException()
    {
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var parser = new CommandParserService(fileSystem);

        Assert.Throws<ArgumentException>(() => parser.Parse("file copy src.txt"));
    }
}
