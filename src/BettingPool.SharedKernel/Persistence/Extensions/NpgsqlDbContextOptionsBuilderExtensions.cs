using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace BettingPool.SharedKernel.Persistence.Extensions;

public static class NpgsqlDbContextOptionsBuilderExtensions
{
    public static NpgsqlDbContextOptionsBuilder WithMigrationHistoryTableInSchema(
        this NpgsqlDbContextOptionsBuilder dbContextOptionsBuilder,
        string schema) =>
        dbContextOptionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", schema);
}
