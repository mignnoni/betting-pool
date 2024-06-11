using Microsoft.AspNetCore.Authorization;

namespace BettingPool.SharedKernel.Infrastructure;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    internal const string HasPermissionPolicyName = "HasPermission";

    public HasPermissionAttribute(string permission)
        : base(permission) =>
        Permission = permission;

    public string Permission { get; }
}
