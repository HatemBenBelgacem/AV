using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AV.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auftraege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Beschreibung = table.Column<string>(type: "TEXT", nullable: true),
                    AdresseId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdresseId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auftraege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auftraege_Adressen_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adressen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auftraege_Adressen_AdresseId1",
                        column: x => x.AdresseId1,
                        principalTable: "Adressen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auftraege_AdresseId",
                table: "Auftraege",
                column: "AdresseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auftraege_AdresseId1",
                table: "Auftraege",
                column: "AdresseId1",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auftraege");

            migrationBuilder.DropTable(
                name: "Adressen");
        }
    }
}
