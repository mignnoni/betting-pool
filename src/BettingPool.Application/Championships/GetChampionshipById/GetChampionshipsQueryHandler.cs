using Ardalis.Result;
using BettingPool.Application.Championships.Specifications;
using BettingPool.Domain.Championships;
using BettingPool.SharedKernel.Application;
using BettingPool.SharedKernel.Domain;

namespace BettingPool.Application.Championships.GetChampionshipById;

internal class GetChampionshipByIdQueryHandler(
    IRepository<Championship> _repo) : IQueryHandler<GetChampionshipByIdQuery, ChampionshipResponse>
{
    public async Task<Result<ChampionshipResponse>> Handle(GetChampionshipByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetChampionshipByIdReadOnlySpec(request.Id);

        var championship = await _repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (championship is null)
            return Result.Error("Campeonato não encontrado");

        return new ChampionshipResponse(
            championship.Id,
            championship.Title,
            championship.StartDate,
            championship.EndDate,
            championship.Description,
            championship.Base64Logo);
    }
}
