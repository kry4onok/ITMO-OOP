using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.FilterSuspiciousWords;

public interface IFilterMessageNotification
{
    bool CheckSuspicious(IMessage message);
}