using Ardalis.Specification;
using BettingPool.Domain.Championships;

namespace BettingPool.Application.Championships.Specifications;

public class GetChampionshipByIdReadOnlySpec : Specification<Championship>
{
    public GetChampionshipByIdReadOnlySpec(Guid id)
    {
        Query
            .AsNoTracking()
            .Where(x => x.Id == id);
    }
}
