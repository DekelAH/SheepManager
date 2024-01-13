using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetAllSheeps_StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllSheeps = @"
            CREATE PROCEDURE [dbo].[GetAllSheeps]
            AS BEGIN
            SELECT SheepId, TagNumber, Weight, Gender, Race, BloodType, Selection, Birthdate, MotherTagNumber, FatherTagNumber,
                   IsDead, IsSold, IsPregnant, BirthId, VaccineId
            FROM [dbo].[Sheeps]
            END
            ";

            migrationBuilder.Sql(sp_GetAllSheeps);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllSheeps = @"
            DROP PROCEDURE [dbo].[GetAllSheeps]
            ";
            
            migrationBuilder.Sql(sp_GetAllSheeps);
        }
    }
}
