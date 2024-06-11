using Ardalis.Specification;

namespace BettingPool.Domain.Championships.Abstractions;

public interface IChampionshipRepository
{
    Task<Championship?> FirstOrDefaultAsync(
    ISpecification<Championship> specification,
    CancellationToken cancellationToken = default);

    Task<List<Championship>> ListAsync(ISpecification<Championship> specification, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(ISpecification<Championship> specification, CancellationToken cancellationToken = default);

    Task<List<Championship>> GetAll();

    void Add(Championship championship);
    void Delete(Championship championship);
}
