using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class GetAllMatches_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllMatches = @"
            CREATE PROCEDURE [dbo].[GetAllMatches]
            AS BEGIN
            SELECT MatchId, MaleTagNumber, FemaleTagNumber
            FROM [dbo].[Matches]
            END
            ";

            migrationBuilder.Sql(sp_GetAllMatches);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllMatches = @"
            DROP PROCEDURE [dbo].[GetAllMatches]
            ";

            migrationBuilder.Sql(sp_GetAllMatches);
        }
    }
}
