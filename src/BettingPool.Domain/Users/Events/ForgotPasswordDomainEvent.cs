using BettingPool.SharedKernel.Domain;

namespace BettingPool.Domain.Users.Events;

public sealed record ForgotPasswordDomainEvent(
    Guid Id,
    DateTime OcurredOn,
    string FullName,
    string Email) : DomainEvent(Id, OcurredOn);
