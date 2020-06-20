using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPersonasBlazor.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moras",
                columns: table => new
                {
                    moraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moras", x => x.moraId);
                });

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
                    balance = table.Column<double>(nullable: false),
                    fechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.personaId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    prestamoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    concepto = table.Column<string>(nullable: false),
                    monto = table.Column<double>(nullable: false),
                    balance = table.Column<double>(nullable: false),
                    personaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.prestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Personas_personaId",
                        column: x => x.personaId,
                        principalTable: "Personas",
                        principalColumn: "personaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MorasDetalle",
                columns: table => new
                {
                    morasDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    moraId = table.Column<int>(nullable: false),
                    prestamoId = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MorasDetalle", x => x.morasDetalleId);
                    table.ForeignKey(
                        name: "FK_MorasDetalle_Prestamos_prestamoId",
                        column: x => x.prestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "prestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Moras",
                columns: new[] { "moraId", "fecha", "total" },
                values: new object[] { 1, new DateTime(2020, 6, 19, 22, 45, 38, 735, DateTimeKind.Local).AddTicks(4465), 1000.0 });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "personaId", "balance", "cedula", "direccion", "fechaNacimiento", "nombre", "telefono" },
                values: new object[] { 1, 0.0, "40233030523", "Nagua", new DateTime(2020, 6, 19, 22, 45, 38, 732, DateTimeKind.Local).AddTicks(8274), "Martinsito", "8098010738" });

            migrationBuilder.CreateIndex(
                name: "IX_MorasDetalle_prestamoId",
                table: "MorasDetalle",
                column: "prestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_personaId",
                table: "Prestamos",
                column: "personaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moras");

            migrationBuilder.DropTable(
                name: "MorasDetalle");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
