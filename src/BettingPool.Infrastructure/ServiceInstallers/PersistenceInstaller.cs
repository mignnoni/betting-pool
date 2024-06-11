using BettingPool.Domain.Championships.Abstractions;
using BettingPool.Persistence;
using BettingPool.Persistence.Repositories;
using BettingPool.SharedKernel.Domain;
using BettingPool.SharedKernel.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.Infrastructure.ServiceInstallers;

internal static class PersistenceInstaller
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
