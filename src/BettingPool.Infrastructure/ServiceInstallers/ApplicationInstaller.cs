using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.Infrastructure.DependencyInjection;

internal static class ApplicationInstaller
{
    public static void AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

        services
            .AddValidatorsFromAssembly(Application.AssemblyReference.Assembly);
    }
}
