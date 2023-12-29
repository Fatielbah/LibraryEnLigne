using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LireEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Livre",
                columns: table => new
                {
                    LivreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Isbn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Titre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NbreExemplaire = table.Column<int>(type: "int", nullable: false),
                    NbrePages = table.Column<int>(type: "int", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Resume = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livre", x => x.LivreID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroTelephone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Exemplaire",
                columns: table => new
                {
                    ExemplaireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Edition = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Langue = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    LivreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemplaire", x => x.ExemplaireID);
                    table.ForeignKey(
                        name: "FK_Exemplaire_Livre_LivreID",
                        column: x => x.LivreID,
                        principalTable: "Livre",
                        principalColumn: "LivreID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Emprunt",
                columns: table => new
                {
                    EmpruntID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateEmprunt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateRetourPrevue = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    dateRetourEffective = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ExemplaireID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprunt", x => x.EmpruntID);
                    table.ForeignKey(
                        name: "FK_Emprunt_Exemplaire_ExemplaireID",
                        column: x => x.ExemplaireID,
                        principalTable: "Exemplaire",
                        principalColumn: "ExemplaireID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprunt_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateDemande = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateAnnulation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExemplaireID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservation_Exemplaire_ExemplaireID",
                        column: x => x.ExemplaireID,
                        principalTable: "Exemplaire",
                        principalColumn: "ExemplaireID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunt_ExemplaireID",
                table: "Emprunt",
                column: "ExemplaireID");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunt_UserID",
                table: "Emprunt",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Exemplaire_LivreID",
                table: "Exemplaire",
                column: "LivreID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ExemplaireID",
                table: "Reservation",
                column: "ExemplaireID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserID",
                table: "Reservation",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprunt");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Exemplaire");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Livre");
        }
    }
}
