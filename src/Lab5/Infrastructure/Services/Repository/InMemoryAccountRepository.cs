using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Services.Repository;

public sealed class InMemoryAccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountNumber, Account> _accounts = new();

    public Task Save(Account account)
    {
        _accounts[account.Id] = account;
        return Task.CompletedTask;
    }

    public Task<Account?> GetAccountNumber(AccountNumber accountNumber)
    {
        _accounts.TryGetValue(accountNumber, out Account? account);
        return Task.FromResult(account);
    }

    public Task<bool> ExistsAccount(AccountNumber accountNumber)
    {
        return Task.FromResult(_accounts.ContainsKey(accountNumber));
    }
}