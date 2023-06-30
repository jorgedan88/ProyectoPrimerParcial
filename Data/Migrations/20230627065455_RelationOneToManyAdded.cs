using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PrimerParcial.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelationOneToManyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AeronaveId",
                table: "Instructor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_AeronaveId",
                table: "Instructor",
                column: "AeronaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Aeronave_AeronaveId",
                table: "Instructor",
                column: "AeronaveId",
                principalTable: "Aeronave",
                principalColumn: "AeronaveId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Aeronave_AeronaveId",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_AeronaveId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "AeronaveId",
                table: "Instructor");
        }
    }
}
