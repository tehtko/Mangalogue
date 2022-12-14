using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mangalogue.Migrations
{
    public partial class RatingAndViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Mangas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Mangas",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Mangas");
        }
    }
}
