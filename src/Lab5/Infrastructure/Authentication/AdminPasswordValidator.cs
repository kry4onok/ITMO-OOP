using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Authentication;

public sealed class AdminPasswordValidator : IAdminPasswordValidator
{
    private readonly AdminSettings _adminSettings;

    public AdminPasswordValidator(AdminSettings adminSettings)
    {
        _adminSettings = adminSettings;
    }

    public ValueTask<bool> ValidateAsync(string password)
    {
        bool isValid = _adminSettings.Password == password;
        return ValueTask.FromResult(isValid);
    }
}