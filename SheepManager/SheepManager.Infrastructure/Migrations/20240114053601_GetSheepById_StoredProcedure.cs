using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{

    public partial class GetSheepById_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetSheepById = @"
            CREATE PROCEDURE [dbo].[GetSheepById] (@SheepId uniqueidentifier)
            AS BEGIN
                SELECT SheepId, TagNumber, Weight, Gender, Race, BloodType, 
                   Selection, Birthdate, MotherTagNumber, FatherTagNumber,
                   IsDead, IsSold, IsPregnant, BirthId, VaccineId
                FROM [dbo].[Sheeps]
                WHERE SheepId = @SheepId
            END
            ";

            migrationBuilder.Sql(sp_GetSheepById);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetSheepById = @"
            DROP PROCEDURE [dbo].[GetSheepById]
            ";

            migrationBuilder.Sql(sp_GetSheepById);
        }
    }
}
