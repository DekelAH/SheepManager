using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class AddSheep_StoredProcedure : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_AddSheep = @"
            CREATE PROCEDURE [dbo].[AddSheep]
            (@SheepId uniqueidentifier, @TagNumber int, @Weight float, @Gender nvarchar(MAX), @Race nvarchar(MAX),
            @BloodType nvarchar(MAX), @Selection nvarchar(MAX), @Birthdate datetime2(7), @MotherTagNumber int, @FatherTagNumber int,
            @IsDead bit, @IsSold bit, @IsPregnant bit, @BirthId uniqueidentifier, @VaccineId uniqueidentifier)            
            AS BEGIN
                INSERT INTO [dbo].[Sheeps](SheepId, TagNumber, Weight, Gender, Race, BloodType, Selection, Birthdate,
                MotherTagNumber, FatherTagNumber, IsDead, IsSold, IsPregnant, BirthId, VaccineId)
                VALUES (@SheepId, @TagNumber, @Weight, @Gender, @Race, @BloodType, @Selection, @Birthdate,
                        @MotherTagNumber, @FatherTagNumber, @IsDead, @IsSold, @IsPregnant, @BirthId, @VaccineId)
            END
            ";

            migrationBuilder.Sql(sp_AddSheep);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_AddSheep = @"
            DROP PROCEDURE [dbo].[AddSheep]
            ";

            migrationBuilder.Sql(sp_AddSheep);
        }
    }
}
