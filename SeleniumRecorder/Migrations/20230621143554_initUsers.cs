using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeleniumRecorder.Migrations
{
    /// <inheritdoc />
    public partial class initUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Suits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suits_UserId",
                table: "Suits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suits_Users_UserId",
                table: "Suits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suits_Users_UserId",
                table: "Suits");

            migrationBuilder.DropIndex(
                name: "IX_Suits_UserId",
                table: "Suits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Suits");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
