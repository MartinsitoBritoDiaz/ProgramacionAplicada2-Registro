﻿using System;
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

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "personaId", "balance", "cedula", "direccion", "fechaNacimiento", "nombre", "telefono" },
                values: new object[] { 1, 0.0, "40233030523", "Nagua", new DateTime(2020, 5, 29, 15, 26, 20, 751, DateTimeKind.Local).AddTicks(5804), "Martinsito", "8098010738" });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_personaId",
                table: "Prestamos",
                column: "personaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}