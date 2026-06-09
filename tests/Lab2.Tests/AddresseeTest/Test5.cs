using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Addressees.Decorator;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.AddresseeTest;

public class Test5
{
    [Fact]

    public void LoggingAddresseeShouldLogMessageWhenReceiveCalled()
    {
        IAddressee addresseeMock = Substitute.For<IAddressee>();

        ILogging loggerMock = Substitute.For<ILogging>();

        var addresseeLoging = new AddresseeLogging(addresseeMock, loggerMock);

        var message = new Message(
            "Valek is not productive",
            "He's not bothering with anything",
            new ImportanceLevel.LowImportance());

        addresseeLoging.Receive(message);

        loggerMock.Received(1).Log(message);

        addresseeMock.Received(1).Receive(message);
    }
}