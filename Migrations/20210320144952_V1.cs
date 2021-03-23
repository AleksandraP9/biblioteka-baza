using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerProj.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biblioteka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivBiblioteke = table.Column<string>(name: "Naziv Biblioteke", type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Polica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePolice = table.Column<string>(name: "Ime Police", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaksimalniBrKnjiga = table.Column<int>(type: "int", nullable: false),
                    BibliotekaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Polica_Biblioteka_BibliotekaID",
                        column: x => x.BibliotekaID,
                        principalTable: "Biblioteka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKnjige = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImeAutora = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BojaKnjige = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Knjiga_Polica_PolicaID",
                        column: x => x.PolicaID,
                        principalTable: "Polica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_PolicaID",
                table: "Knjiga",
                column: "PolicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Polica_BibliotekaID",
                table: "Polica",
                column: "BibliotekaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Knjiga");

            migrationBuilder.DropTable(
                name: "Polica");

            migrationBuilder.DropTable(
                name: "Biblioteka");
        }
    }
}
