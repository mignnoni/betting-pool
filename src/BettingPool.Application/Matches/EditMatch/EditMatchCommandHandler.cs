using Ardalis.Result;
using BettingPool.Application.Matches.Specifications;
using BettingPool.Domain.Matches;
using BettingPool.SharedKernel.Application;
using BettingPool.SharedKernel.Domain;
using BettingPool.SharedKernel.Persistence;
using FluentValidation;
namespace BettingPool.Application.Matches.EditMatch;

internal class EditMatchCommandHandler(
    IRepository<Match> _repo,
    IUnitOfWork _uow,
    IValidator<EditMatchCommand> _validator) : ICommandHandler<EditMatchCommand>
{
    public async Task<Result> Handle(EditMatchCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return Result.Error(validatorResult.Errors.First().ErrorMessage);

        var spec = new GetMatchByIdSpec(request.Id);

        var match = await _repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (match is null)
            return Result.Error("Partida não encontrada");

        match.UpdateBasicInfo(
            request.Team1,
            request.Team2,
            request.Date,
            request.Round);

        await _uow.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
