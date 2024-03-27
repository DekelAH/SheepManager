using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HerdId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HerdId",
                table: "AspNetUsers");
        }
    }
}
