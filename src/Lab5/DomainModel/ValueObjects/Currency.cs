using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

public sealed record Currency
{
    private Currency(string code)
    {
        Code = code;
    }

    public string Code { get; }

    public static Currency Usd { get; } = new("USD");

    public static Currency Eur { get; } = new("EUR");

    public static Currency Rub { get; } = new("RUB");

    public static Currency Gbp { get; } = new("GBP");

    public static HandlerResult<Currency> FromCode(string code)
    {
        return code switch
        {
            "USD" => new HandlerResult<Currency>.SuccessfulOperation(Usd),
            "EUR" => new HandlerResult<Currency>.SuccessfulOperation(Eur),
            "RUB" => new HandlerResult<Currency>.SuccessfulOperation(Rub),
            "GBP" => new HandlerResult<Currency>.SuccessfulOperation(Gbp),
            _ => new HandlerResult<Currency>.FailedOperation($"Unknown currency: {code}"),
        };
    }

    public override string ToString()
    {
        return Code;
    }
}