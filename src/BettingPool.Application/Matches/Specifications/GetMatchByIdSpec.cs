using Ardalis.Specification;
using BettingPool.Domain.Matches;

namespace BettingPool.Application.Matches.Specifications;

public class GetMatchByIdSpec : Specification<Match>
{
    public GetMatchByIdSpec(Guid id)
    {
        Query
            .Where(x => x.Id == id);
    }
}
