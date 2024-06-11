namespace BettingPool.API.Users.Contracts;

public sealed record ResetPasswordRequest(
    string Email,
    string Token,
    string Password,
    string ConfirmPassword);