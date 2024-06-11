using BettingPool.Application.Users.Abstractions;
using BettingPool.Infrastructure.Authentication;
using BettingPool.Infrastructure.Services.Email;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.Infrastructure.ServiceInstallers;

internal static class InfrastructureInstaller
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();

        services.AddScoped<IJwtProvider, JwtProvider>();

        services.AddAuthorizationService();

        services.ConfigureOptions<EmailSenderOptionsSetup>();
    }
}
