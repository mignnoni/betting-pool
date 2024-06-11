namespace BettingPool.Application.Users.ForgotPassword;

public sealed record ForgotPasswordResponse(string Email, string Token);
