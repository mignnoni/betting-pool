namespace BettingPool.Application.Championships.GetChampionshipById;

public sealed record ChampionshipResponse(
    Guid Id,
    string Title,
    DateTime StartDate,
    DateTime EndDate,
    string? Description,
    string? Logo);
