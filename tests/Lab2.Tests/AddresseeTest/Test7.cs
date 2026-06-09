using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Addressees.ProxyProtection;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Topics;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.AddresseeTest;

public class Test7
{
    [Fact]
    public void FilteredAddressee_ShouldReceiveMessageOnlyOnce()
    {
        IAddressee user1 = Substitute.For<IAddressee>();
        IAddressee user2 = Substitute.For<IAddressee>();

        IFilter filterAddressee = new Filter(new ImportanceLevel.NormalImportance());

        var filteredUser2 = new AddresseeFilter(user2, filterAddressee);

        var addressees = new List<IAddressee> { user1, filteredUser2 };

        var topic = new Topic("General", addressees);

        var lowImportanceMessage = new Message(
            "Low priority",
            "This is a low priority message",
            new ImportanceLevel.LowImportance());

        var normalImportanceMessage = new Message(
            "Normal priority",
            "This is a normal message",
            new ImportanceLevel.NormalImportance());

        topic.Send(lowImportanceMessage);
        topic.Send(normalImportanceMessage);

        user1.Received(2).Receive(Arg.Any<IMessage>());
        user2.Received(1).Receive(normalImportanceMessage);
    }
}