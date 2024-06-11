using Ardalis.Result;
using BettingPool.Application.Championships.Specifications;
using BettingPool.Domain.Championships;
using BettingPool.Domain.Matches;
using BettingPool.SharedKernel.Application;
using BettingPool.SharedKernel.Domain;
using BettingPool.SharedKernel.Persistence;
using FluentValidation;

namespace BettingPool.Application.Matches.CreateMatch;

internal class CreateMatchCommandHandler(
    IRepository<Match> _repo,
    IRepository<Championship> _championshipRepo,
    IUnitOfWork _uow,
    IValidator<CreateMatchCommand> _validator) : ICommandHandler<CreateMatchCommand>
{
    public async Task<Result> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return Result.Error(validatorResult.Errors.First().ErrorMessage);

        var spec = new GetChampionshipByIdReadOnlySpec(request.ChampionshipId);

        var exists = await _championshipRepo.AnyAsync(spec, cancellationToken);

        if (!exists)
            return Result.Error("Campeonato não encontrado");

        var match = Match.Create(
            Guid.NewGuid(),
            request.ChampionshipId,
            request.Team1,
            request.Team2,
            request.Date,
            request.Round);

        _repo.Add(match);

        await _uow.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
