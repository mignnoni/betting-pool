using BettingPool.SharedKernel.Persistence.Options;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.SharedKernel.Persistence;

public static class PersistenceServiceInstaller
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services
            .AddMemoryCache()
            .ConfigureOptions<ConnectionStringSetup>();
    }
}
