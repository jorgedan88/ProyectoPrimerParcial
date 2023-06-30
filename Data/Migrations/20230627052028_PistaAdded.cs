using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PrimerParcial.Data.Migrations
{
    /// <inheritdoc />
    public partial class PistaAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pista",
                columns: table => new
                {
                    PistaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PistaNombre = table.Column<string>(type: "TEXT", nullable: true),
                    PistaCapacidad = table.Column<int>(type: "INTEGER", nullable: false),
                    PistaIluminacion = table.Column<bool>(type: "INTEGER", nullable: false),
                    PistaAprovisionamiento = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pista", x => x.PistaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pista");
        }
    }
}
