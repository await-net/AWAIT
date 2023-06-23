using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeleniumRecorder.Migrations
{
    /// <inheritdoc />
    public partial class testSuitReconfigure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestDescription",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "SuitId",
                table: "Suits",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Tests",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
