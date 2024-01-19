using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{

    public partial class GetVaccinesByTagNumber : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetVaccinesByTagNumber = @"
            CREATE PROCEDURE [dbo].[GetVaccinesByTagNumber] (@TagNumber int)
            AS BEGIN
                SELECT VaccineId, VaccineName, VaccinationDate, IsMandatory, IsForBirth, SheepTagNumber
                FROM [dbo].[Vaccines]
                WHERE SheepTagNumber = @TagNumber
            END
            ";

            migrationBuilder.Sql(sp_GetVaccinesByTagNumber);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetVaccinesByTagNumber = @"
            DROP PROCEDURE [dbo].[GetVaccinesByTagNumber]
            ";

            migrationBuilder.Sql(sp_GetVaccinesByTagNumber);
        }
    }
}
