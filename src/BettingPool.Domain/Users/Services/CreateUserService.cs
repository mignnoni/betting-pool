using Ardalis.Result;
using BettingPool.Domain.Users.Abstractions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BettingPool.Domain.Users.Services;

public class CreateUserService(UserManager<User> _userManager, RoleManager<IdentityRole<Guid>> _roleManager) : ICreateUserService
{
    public async Task<Result<Guid>> CreateUser(string fullName, string email, string password, string role)
    {

        if (!await _roleManager.RoleExistsAsync(role))
            return Result.NotFound("Role não encontrada");

        var user = User.Create(fullName, email);

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            return Result.Error(result.Errors.First().Description);

        var rolesResult = await AddToRole(user, role);

        if (!rolesResult.Succeeded)
        {
            await DeleteUserAfterCreated(user);
            return Result.Error(rolesResult.Errors.First().Description);
        }

        var claimsResult = await AddClaims(user);

        if (!claimsResult.Succeeded)
        {
            await DeleteUserAfterCreated(user);
            return Result.Error(claimsResult.Errors.First().Description);
        }

        return Result.Success(user.Id);
    }

    private async Task DeleteUserAfterCreated(User user)
    {
        await _userManager.DeleteAsync(user);
    }

    private async Task<IdentityResult?> AddToRole(User user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    private async Task<IdentityResult?> AddClaims(User user)
    {
        return await _userManager
            .AddClaimsAsync(user,
            [
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            ]);
    }

}
