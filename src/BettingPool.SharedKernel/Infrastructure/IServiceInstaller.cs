using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BettingPool.SharedKernel.Infrastructure;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
