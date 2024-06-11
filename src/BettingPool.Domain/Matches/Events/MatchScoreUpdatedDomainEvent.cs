using BettingPool.SharedKernel.Domain;

namespace BettingPool.Domain.Matches.Events;

public sealed record MatchScoreUpdatedDomainEvent(
    Guid Id,
    DateTime OcurredOn,
    DateTime MatchDate,
    int Score1,
    int Score2) : DomainEvent(Id, OcurredOn);
