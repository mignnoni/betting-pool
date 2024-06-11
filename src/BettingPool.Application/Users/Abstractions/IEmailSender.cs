namespace BettingPool.Application.Users.Abstractions;

public interface IEmailSender
{
    Task SendTokenToResetPassword(string name, string email, string token, CancellationToken cancellationToken = default);
    Task PasswordReseted(string name, string email, CancellationToken cancellationToken = default);
}
