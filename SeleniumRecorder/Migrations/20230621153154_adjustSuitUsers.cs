using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeleniumRecorder.Migrations
{
    /// <inheritdoc />
    public partial class adjustSuitUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Suits",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Suits");

            migrationBuilder.AddColumn<string>(
                name: "SuitOwnerId",
                table: "Suits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuitOwnerUsername",
                table: "Suits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
