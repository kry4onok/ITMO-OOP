using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Authentication;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Configuration;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Services;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Services.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AdminSettings? adminSettings = configuration.GetSection("AdminSettings").Get<AdminSettings>();
        services.AddSingleton(adminSettings ?? new AdminSettings());

        services.AddScoped<IAdminPasswordValidator, AdminPasswordValidator>();
        services.AddScoped<IPinHash, Sha256PinHasher>();

        services.AddSingleton<IAccountRepository, InMemoryAccountRepository>();
        services.AddSingleton<ISessionRepository, InMemorySessionRepository>();

        return services;
    }
}
