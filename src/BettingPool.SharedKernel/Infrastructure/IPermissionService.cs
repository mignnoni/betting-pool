namespace BettingPool.SharedKernel.Infrastructure;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsByRoleAsync(string identityProviderId, CancellationToken cancellationToken = default);
}
