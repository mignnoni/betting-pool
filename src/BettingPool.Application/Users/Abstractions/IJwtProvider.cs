using System.Security.Claims;

namespace BettingPool.Application.Users.Abstractions;

public interface IJwtProvider
{
    string Generate(List<Claim> claims, List<string> roles);
}
