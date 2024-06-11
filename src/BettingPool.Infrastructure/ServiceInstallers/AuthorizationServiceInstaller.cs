using BettingPool.Infrastructure.Services.Permission;
using BettingPool.SharedKernel.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.Infrastructure.ServiceInstallers;

public static class AuthorizationServiceInstaller
{
    public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
    {
        services
            .AddAuthorization()
            .AddScoped<IPermissionService, PermissionService>()
            .AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>()
            .AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        return services;
    }
}
