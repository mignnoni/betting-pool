using BettingPool.SharedKernel.Domain;

namespace BettingPool.Domain.Predictions;

public sealed class Prediction : Entity<Guid>
{
    public Prediction(Guid id, Guid matchId, Guid groupId, Guid userId, int scoreTeam1, int scoreTeam2)
    {
        Id = id;
        MatchId = matchId;
        GroupId = groupId;
        UserId = userId;
        ScoreTeam1 = scoreTeam1;
        ScoreTeam2 = scoreTeam2;
    }

    public Guid MatchId { get; private set; }
    public Guid GroupId { get; private set; }
    public Guid UserId { get; private set; }
    public int ScoreTeam1 { get; private set; }
    public int ScoreTeam2 { get; private set; }

    public static Prediction Create(Guid id, Guid matchId, Guid groupId, Guid userId, int score1, int score2)
    {
        return new Prediction(id, matchId, groupId, userId, score1, score2);
    }

    public void Update(int score1, int score2)
    {
        ScoreTeam1 = score1;
        ScoreTeam2 = score2;
    }
}
