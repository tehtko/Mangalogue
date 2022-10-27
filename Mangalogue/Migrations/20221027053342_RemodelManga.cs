using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mangalogue.Migrations
{
    public partial class RemodelManga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.RenameColumn(
                name: "salt",
                table: "Users",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Page",
                table: "Chapter",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "Chapter");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Users",
                newName: "salt");

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Page_ChapterId",
                table: "Page",
                column: "ChapterId");
        }
    }
}
