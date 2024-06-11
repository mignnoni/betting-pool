using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.""AspNetRoles""(""Id"", ""Name"", ""NormalizedName"")
	                VALUES ('E66506C1-4792-4DF0-B4FF-949E431A5480', 'admin', 'ADMIN');

                INSERT INTO dbo.""AspNetRoles""(""Id"", ""Name"", ""NormalizedName"")
	                VALUES ('03E511DD-BA29-476E-8D19-B888B1C6C029', 'member', 'MEMBER');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
