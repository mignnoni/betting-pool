using Ardalis.Specification;
using BettingPool.Domain.Matches;

namespace BettingPool.Application.Matches.Specifications;

public class GetMatchesByChampionshipPaginatedReadOnlySpec : Specification<Match>
{
    public GetMatchesByChampionshipPaginatedReadOnlySpec(int pageIndex, int pageSize, Guid championshipId)
    {
        Query
            .AsNoTracking()
            .Where(x => x.ChampionshipId == championshipId)
            .OrderBy(o => o.Date)
            .Skip(pageIndex * pageSize)
            .Take(pageSize);
    }
}
