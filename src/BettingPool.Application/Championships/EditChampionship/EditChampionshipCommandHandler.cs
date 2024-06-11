using Ardalis.Result;
using BettingPool.Application.Championships.Specifications;
using BettingPool.Domain.Championships;
using BettingPool.SharedKernel.Application;
using BettingPool.SharedKernel.Domain;
using BettingPool.SharedKernel.Persistence;
using FluentValidation;
namespace BettingPool.Application.Championships.EditChampionship;

internal class EditChampionshipCommandHandler(
    IRepository<Championship> _repo,
    IUnitOfWork _uow,
    IValidator<EditChampionshipCommand> _validator) : ICommandHandler<EditChampionshipCommand>
{
    public async Task<Result> Handle(EditChampionshipCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return Result.Error(validatorResult.Errors.First().ErrorMessage);

        var spec = new GetChampionshipByIdSpec(request.Id);

        var championship = await _repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (championship is null)
            return Result.Error("Campeonato não encontrado");

        championship.Update(request.Title, request.StartDate, request.EndDate, request.Description, request.Base64Logo);

        await _uow.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
