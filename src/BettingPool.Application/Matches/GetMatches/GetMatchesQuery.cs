using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Matches.GetMatches;

public sealed record GetMatchesQuery(
    int PageIndex,
    int PageSize,
    Guid ChampionshipId) : IQuery<List<GetMatchesResponse>>;