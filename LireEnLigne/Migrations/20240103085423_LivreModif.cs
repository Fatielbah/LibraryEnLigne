using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LireEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class LivreModif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Livre",
                keyColumn: "Genre",
                keyValue: null,
                column: "Genre",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Livre",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Livre",
                type: "longblob",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Livre");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Livre",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
