using BettingPool.Domain.Matches.Events;
using BettingPool.SharedKernel.Application;

namespace BettingPool.Domain.Predictions.EventHandlers;

public class MatchScoreUpdatedDomainEventHandler : IDomainEventHandler<MatchScoreUpdatedDomainEvent>
{
    public async Task Handle(MatchScoreUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        if (notification.OcurredOn < notification.MatchDate)
            return;

        await Task.CompletedTask;
    }
}
