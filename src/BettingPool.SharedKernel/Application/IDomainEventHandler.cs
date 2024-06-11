using BettingPool.SharedKernel.Domain;
using MediatR;

namespace BettingPool.SharedKernel.Application;

public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}

