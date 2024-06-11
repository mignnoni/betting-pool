namespace BettingPool.API.Users.Contracts;

public sealed record LoginRequest(
    string Email, 
    string Password);
