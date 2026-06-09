using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;

public interface ICurrencyExchangeService
{
    Money Convert(Money from, Currency t0);

    decimal GetExchangeRate(Currency from, Currency t0);
}