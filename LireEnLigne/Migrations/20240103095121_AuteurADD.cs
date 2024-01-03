using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LireEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class AuteurADD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuteurID",
                table: "Livre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Auteur",
                columns: table => new
                {
                    AuteurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuteurName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resume = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteur", x => x.AuteurID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Livre_AuteurID",
                table: "Livre",
                column: "AuteurID");

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Auteur_AuteurID",
                table: "Livre",
                column: "AuteurID",
                principalTable: "Auteur",
                principalColumn: "AuteurID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Auteur_AuteurID",
                table: "Livre");

            migrationBuilder.DropTable(
                name: "Auteur");

            migrationBuilder.DropIndex(
                name: "IX_Livre_AuteurID",
                table: "Livre");

            migrationBuilder.DropColumn(
                name: "AuteurID",
                table: "Livre");
        }
    }
}
