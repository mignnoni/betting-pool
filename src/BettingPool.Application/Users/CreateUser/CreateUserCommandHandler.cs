using Ardalis.Result;
using BettingPool.Domain.Users.Abstractions;
using BettingPool.Domain.Users.Constants;
using BettingPool.SharedKernel.Application;
using FluentValidation;

namespace BettingPool.Application.Users.CreateUser;

public class CreateUserCommandHandler(
    ICreateUserService _createUserService,
    IValidator<CreateUserCommand> _validator) : ICommandHandler<CreateUserCommand, UserCreatedResponse>
{
    public async Task<Result<UserCreatedResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return Result.Error(validationResult.Errors.First().ErrorMessage);

        if (request.Password != request.ConfirmPassword)
            return Result.Error("As senhas digitadas devem ser iguais");


        var result = await _createUserService
            .CreateUser(
                request.FullName,
                request.Email,
                request.Password,
                UserRoles.Admin
            );

        return result
            .Map(userId => new UserCreatedResponse(
                userId,
                request.FullName,
                request.Email));
    }
}
