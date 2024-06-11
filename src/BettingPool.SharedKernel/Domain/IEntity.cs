namespace BettingPool.SharedKernel.Domain;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> GetDomainEvents();
    void ClearDomainEvents();
}
