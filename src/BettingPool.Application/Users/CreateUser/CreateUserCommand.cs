using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Users.CreateUser;

public sealed record CreateUserCommand(
    string FullName, 
    string Email, 
    string Password,
    string ConfirmPassword) : ICommand<UserCreatedResponse>;
