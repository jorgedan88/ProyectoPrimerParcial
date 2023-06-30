using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PrimerParcial.Data.Migrations
{
    /// <inheritdoc />
    public partial class HangarAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hangar",
                columns: table => new
                {
                    HangarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HangarNombre = table.Column<string>(type: "TEXT", nullable: true),
                    HangarSector = table.Column<int>(type: "INTEGER", nullable: false),
                    HangarAptoMantenimiento = table.Column<bool>(type: "INTEGER", nullable: false),
                    HangarOficinas = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangar", x => x.HangarId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hangar");
        }
    }
}
