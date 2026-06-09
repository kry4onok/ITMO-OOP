using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Addressees.ProxyProtection;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.AddresseeTest;

public class Test4
{
    [Fact]

    public void MessageBelowImportanceShouldNotReachAddressee()
    {
        IAddressee addresseeMock = Substitute.For<IAddressee>();
        var filterLogic = new Filter(new ImportanceLevel.HighImportance());
        var filterAddressee = new AddresseeFilter(addresseeMock, filterLogic);

        var lowMessage = new Message(
            "Low importance message",
            "Low body message",
            new ImportanceLevel.LowImportance());

        filterAddressee.Receive(lowMessage);

        addresseeMock.DidNotReceive().Receive(Arg.Any<IMessage>());
    }
}