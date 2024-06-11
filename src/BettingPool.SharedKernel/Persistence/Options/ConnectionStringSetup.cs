using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BettingPool.SharedKernel.Persistence.Options;

public sealed class ConnectionStringSetup : IConfigureOptions<ConnectionStringOptions>
{
    private const string ConnectionStringName = "projectsDB";
    private readonly IConfiguration _configuration;

    public ConnectionStringSetup(IConfiguration configuration) => _configuration = configuration;

    public void Configure(ConnectionStringOptions options) => options.Value = _configuration.GetConnectionString(ConnectionStringName);
}
