using System.Security.Claims;

namespace BettingPool.Infrastructure.Authentication
{
    public static class JwtExtensions
    {
        public static void AddRoles(this List<Claim> claims, IEnumerable<string> roles)
        {
            if (roles != null && roles.Any())
            {
                claims.AddRange(roles.Select(s => new Claim(ClaimTypes.Role, s)));
            }
        }
    }
}
