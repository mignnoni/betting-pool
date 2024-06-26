﻿using Ardalis.Result;
using BettingPool.Application.Users.Abstractions;
using BettingPool.Application.Users.Common;
using BettingPool.Domain.Users;
using BettingPool.SharedKernel.Application;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Text.Json;

namespace BettingPool.Application.Users.ForgotPassword;

internal sealed class ForgotPasswordCommandHandler(
    UserManager<User> _userManager,
    IEmailSender _emailSender) : ICommandHandler<ForgotPasswordCommand, ForgotPasswordResponse>
{
    public async Task<Result<ForgotPasswordResponse>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return Result.NotFound("Usuário não encontrado");
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        if (string.IsNullOrEmpty(token))
            return Result.Error("Não foi possível gerar o token de alteração de senha. Por favor, tente novamente");

        string tokenString = JsonSerializer.Serialize(new ResetPasswordToken(token, request.Email));

        byte[] bytes = Encoding.UTF8.GetBytes(tokenString);

        var base64Token = Convert.ToBase64String(bytes);

        await _emailSender.SendTokenToResetPassword(
            user.FullName,
            request.Email,
            base64Token,
            cancellationToken);

        return new ForgotPasswordResponse(request.Email, token);
    }
}
