﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class UpdateSheep_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_UpdateSheep = @"
            CREATE PROCEDURE [dbo].[UpdateSheep]
            (@SheepId uniqueidentifier, @TagNumber bigint, @Weight float, @Gender nvarchar(MAX), @Race nvarchar(MAX),
            @BloodType nvarchar(MAX), @Selection nvarchar(MAX), @Birthdate datetime2(7), @MotherTagNumber bigint, @FatherTagNumber bigint,
            @IsDead bit, @IsSold bit, @IsPregnant bit, @BirthId uniqueidentifier, @VaccineId uniqueidentifier)            
            AS BEGIN
                WHERE SheepId = @SheepId;

                UPDATE [dbo].[Sheeps]
                SET 
                TagNumber = @TagNumber, 
                Weight = @Weight, 
                Gender = @Gender, 
                Race = @Race, 
                BloodType = @BloodType, 
                Selection = @Selection, 
                Birthdate = @Birthdate,
                MotherTagNumber = @MotherTagNumber, 
                FatherTagNumber = @FatherTagNumber, 
                IsDead = @IsDead, 
                IsSold = @IsSold, 
                IsPregnant = @IsPregnant, 
                BirthId = @BirthId, 
                VaccineId = @VaccineId
                
            END
            ";

            migrationBuilder.Sql(sp_UpdateSheep);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_UpdateSheep = @"
            DROP PROCEDURE [dbo].[UpdateSheep]
            END
            ";

            migrationBuilder.Sql(sp_UpdateSheep);
        }
    }
}
