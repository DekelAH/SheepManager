using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class GetAllMales_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllMales = @"
            CREATE PROCEDURE [dbo].[GetAllMales]
            AS BEGIN
                SELECT SheepId, TagNumber, Weight, Gender, Race, BloodType, 
                   Selection, Birthdate, MotherTagNumber, FatherTagNumber,
                   IsDead, IsSold, IsPregnant, BirthId, VaccineId
                FROM [dbo].[Sheeps]
                WHERE Gender = 'Male'
            END
            ";

            migrationBuilder.Sql(sp_GetAllMales);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllMales = @"
            DROP PROCEDURE [dbo].[GetAllMales]
            ";

            migrationBuilder.Sql(sp_GetAllMales);
        }
    }
}
