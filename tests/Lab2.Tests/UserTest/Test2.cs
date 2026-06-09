using Itmo.ObjectOrientedProgramming.Lab2.Clients;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.UserTest;

public class Test2
{
    [Fact]
    public void UserNotesMessageRead()
    {
        var user = new User("Makson");
        var message = new Message(
            "Platinum Concert",
            "Concert will be 18.03 in 21:00pm!",
            new ImportanceLevel.NormalImportance());

        user.Receive(message);

        ResultStatusMessage result = user.MarkTheMessage("Platinum Concert");

        Assert.IsType<ResultStatusMessage.MarkAsRead>(result);

        StatusMessage status = user.GetStatus("Platinum Concert");

        Assert.IsType<StatusMessage.Read>(status);
    }
}