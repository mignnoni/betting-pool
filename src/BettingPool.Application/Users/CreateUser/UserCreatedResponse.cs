namespace BettingPool.Application.Users.CreateUser;

public sealed record UserCreatedResponse(Guid Id, string FullName, string Email);
