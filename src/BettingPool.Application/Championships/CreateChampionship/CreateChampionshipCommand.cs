using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Championships.CreateChampionship;

public sealed record CreateChampionshipCommand(
    string Title,
    DateTime StartDate,
    DateTime EndDate, 
    string? Description = null,
    string? Base64Logo = null) : ICommand;
