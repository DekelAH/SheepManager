using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetAllHerds_StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllHerds = @"
            CREATE PROCEDURE [dbo].[GetAllHerds]
            AS BEGIN
            SELECT HerdId, HerdName
            FROM [dbo].[Herds]
            END
            ";

            migrationBuilder.Sql(sp_GetAllHerds);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllHerds = @"
            DROP PROCEDURE [dbo].[GetAllHerds]
            ";

            migrationBuilder.Sql(sp_GetAllHerds);
        }
    }
}
