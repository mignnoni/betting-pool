using Microsoft.AspNetCore.Authorization;

namespace BettingPool.Infrastructure.Services.Permission;

internal sealed class PermissionRequirement : IAuthorizationRequirement
{
    internal PermissionRequirement(string permission) => Permission = permission;
    internal string Permission { get; }
}
