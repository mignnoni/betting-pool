using BettingPool.Infrastructure.DependencyInjection;
using BettingPool.Infrastructure.ServiceInstallers;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.Infrastructure;

public static class ModuleInstaller
{
    public static void AddModule(this IServiceCollection services)
    {
        services.AddDomain();

        services.AddDatabase();

        services.AddApplication();

        services.AddInfrastructure();

        services.AddPersistence();
    }
}
