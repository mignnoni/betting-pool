namespace BettingPool.Application.Matches.GetMatches;

public sealed record GetMatchesResponse(
    Guid Id,
    string Team1,
    string Team2,
    int? ScoreTeam1,
    int? ScoreTeam2,
    int Round,
    DateTime Date,
    Guid ChampionshipId);
