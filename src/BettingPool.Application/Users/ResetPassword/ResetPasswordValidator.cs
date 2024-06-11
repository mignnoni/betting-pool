using BettingPool.Application.Users.ResetPassword;
using FluentValidation;

namespace BettingPool.Application.Users.ResetPassword;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("O campo digitado deve ser um e-mail válido");

        RuleFor(x => x.NewPassword)
            .Matches(x => x.ConfirmNewPassword)
            .WithMessage("As senhas digitadas devem ser iguais")
            .MinimumLength(8)
            .WithMessage("A senha deve conter pelo menos 8 caracteres");

        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("O token para redefinição de senha deve ser informado");
    }
}
