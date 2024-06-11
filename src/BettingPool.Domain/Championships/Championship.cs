using Ardalis.Result;
using BettingPool.Domain.Matches;
using BettingPool.SharedKernel.Domain;

namespace BettingPool.Domain.Championships;

public sealed class Championship : Entity<Guid>, IAggregateRoot
{
    private Championship(Guid id, string title, DateTime startDate, DateTime endDate, string? description = null, string? base64Logo = null)
    {
        Id = id;
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Base64Logo = base64Logo;
    }

    private Championship()
    {
        
    }

    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string? Base64Logo { get; private set; }

    private readonly List<Match> _matches = [];
    public IEnumerable<Match> Matches => _matches;

    public static Championship Create(Guid id, string title, DateTime startDate, DateTime endDate, string? description = null, string? base64Logo = null)
    {
        return new Championship(id, title, startDate, endDate, description, base64Logo);
    }

    public void Update(string title, DateTime startDate, DateTime endDate, string? description = null, string? base64Logo = null)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Base64Logo = base64Logo;
    }
}
