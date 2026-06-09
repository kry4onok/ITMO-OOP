using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.FilterSuspiciousWords;

public class FilterMessageNotification : IFilterMessageNotification
{
    private readonly List<string> _forbiddenWords;

    public FilterMessageNotification(IEnumerable<string> forbiddenWords)
    {
        _forbiddenWords = new List<string>(forbiddenWords);
    }

    public bool CheckSuspicious(IMessage message)
    {
        foreach (string forbbidenWord in _forbiddenWords)
        {
            if (message.Body.Contains(forbbidenWord, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}