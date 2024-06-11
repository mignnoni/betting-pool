using Ardalis.Result;
using Ardalis.Specification;
using BettingPool.Domain.Championships;
using BettingPool.Domain.Championships.Abstractions;
using BettingPool.SharedKernel.Application;
using BettingPool.SharedKernel.Domain;
using BettingPool.SharedKernel.Persistence;
using FluentValidation;
namespace BettingPool.Application.Championships.CreateChampionship;

internal class CreateChampionshipCommandHandler(
    IRepository<Championship> _repo,
    IUnitOfWork _uow,
    IValidator<CreateChampionshipCommand> _validator) : ICommandHandler<CreateChampionshipCommand>
{
    public async Task<Result> Handle(CreateChampionshipCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return Result.Error(validatorResult.Errors.First().ErrorMessage);

        var championship = Championship.Create(
            Guid.NewGuid(),
            request.Title, 
            request.StartDate, 
            request.EndDate, 
            request.Description, 
            request.Base64Logo);

        _repo.Add(championship);

        await _uow.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
