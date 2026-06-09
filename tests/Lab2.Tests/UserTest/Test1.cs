using Itmo.ObjectOrientedProgramming.Lab2.Clients;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.UserTest;

public class Test1
{
    [Fact]
    public void UserReceiveUnReadMessage()
    {
        var user = new User("Bob");
        var message = new Message(
            "Meeting",
            "Don't forget meeting at 10am",
            new ImportanceLevel.LowImportance());

        user.Receive(message);

        StatusMessage status = user.GetStatus("Meeting");

        Assert.IsType<StatusMessage.Unread>(status);
    }
}