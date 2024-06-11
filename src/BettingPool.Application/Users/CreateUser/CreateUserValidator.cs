using FluentValidation;

namespace BettingPool.Application.Users.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FullName)
            .Must(x => x.IndexOf(" ") > -1)
            .WithMessage("É necessário informar o nome completo")
            .MinimumLength(6)
            .WithMessage("O nome completo deve ter no mínimo 6 caracteres");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("O campo digitado deve ser um e-mail válido");

        RuleFor(x => x.Password)
            .Matches(x => x.ConfirmPassword)
            .WithMessage("As senhas digitadas devem ser iguais")
            .MinimumLength(8)
            .WithMessage("A senha deve conter pelo menos 8 caracteres");
    }
}
