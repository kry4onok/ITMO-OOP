using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Services;

public class CurrencyExchangeService : ICurrencyExchangeService
{
    private readonly Dictionary<string, decimal> _exchangeRates = new()
    {
        { "USD", 1m },
        { "EUR", 0.92m },
        { "RUB", 0.011m },
        { "GBP", 1.27m },
    };

    public Money Convert(Money from, Currency t0)
    {
        if (from.Currency == t0)
            return from;

        decimal rate = GetExchangeRate(from.Currency, t0);
        decimal convertedAmount = from.Amount * rate;

        return new Money(convertedAmount, t0);
    }

    public decimal GetExchangeRate(Currency from, Currency t0)
    {
        if (from == t0)
            return 1m;

        if (!_exchangeRates.TryGetValue(from.Code, out decimal fromRate))
            throw new ArgumentException($"Unknown currency: {from.Code}");

        if (!_exchangeRates.TryGetValue(t0.Code, out decimal toRate))
            throw new ArgumentException($"Unknown currency: {t0.Code}");

        return toRate / fromRate;
    }
}
