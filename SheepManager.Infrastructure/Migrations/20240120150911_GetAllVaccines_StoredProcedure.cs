using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{

    public partial class GetAllVaccines_StoredProcedure : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllVaccines = @"
            CREATE PROCEDURE [dbo].[GetAllVaccines]
            AS BEGIN
            SELECT  VaccineId, VaccineName, VaccinationDate, IsMandatory, IsForBirth, SheepTagNumber
            FROM [dbo].[Vaccines]
            END
            ";

            migrationBuilder.Sql(sp_GetAllVaccines);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllVaccines = @"
            DROP PROCEDURE [dbo].[GetAllVaccines]
            ";

            migrationBuilder.Sql(sp_GetAllVaccines);
        }
    }
}

