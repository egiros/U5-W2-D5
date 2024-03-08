using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U5_W2_D5.Migrations
{
    /// <inheritdoc />
    public partial class Prenotazione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenotazione",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrenotazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInizioSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFineSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acconto = table.Column<double>(type: "float", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDCamera = table.Column<int>(type: "int", nullable: false),
                    IDPensione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazione", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Camera_IDCamera",
                        column: x => x.IDCamera,
                        principalTable: "Camera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Clienti_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clienti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Pensione_IDPensione",
                        column: x => x.IDPensione,
                        principalTable: "Pensione",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IDCamera",
                table: "Prenotazione",
                column: "IDCamera");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IDCliente",
                table: "Prenotazione",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IDPensione",
                table: "Prenotazione",
                column: "IDPensione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazione");
        }
    }
}
