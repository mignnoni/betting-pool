using MediatR;

namespace BettingPool.SharedKernel.IntegrationEvents;

public interface IIntegrationEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IIntegrationEvent
{
}
