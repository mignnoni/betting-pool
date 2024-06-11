using Ardalis.Result;
using BettingPool.Application.Matches.Specifications;
using BettingPool.Domain.Matches;
using BettingPool.SharedKernel.Application;
using BettingPool.SharedKernel.Domain;

namespace BettingPool.Application.Matches.GetMatches;

internal class GetMatchesQueryHandler(
    IRepository<Match> _repo) : IQueryHandler<GetMatchesQuery, List<GetMatchesResponse>>
{
    public async Task<Result<List<GetMatchesResponse>>> Handle(GetMatchesQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetMatchesByChampionshipPaginatedReadOnlySpec(request.PageIndex, request.PageSize, request.ChampionshipId);

        var championships = await _repo.ListAsync(spec, cancellationToken);

        if (championships is null)
            return new List<GetMatchesResponse>();

        return championships.Select(s => new GetMatchesResponse(
            s.Id,
            s.Team1,
            s.Team2,
            s.ScoreTeam1,
            s.ScoreTeam2,
            s.Round,
            s.Date,
            s.ChampionshipId)).ToList();
    }
}
