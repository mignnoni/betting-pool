using BettingPool.Domain.Matches.Events;
using BettingPool.SharedKernel.Domain;

namespace BettingPool.Domain.Matches;

public sealed class Match : Entity<Guid>, IAggregateRoot
{
    private Match(Guid id, Guid championshipId, string team1, string team2, DateTime date, int round)
    {
        Id = id;
        ChampionshipId = championshipId;
        Team1 = team1;
        Team2 = team2;
        Date = date;
        Round = round;
    }

    private Match()
    {

    }

    public Guid ChampionshipId { get; private set; }
    public string Team1 {  get; private set; }
    public string Team2 { get; private set; }
    public int? ScoreTeam1 { get; private set; }
    public int? ScoreTeam2 { get; private set ;}
    public int Round {  get; private set; }
    public DateTime Date {  get; private set; }

    public static Match Create(Guid id, Guid championshipId, string team1, string team2, DateTime date, int round)
    {
        return new Match(id, championshipId, team1, team2, date, round);
    }

    public void SetScore(int scoreTeam1, int scoreTeam2)
    {
        ScoreTeam1 = scoreTeam1;
        ScoreTeam2 = scoreTeam2;

        this.RaiseDomainEvent(new MatchScoreUpdatedDomainEvent(
            Guid.NewGuid(),
            DateTime.UtcNow,
            this.Date,
            scoreTeam1, scoreTeam2));
    }

    public void UpdateBasicInfo(string team1, string team2, DateTime date, int round)
    {
        Team1 = team1;
        Team2 = team2;
        Date = date;
        Round = round;
    }
}
