using Ardalis.Result;
using BettingPool.SharedKernel.Application;
using Microsoft.AspNetCore.Identity;

namespace BettingPool.Application.Users.Permissions.GetRolePermissions;

internal sealed class GetRolePermissionsQueryHandler(RoleManager<IdentityRole<Guid>> roleManager) : IQueryHandler<GetRolePermissionsQuery, HashSet<string>>
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager = roleManager;
    public async Task<Result<HashSet<string>>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByNameAsync(request.Role);

        if (role == null)
        {
            return new HashSet<string>();
        }

        var claims = await _roleManager.GetClaimsAsync(role);

        if (claims == null)
        {
            return new HashSet<string>();
        }

        return claims.Select(x => x.Value).ToHashSet();
    }
}
