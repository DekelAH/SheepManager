using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class AddVaccine_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_AddVaccine = @"
            CREATE PROCEDURE [dbo].[AddVaccine]
            (@VaccineId uniqueidentifier, @VaccineName NVARCHAR (MAX), @VaccinationDate DATETIME2 (7), @IsMandatory BIT, 
             @IsForBirth BIT, @SheepTagNumber INT)            
            AS BEGIN
                INSERT INTO [dbo].[Vaccines](VaccineId, VaccineName, VaccinationDate, IsMandatory, IsForBirth, SheepTagNumber)
                VALUES (@VaccineId, @VaccineName, @VaccinationDate, @IsMandatory, @IsForBirth, @SheepTagNumber)
            END
            ";

            migrationBuilder.Sql(sp_AddVaccine);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_AddVaccine = @"
            DROP PROCEDURE [dbo].[AddVaccine]
            ";

            migrationBuilder.Sql(sp_AddVaccine);
        }
    }
}
