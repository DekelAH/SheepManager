using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class GetAllSheeps_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllSheeps = @"
            CREATE PROCEDURE [dbo].[GetAllSheeps]
            AS BEGIN
            SELECT SheepId, TagNumber, HerdId, Weight, Gender, Race, BloodType, Selection, Birthdate, MotherTagNumber, FatherTagNumber,
                   IsDead, IsSold, IsPregnant
            FROM [dbo].[Sheeps]
            END
            ";

            migrationBuilder.Sql(sp_GetAllSheeps);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllSheeps = @"
            DROP PROCEDURE [dbo].[GetAllSheeps]
            ";
            
            migrationBuilder.Sql(sp_GetAllSheeps);
        }
    }
}
