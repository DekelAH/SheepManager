using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class AddMatch_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_AddMatch = @"
            CREATE PROCEDURE [dbo].[AddMatch]
            (@MatchId uniqueidentifier, @MaleTagNumber int, @FemaleTagNumber int)            
            AS BEGIN
                INSERT INTO [dbo].[Matches](MatchId, MaleTagNumber, FemaleTagNumber)
                VALUES (@MatchId, @MaleTagNumber, @FemaleTagNumber)
            END
            ";

            migrationBuilder.Sql(sp_AddMatch);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_AddMatch = @"
            DROP PROCEDURE [dbo].[AddMatch]
            ";

            migrationBuilder.Sql(sp_AddMatch);
        }
    }
}
