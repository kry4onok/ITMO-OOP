using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.ProxyProtection;

public class Filter : IFilter
{
    private readonly ImportanceLevel _minImportance;

    public Filter(ImportanceLevel minImportance)
    {
        _minImportance = minImportance;
    }

    public bool FilterPriorety(IMessage message)
    {
        return message.Importance.Priorety >= _minImportance.Priorety;
    }
}