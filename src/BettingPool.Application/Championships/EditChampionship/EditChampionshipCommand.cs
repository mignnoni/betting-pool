using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Championships.EditChampionship;

public sealed record EditChampionshipCommand(
    Guid Id,
    string Title,
    DateTime StartDate,
    DateTime EndDate,
    string? Description = null,
    string? Base64Logo = null) : ICommand;
