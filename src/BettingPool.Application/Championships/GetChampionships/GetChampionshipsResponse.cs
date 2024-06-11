namespace BettingPool.Application.Championships.GetChampionships;

public sealed record GetChampionshipsResponse(
    Guid Id,
    string Title,
    DateTime StartDate,
    DateTime EndDate,
    string? Description,
    string? Logo);
