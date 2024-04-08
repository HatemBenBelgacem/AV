using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AV.Migrations
{
    /// <inheritdoc />
    public partial class modelProduktundPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Auftraege_AdresseId",
                table: "Auftraege");

            migrationBuilder.CreateTable(
                name: "Positionen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuftragId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdresseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positionen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positionen_Adressen_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adressen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Positionen_Auftraege_AuftragId",
                        column: x => x.AuftragId,
                        principalTable: "Auftraege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produkte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkte", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auftraege_AdresseId",
                table: "Auftraege",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Positionen_AdresseId",
                table: "Positionen",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Positionen_AuftragId",
                table: "Positionen",
                column: "AuftragId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positionen");

            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropIndex(
                name: "IX_Auftraege_AdresseId",
                table: "Auftraege");

            migrationBuilder.CreateIndex(
                name: "IX_Auftraege_AdresseId",
                table: "Auftraege",
                column: "AdresseId",
                unique: true);
        }
    }
}
