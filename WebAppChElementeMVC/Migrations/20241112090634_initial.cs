using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChElementeMVC.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gruppe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gruppe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zustand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zustand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GruppeId = table.Column<int>(type: "int", nullable: false),
                    PeriodeId = table.Column<int>(type: "int", nullable: false),
                    ZustandId = table.Column<int>(type: "int", nullable: false),
                    Ordnungszahl = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Element_Gruppe_GruppeId",
                        column: x => x.GruppeId,
                        principalTable: "Gruppe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Periode_PeriodeId",
                        column: x => x.PeriodeId,
                        principalTable: "Periode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Zustand_ZustandId",
                        column: x => x.ZustandId,
                        principalTable: "Zustand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Element_GruppeId",
                table: "Element",
                column: "GruppeId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_PeriodeId",
                table: "Element",
                column: "PeriodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_ZustandId",
                table: "Element",
                column: "ZustandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Gruppe");

            migrationBuilder.DropTable(
                name: "Periode");

            migrationBuilder.DropTable(
                name: "Zustand");
        }
    }
}
