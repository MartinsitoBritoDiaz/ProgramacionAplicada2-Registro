using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPersonasBlazor.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    personaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(nullable: false),
                    telefono = table.Column<string>(maxLength: 10, nullable: false),
                    cedula = table.Column<string>(maxLength: 11, nullable: false),
                    direccion = table.Column<string>(nullable: false),
                    fechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.personaId);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "personaId", "cedula", "direccion", "fechaNacimiento", "nombre", "telefono" },
                values: new object[] { 1, "40233030523", "Nagua", new DateTime(2020, 5, 23, 17, 23, 11, 502, DateTimeKind.Local).AddTicks(1814), "Martinsito", "8098010738" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
