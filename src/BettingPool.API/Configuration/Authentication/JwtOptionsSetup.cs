using BettingPool.SharedKernel.Infrastructure;
using Microsoft.Extensions.Options;

namespace BettingPool.API.Configuration.Authentication;

public class JwtOptionsSetup(IConfiguration _configuration) : IConfigureOptions<JwtOptions>
{
    private const string SectionName = "Jwt";

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
