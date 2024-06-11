using Ardalis.Specification;
using BettingPool.Domain.Championships;

namespace BettingPool.Application.Championships.Specifications;

public class GetChampionshipByIdSpec : Specification<Championship>
{
    public GetChampionshipByIdSpec(Guid id)
    {
        Query
            .Where(x => x.Id == id);
    }
}
