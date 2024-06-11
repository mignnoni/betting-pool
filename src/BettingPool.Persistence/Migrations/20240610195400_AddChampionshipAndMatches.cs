using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddChampionshipAndMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Base64Logo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChampionshipId = table.Column<Guid>(type: "uuid", nullable: false),
                    Team1 = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Team2 = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ScoreTeam1 = table.Column<int>(type: "integer", nullable: true),
                    ScoreTeam2 = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalSchema: "dbo",
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_ChampionshipId",
                schema: "dbo",
                table: "Match",
                column: "ChampionshipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Championship",
                schema: "dbo");
        }
    }
}
