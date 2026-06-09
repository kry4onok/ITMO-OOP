using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Runner;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.UnitTests;

public class ApplicationRunnerTests
{
    [Fact]
    public void Run_ValidCommand_ExecutesSuccessfully()
    {
        ICommandParserService parser = Substitute.For<ICommandParserService>();
        ICommand command = Substitute.For<ICommand>();
        command.Execute().Returns(new CommandResult.Success());
        parser.Parse("test").Returns(command);

        var runner = new ApplicationRunner(parser);

        Assert.NotNull(runner);
    }
}
