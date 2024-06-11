using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Users.Login
{
    public sealed record LoginCommand(
        string Email, 
        string Password) : ICommand<LoginResponse>;
}
