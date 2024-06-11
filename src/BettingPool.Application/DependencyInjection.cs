using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BettingPool.Application;

public static class DependencyInjection
{
    public static void AddApplicationT(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        services
            .AddValidatorsFromAssembly(AssemblyReference.Assembly);
    }
}
