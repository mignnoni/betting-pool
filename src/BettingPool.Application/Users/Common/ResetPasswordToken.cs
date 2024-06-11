namespace BettingPool.Application.Users.Common;

public sealed record ResetPasswordToken(
    string Token,
    string Email);
