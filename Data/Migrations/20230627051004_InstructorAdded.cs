using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PrimerParcial.Data.Migrations
{
    /// <inheritdoc />
    public partial class InstructorAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InstructorNombre = table.Column<string>(type: "TEXT", nullable: true),
                    InstructorApellido = table.Column<string>(type: "TEXT", nullable: true),
                    InstructorDni = table.Column<int>(type: "INTEGER", nullable: false),
                    InstructorTipoLicencia = table.Column<int>(type: "INTEGER", nullable: false),
                    InstructorNumeroLicencia = table.Column<int>(type: "INTEGER", nullable: false),
                    InstructorExpedicion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InstructorEnActividad = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructor");
        }
    }
}
