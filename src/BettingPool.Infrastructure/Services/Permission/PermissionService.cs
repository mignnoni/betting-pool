using BettingPool.SharedKernel.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace BettingPool.Infrastructure.Services.Permission;

internal sealed class PermissionService(
    IMemoryCache memoryCache,
    RoleManager<IdentityRole<Guid>> _roleManager) : IPermissionService
{
    private readonly IMemoryCache _memoryCache = memoryCache;

#pragma warning disable CS8603 // Possível retorno de referência nula.
    public async Task<HashSet<string>> GetPermissionsByRoleAsync(string role, CancellationToken cancellationToken = default) =>
        await _memoryCache.GetOrCreateAsync(
            CreateCacheKey(role),
            async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);

                var permissions = await GetPermissionsByRoleInternalAsync(role, cancellationToken);

                if (permissions is null)
                    return [];

                return permissions;
            });
#pragma warning restore CS8603 // Possível retorno de referência nula.

    private static string CreateCacheKey(string role) => $"permissions_{role}";

    private async Task<HashSet<string>> GetPermissionsByRoleInternalAsync(string roleName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            return [];
        }

        var role = await _roleManager.FindByNameAsync(roleName);

        if (role == null)
        {
            return [];
        }

        var claims = await _roleManager.GetClaimsAsync(role);

        if (claims == null)
        {
            return [];
        }

        return claims.Select(x => x.Value).ToHashSet();
    }

}
