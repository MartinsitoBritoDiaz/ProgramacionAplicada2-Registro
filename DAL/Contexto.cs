using Microsoft.EntityFrameworkCore;
using ProyectoPersonasBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPersonasBlazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Persona.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>().HasData(new Personas
            {
                personaId = 1,
                nombre = "Martinsito",
                telefono = "8098010738",
                cedula = "40233030523",
                direccion = "Nagua",
                fechaNacimiento = DateTime.Now
            });
        }
    }
}
