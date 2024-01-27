using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    public partial class AddHerd_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_AddHerd = @"
            CREATE PROCEDURE [dbo].[AddHerd]
            (@HerdId UNIQUEIDENTIFIER, @HerdName NVARCHAR (MAX))            
            AS BEGIN
                INSERT INTO [dbo].[Herds](HerdId, HerdName)
                VALUES (@HerdId, @HerdName)
            END
            ";

            migrationBuilder.Sql(sp_AddHerd);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_AddHerd = @"
            DROP PROCEDURE [dbo].[AddHerd]
            ";

            migrationBuilder.Sql(sp_AddHerd);
        }
    }
}
