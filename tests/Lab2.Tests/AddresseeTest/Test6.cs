using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters.Writers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.AddresseeTest;

public class Test6
{
    [Fact]
    public void Message_ShouldBeFormattedAndArchived()
    {
        IMessageFormatter formatter = Substitute.For<IMessageFormatter>();
        IMessageWriter writer = Substitute.For<IMessageWriter>();

        var archiver = new FormattingArchiver(formatter, writer);

        var message = new Message(
            "Meeting",
            "Don't forget the meeting at 10am",
            new ImportanceLevel.NormalImportance());

        archiver.Archive(message);

        formatter.Received(1).Format(message);
        writer.Received(1).Write(Arg.Any<string>());
    }
}