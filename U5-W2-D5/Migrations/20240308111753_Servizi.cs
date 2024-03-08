using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U5_W2_D5.Migrations
{
    /// <inheritdoc />
    public partial class Servizi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servizi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: true),
                    DataRichiestaServizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDPrenotazione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servizi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Servizi_Prenotazione_IDPrenotazione",
                        column: x => x.IDPrenotazione,
                        principalTable: "Prenotazione",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servizi_IDPrenotazione",
                table: "Servizi",
                column: "IDPrenotazione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servizi");
        }
    }
}
