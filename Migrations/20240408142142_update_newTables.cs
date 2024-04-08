using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AV.Migrations
{
    /// <inheritdoc />
    public partial class update_newTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positionen_Adressen_AdresseId",
                table: "Positionen");

            migrationBuilder.RenameColumn(
                name: "AdresseId",
                table: "Positionen",
                newName: "ProduktId");

            migrationBuilder.RenameIndex(
                name: "IX_Positionen_AdresseId",
                table: "Positionen",
                newName: "IX_Positionen_ProduktId");

            migrationBuilder.AddColumn<int>(
                name: "AdresseId",
                table: "Produkte",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "Auftraege",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_AdresseId",
                table: "Produkte",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Auftraege_ProduktId",
                table: "Auftraege",
                column: "ProduktId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auftraege_Produkte_ProduktId",
                table: "Auftraege",
                column: "ProduktId",
                principalTable: "Produkte",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positionen_Produkte_ProduktId",
                table: "Positionen",
                column: "ProduktId",
                principalTable: "Produkte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produkte_Adressen_AdresseId",
                table: "Produkte",
                column: "AdresseId",
                principalTable: "Adressen",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auftraege_Produkte_ProduktId",
                table: "Auftraege");

            migrationBuilder.DropForeignKey(
                name: "FK_Positionen_Produkte_ProduktId",
                table: "Positionen");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkte_Adressen_AdresseId",
                table: "Produkte");

            migrationBuilder.DropIndex(
                name: "IX_Produkte_AdresseId",
                table: "Produkte");

            migrationBuilder.DropIndex(
                name: "IX_Auftraege_ProduktId",
                table: "Auftraege");

            migrationBuilder.DropColumn(
                name: "AdresseId",
                table: "Produkte");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Auftraege");

            migrationBuilder.RenameColumn(
                name: "ProduktId",
                table: "Positionen",
                newName: "AdresseId");

            migrationBuilder.RenameIndex(
                name: "IX_Positionen_ProduktId",
                table: "Positionen",
                newName: "IX_Positionen_AdresseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positionen_Adressen_AdresseId",
                table: "Positionen",
                column: "AdresseId",
                principalTable: "Adressen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
