namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;

public interface IAdminPasswordValidator
{
    ValueTask<bool> ValidateAsync(string password);
}