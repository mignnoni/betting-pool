using FluentValidation;

namespace BettingPool.Application.Championships.CreateChampionship;

public class CreateChampionshipValidator : AbstractValidator<CreateChampionshipCommand>
{
    public CreateChampionshipValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(40);

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("A data de início deve ser maior que a data de fim");
    }
}
