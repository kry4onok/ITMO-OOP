using Itmo.ObjectOrientedProgramming.Lab2.Clients;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.UserTest;

public class Test3
{
    [Fact]
    public void UserNotesMessageAlreadyRead()
    {
        var user = new User("Sanek");
        var message = new Message(
            "Radiohead Concert",
            "Concert will be 28.07 in 23:30pm!",
            new ImportanceLevel.NormalImportance());

        user.Receive(message);

        ResultStatusMessage result1 = user.MarkTheMessage("Radiohead Concert");

        Assert.IsType<ResultStatusMessage.MarkAsRead>(result1);

        ResultStatusMessage result2 = user.MarkTheMessage("Radiohead Concert");

        Assert.IsType<ResultStatusMessage.AlreadyMarkAsRead>(result2);
    }
}