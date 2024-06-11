using Ardalis.Result;
using BettingPool.Domain.Users;
using BettingPool.SharedKernel.Application;
using Microsoft.AspNetCore.Identity;

namespace BettingPool.Application.Users.DeleteUser;

public class DeleteUserCommandHandler(UserManager<User> _userManager)
    : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);

        if (user is null)
            return Result.NotFound("Usuário não encontrado");

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
            return Result.Error(result.Errors.First().Description);

        return Result.Success();
    }
}
