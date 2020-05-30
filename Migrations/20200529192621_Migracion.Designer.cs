﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPersonasBlazor.DAL;

namespace ProyectoPersonasBlazor.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200529192621_Migracion")]
    partial class Migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("ProyectoPersonasBlazor.Models.Personas", b =>
                {
                    b.Property<int>("personaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("balance")
                        .HasColumnType("REAL");

                    b.Property<string>("cedula")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("personaId");

                    b.ToTable("Personas");

                    b.HasData(
                        new
                        {
                            personaId = 1,
                            balance = 0.0,
                            cedula = "40233030523",
                            direccion = "Nagua",
                            fechaNacimiento = new DateTime(2020, 5, 29, 15, 26, 20, 751, DateTimeKind.Local).AddTicks(5804),
                            nombre = "Martinsito",
                            telefono = "8098010738"
                        });
                });

            modelBuilder.Entity("ProyectoPersonasBlazor.Models.Prestamos", b =>
                {
                    b.Property<int>("prestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("balance")
                        .HasColumnType("REAL");

                    b.Property<string>("concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("monto")
                        .HasColumnType("REAL");

                    b.Property<int>("personaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("prestamoId");

                    b.HasIndex("personaId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("ProyectoPersonasBlazor.Models.Prestamos", b =>
                {
                    b.HasOne("ProyectoPersonasBlazor.Models.Personas", "Persona")
                        .WithMany()
                        .HasForeignKey("personaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}