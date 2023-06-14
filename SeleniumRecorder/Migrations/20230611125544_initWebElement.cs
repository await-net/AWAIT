using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeleniumRecorder.Migrations
{
    /// <inheritdoc />
    public partial class initWebElement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementXPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementCSSPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementWindowLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebElements", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebElements");
        }
    }
}
