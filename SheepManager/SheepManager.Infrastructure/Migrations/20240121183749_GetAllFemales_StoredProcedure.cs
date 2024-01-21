using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetAllFemales_StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllFemales = @"
            CREATE PROCEDURE [dbo].[GetAllFemales]
            AS BEGIN
                SELECT SheepId, TagNumber, Weight, Gender, Race, BloodType, 
                   Selection, Birthdate, MotherTagNumber, FatherTagNumber,
                   IsDead, IsSold, IsPregnant, BirthId, VaccineId
                FROM [dbo].[Sheeps]
                WHERE Gender = 'Female'
            END
            ";

            migrationBuilder.Sql(sp_GetAllFemales);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllFemales = @"
            DROP PROCEDURE [dbo].[GetAllFemales]
            ";

            migrationBuilder.Sql(sp_GetAllFemales);
        }
    }
}
