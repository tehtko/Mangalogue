using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mangalogue.Migrations
{
    public partial class ForeignKeyConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Users_AuthorId",
                table: "Mangas");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Mangas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Users_AuthorId",
                table: "Mangas",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Users_AuthorId",
                table: "Mangas");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Mangas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Users_AuthorId",
                table: "Mangas",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
