using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Users.Permissions.GetRolePermissions;

public sealed record GetRolePermissionsQuery(string Role) : IQuery<HashSet<string>>
{
}
