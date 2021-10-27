using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week7.Master.RepositoryEF.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corso",
                columns: table => new
                {
                    CorsoCodice = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corso", x => x.CorsoCodice);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitoloStudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorsoCodice = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Studente_Corso_CorsoCodice",
                        column: x => x.CorsoCodice,
                        principalTable: "Corso",
                        principalColumn: "CorsoCodice",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lezione",
                columns: table => new
                {
                    LezioneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Aula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocenteID = table.Column<int>(type: "int", nullable: false),
                    CorsoCodice = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezione", x => x.LezioneID);
                    table.ForeignKey(
                        name: "FK_Lezione_Corso_CorsoCodice",
                        column: x => x.CorsoCodice,
                        principalTable: "Corso",
                        principalColumn: "CorsoCodice",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lezione_Docente_DocenteID",
                        column: x => x.DocenteID,
                        principalTable: "Docente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lezione_CorsoCodice",
                table: "Lezione",
                column: "CorsoCodice");

            migrationBuilder.CreateIndex(
                name: "IX_Lezione_DocenteID",
                table: "Lezione",
                column: "DocenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Studente_CorsoCodice",
                table: "Studente",
                column: "CorsoCodice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lezione");

            migrationBuilder.DropTable(
                name: "Studente");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Corso");
        }
    }
}
