using MediatR;

namespace BettingPool.SharedKernel.IntegrationEvents
{
    public interface IIntegrationEvent : INotification
    {
        Guid Id { get; }
        DateTime OccurredOn { get; }
    }
}
