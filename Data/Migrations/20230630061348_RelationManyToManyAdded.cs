using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PrimerParcial.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelationManyToManyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangarPista",
                columns: table => new
                {
                    HangarsHangarId = table.Column<int>(type: "INTEGER", nullable: false),
                    PistasPistaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangarPista", x => new { x.HangarsHangarId, x.PistasPistaId });
                    table.ForeignKey(
                        name: "FK_HangarPista_Hangar_HangarsHangarId",
                        column: x => x.HangarsHangarId,
                        principalTable: "Hangar",
                        principalColumn: "HangarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HangarPista_Pista_PistasPistaId",
                        column: x => x.PistasPistaId,
                        principalTable: "Pista",
                        principalColumn: "PistaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangarPista_PistasPistaId",
                table: "HangarPista",
                column: "PistasPistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangarPista");
        }
    }
}
