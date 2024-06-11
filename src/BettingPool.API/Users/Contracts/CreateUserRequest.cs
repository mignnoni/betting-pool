namespace BettingPool.API.Users.Contracts;

public sealed record CreateUserRequest(
    string FullName, 
    string Email, 
    string Password,
    string ConfirmPassword);