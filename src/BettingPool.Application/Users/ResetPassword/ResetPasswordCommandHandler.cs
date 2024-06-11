using Ardalis.Result;
using BettingPool.Application.Users.Abstractions;
using BettingPool.Domain.Users;
using BettingPool.SharedKernel.Application;
using Microsoft.AspNetCore.Identity;

namespace BettingPool.Application.Users.ResetPassword;

internal sealed class ResetPasswordCommandHandler(
    UserManager<User> _userManager,
    IEmailSender _emailSender) : ICommandHandler<ResetPasswordCommand>
{
    public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        if (request.NewPassword != request.ConfirmNewPassword)
            return Result.Error("As senhas digitadas devem ser iguais");

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return Result.NotFound("Usuário não encontrado");
        }

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

        if (!result.Succeeded)
            return Result.Error(result.Errors.First().Description);

        await _emailSender.PasswordReseted(user.FullName, user.Email, cancellationToken);

        return Result.Success();
    }
}
