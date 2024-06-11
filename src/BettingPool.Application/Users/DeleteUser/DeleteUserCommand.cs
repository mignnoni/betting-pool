using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Users.DeleteUser;

public sealed record DeleteUserCommand(string Id) : ICommand;
