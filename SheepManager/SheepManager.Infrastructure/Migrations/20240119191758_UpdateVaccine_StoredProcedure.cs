using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class UpdateVaccine_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_UpdateVaccine = @"
            CREATE PROCEDURE [dbo].[UpdateVaccine]
            (@VaccineId uniqueidentifier, @VaccineName NVARCHAR (MAX), @VaccinationDate DATETIME2 (7), @IsMandatory BIT, 
             @IsForBirth BIT, @SheepTagNumber INT)            
            AS BEGIN

                UPDATE [dbo].[Vaccines]
                SET
                VaccineId = @VaccineId,
                VaccineName = @VaccineName, 
                VaccinationDate = @VaccinationDate, 
                IsMandatory = @IsMandatory, 
                IsForBirth = @IsForBirth, 
                SheepTagNumber = @SheepTagNumber
                
                WHERE VaccineId = @VaccineId;
            END
            ";

            migrationBuilder.Sql(sp_UpdateVaccine);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_UpdateVaccine = @"
            DROP PROCEDURE [dbo].[UpdateVaccine]
            END
            ";

            migrationBuilder.Sql(sp_UpdateVaccine);
        }
    }
}
