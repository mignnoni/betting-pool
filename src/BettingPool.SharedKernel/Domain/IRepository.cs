using Ardalis.Specification;

namespace BettingPool.SharedKernel.Domain;

public interface IRepository<T> where T : class
{
    Task<T?> FirstOrDefaultAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default);

    Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<List<T>> GetAll();

    void Add(T entity);
    void Delete(T entity);
}
