using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Matches.EditMatch;

public sealed record EditMatchCommand(
    Guid Id,
    string Team1,
    string Team2,
    DateTime Date,
    int Round) : ICommand;
