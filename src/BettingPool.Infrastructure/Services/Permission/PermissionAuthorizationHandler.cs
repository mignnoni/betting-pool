using BettingPool.SharedKernel.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using BettingPool.SharedKernel.API.Authorization.Extensions;

namespace BettingPool.Infrastructure.Services.Permission;

internal sealed class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory) : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();

        IPermissionService permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();

        HashSet<string> permissions = await permissionService.GetPermissionsByRoleAsync(context.User.GetUserRole());

        if (permissions.Contains(requirement.Permission))
            context.Succeed(requirement);
    }
}
