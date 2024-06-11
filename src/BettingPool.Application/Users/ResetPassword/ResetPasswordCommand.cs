using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Users.ResetPassword;

public sealed record ResetPasswordCommand(
    string Email,
    string Token,
    string NewPassword,
    string ConfirmNewPassword) : ICommand;
