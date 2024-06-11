using BettingPool.Domain.Users;
using BettingPool.Persistence;
using BettingPool.Persistence.Constants;
using BettingPool.SharedKernel.Persistence.Extensions;
using BettingPool.SharedKernel.Persistence.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.Infrastructure.ServiceInstallers;

internal static class DatabaseInstaller
{
    public static void AddDatabase(this IServiceCollection services)
    {
        services
            .AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                ConnectionStringOptions connectionString = serviceProvider.GetService<IOptions<ConnectionStringOptions>>()!.Value;

                options
                    .UseNpgsql(
                        connectionString,
                        dbContextOptionsBuilder => dbContextOptionsBuilder.WithMigrationHistoryTableInSchema(Schemas.Dbo));
            });


        services.AddIdentity<User, IdentityRole<Guid>>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 8;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders()
        .AddRoles<IdentityRole<Guid>>();

        services
            .AddMemoryCache()
            .ConfigureOptions<ConnectionStringSetup>();

    }
}
