using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Users.ForgotPassword;

public sealed record ForgotPasswordCommand(string Email) : ICommand<ForgotPasswordResponse>;
