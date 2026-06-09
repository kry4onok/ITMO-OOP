using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;

public interface IAccountRepository
{
    Task Save(Account account);

    Task<Account?> GetAccountNumber(AccountNumber accountNumber);

    Task<bool> ExistsAccount(AccountNumber accountNumber);
}