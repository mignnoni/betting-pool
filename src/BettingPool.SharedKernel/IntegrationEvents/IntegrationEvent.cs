namespace BettingPool.SharedKernel.IntegrationEvents;

public abstract record IntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; }
    public DateTime OccurredOn { get; }

    protected IntegrationEvent(Guid id, DateTime ocurredOn)
    : this()
    {
        Id = id;
        OccurredOn = ocurredOn;
    }

    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }
}
