using BettingPool.Domain.Users.Abstractions;
using BettingPool.Domain.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.Infrastructure.ServiceInstallers;

internal static class DomainInstaller
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserService, CreateUserService>();
    }
}
