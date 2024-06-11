using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BettingPool.Infrastructure.Services.Email;

public class EmailSenderOptionsSetup(
    IConfiguration _configuration) : IConfigureOptions<EmailSenderOptions>
{
    private const string SectionName = "EmailOptions";
    public void Configure(EmailSenderOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}

public class EmailSenderOptions
{
    public string FromName { get; set; }
    public string FromEmail { get; set; }
    public string ApiKey { get; set; }
}
