using BettingPool.Domain.Championships;
using BettingPool.Domain.Matches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingPool.Persistence.Configurations;

public class MatchesConfig : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Match");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.ChampionshipId)
            .IsRequired();

        builder
            .Property(x => x.Team1)
            .HasMaxLength(40)
            .IsRequired();

        builder
            .Property(x => x.Team2)
            .HasMaxLength(40)
            .IsRequired();

        builder
            .Property(x => x.ScoreTeam1)
            .IsRequired(false);

        builder
            .Property(x => x.ScoreTeam2)
            .IsRequired(false);

        builder
            .Property(x => x.Date)
            .IsRequired();

        builder
            .HasOne<Championship>()
            .WithMany(many => many.Matches)
            .HasForeignKey(fk => fk.ChampionshipId)
            .IsRequired();
    }
}
