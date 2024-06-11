using FluentValidation;

namespace BettingPool.Application.Matches.CreateMatch;

public class CreateMatchValidator : AbstractValidator<CreateMatchCommand>
{
    public CreateMatchValidator()
    {
        RuleFor(x => x.Team1)
            .NotEmpty();

        RuleFor(x => x.Team2)
            .NotEmpty();

        RuleFor(x => x.Round)
            .NotNull();
    }
}
