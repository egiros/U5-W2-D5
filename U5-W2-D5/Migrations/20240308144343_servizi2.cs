using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U5_W2_D5.Migrations
{
    /// <inheritdoc />
    public partial class servizi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Descrizione",
                table: "Servizi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CheckoutViewModel",
                columns: table => new
                {
                    PrenotazioneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CheckoutViewModel_Prenotazione_PrenotazioneID",
                        column: x => x.PrenotazioneID,
                        principalTable: "Prenotazione",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutViewModel_PrenotazioneID",
                table: "CheckoutViewModel",
                column: "PrenotazioneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Servizi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
