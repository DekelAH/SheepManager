using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class GetAllFemales_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllFemales = @"
            CREATE PROCEDURE [dbo].[GetAllFemales]
            AS BEGIN
                SELECT SheepId, TagNumber, HerdId, Weight, Gender, Race, BloodType, 
                   Selection, Birthdate, MotherTagNumber, FatherTagNumber,
                   IsDead, IsSold, IsPregnant
                FROM [dbo].[Sheeps]
                WHERE Gender = 'Female'
            END
            ";

            migrationBuilder.Sql(sp_GetAllFemales);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllFemales = @"
            DROP PROCEDURE [dbo].[GetAllFemales]
            ";

            migrationBuilder.Sql(sp_GetAllFemales);
        }
    }
}
