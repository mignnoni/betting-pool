using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Matches.CreateMatch;

public sealed record CreateMatchCommand(
    Guid ChampionshipId,
    string Team1,
    string Team2,
    DateTime Date,
    int Round) : ICommand;
