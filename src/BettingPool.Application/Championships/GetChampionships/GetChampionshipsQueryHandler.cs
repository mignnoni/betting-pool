using Ardalis.Result;
using BettingPool.Application.Championships.Specifications;
using BettingPool.Domain.Championships;
using BettingPool.SharedKernel.Application;
using BettingPool.SharedKernel.Domain;

namespace BettingPool.Application.Championships.GetChampionships;

internal class GetChampionshipsQueryHandler(
    IRepository<Championship> _repo) : IQueryHandler<GetChampionshipsQuery, List<GetChampionshipsResponse>>
{
    public async Task<Result<List<GetChampionshipsResponse>>> Handle(GetChampionshipsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetChampionshipsPaginatedReadOnlySpec(request.PageIndex, request.PageSize);

        var championships = await _repo.ListAsync(spec, cancellationToken);

        if (championships is null)
            return new List<GetChampionshipsResponse>();

        return championships.Select(s => new GetChampionshipsResponse(
            s.Id,
            s.Title,
            s.StartDate,
            s.EndDate,
            s.Description,
            s.Base64Logo)).ToList();
    }
}
