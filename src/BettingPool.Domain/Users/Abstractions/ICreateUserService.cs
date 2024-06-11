using Ardalis.Result;

namespace BettingPool.Domain.Users.Abstractions;

public interface ICreateUserService
{
    Task<Result<Guid>> CreateUser(string fullName, string email, string password, string role);
}
