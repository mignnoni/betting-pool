using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using BettingPool.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace BettingPool.Persistence.Repositories;

public sealed class GenericRepository<T>(AppDbContext context) : IRepository<T> where T : class
{
    private readonly AppDbContext _context = context;

    public Task<List<T>> GetAll()
    {
        return _context.Set<T>().ToListAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public void Add(T group)
    {
        _context.Set<T>().Add(group);
    }

    public void Update(T group)
    {
        _context.Set<T>().Update(group);
    }

    public void Delete(T group)
    {
        _context.Set<T>().Remove(group);
    }

    public async Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification, true).AnyAsync(cancellationToken);
    }

    private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
    {
        return SpecificationEvaluator.Default.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification, bool evaluateCriteriaOnly = false)
    {
        return SpecificationEvaluator.Default.GetQuery(_context.Set<T>().AsQueryable(), specification, evaluateCriteriaOnly);
    }

}
