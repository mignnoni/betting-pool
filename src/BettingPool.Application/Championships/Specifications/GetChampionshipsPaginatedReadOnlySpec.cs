using Ardalis.Specification;
using BettingPool.Domain.Championships;

namespace BettingPool.Application.Championships.Specifications;

public class GetChampionshipsPaginatedReadOnlySpec : Specification<Championship>
{
    public GetChampionshipsPaginatedReadOnlySpec(int pageIndex, int pageSize)
    {
        Query
            .AsNoTracking()
            .OrderByDescending(o => o.StartDate)
            .Skip(pageIndex * pageSize)
            .Take(pageSize);
    }
}
