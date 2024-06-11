using BettingPool.Domain.Championships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingPool.Persistence.Configurations;

public class ChampionshipsConfig : IEntityTypeConfiguration<Championship>
{
    public void Configure(EntityTypeBuilder<Championship> builder)
    {
        builder.ToTable("Championship");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Title)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasMaxLength(200)
            .IsRequired(false);

        builder
            .Property(x => x.StartDate)
            .IsRequired();

        builder
            .Property(x => x.EndDate)
            .IsRequired();
    }
}
