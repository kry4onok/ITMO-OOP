using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.ProxyProtection;

public interface IFilter
{
    bool FilterPriorety(IMessage message);
}