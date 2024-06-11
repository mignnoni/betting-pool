using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using BettingPool.API.Users.Contracts;
using BettingPool.Application.Users.CreateUser;
using BettingPool.Application.Users.ForgotPassword;
using BettingPool.Application.Users.Login;
using BettingPool.Application.Users.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BettingPool.API.Users;

[Route("[controller]")]
[ApiController]
public class UsersController(ISender _sender) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("new-account")]
    [TranslateResultToActionResult]
    public async Task<Result<UserCreatedResponse>> CreateUser(CreateUserRequest request)
    {
        return await _sender.Send(new CreateUserCommand(
            request.FullName,
            request.Email,
            request.Password,
            request.ConfirmPassword));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [TranslateResultToActionResult]
    public async Task<Result<LoginResponse>> Login(LoginRequest request)
    {
        return await _sender.Send(new LoginCommand(
            request.Email,
            request.Password));
    }

    [AllowAnonymous]
    [HttpPost("recoverPassword")]
    [TranslateResultToActionResult]
    public async Task<Result<ForgotPasswordResponse>> RecoverPassword(ForgotPasswordRequest request)
    {
        return await _sender.Send(new ForgotPasswordCommand(request.Email));
    }

    [AllowAnonymous]
    [HttpPost("resetPassword")]
    [TranslateResultToActionResult]
    public async Task<Result> ResetPassword(ResetPasswordRequest request)
    {
        return await _sender.Send(new ResetPasswordCommand(
            request.Email,
            request.Token,
            request.Password,
            request.ConfirmPassword));
    }
}
