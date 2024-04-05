using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AV.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auftraege_Adressen_AdresseId1",
                table: "Auftraege");

            migrationBuilder.DropIndex(
                name: "IX_Auftraege_AdresseId1",
                table: "Auftraege");

            migrationBuilder.DropColumn(
                name: "AdresseId1",
                table: "Auftraege");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdresseId1",
                table: "Auftraege",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auftraege_AdresseId1",
                table: "Auftraege",
                column: "AdresseId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Auftraege_Adressen_AdresseId1",
                table: "Auftraege",
                column: "AdresseId1",
                principalTable: "Adressen",
                principalColumn: "Id");
        }
    }
}
