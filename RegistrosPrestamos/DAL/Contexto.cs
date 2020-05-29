using Microsoft.EntityFrameworkCore;
using RegistrosPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrosPrestamos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= C:\Users\olive\Datos de proyectos\PrestamosControl.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasData(new Persona
            {
                PersonaId = 1,
                Nombre = "Oliver",
                Direccion = "Castillo",
                Cedula = "000-0000000-0",
                Telefono = "809-584-0662",
                Nacimiento = DateTime.Now,
                Balance = 0.0
            });

            modelBuilder.Entity<Prestamo>().HasData(new Prestamo
            {
                PrestamoId = 1,
                PersonaId = 1,
                Fecha = DateTime.Now,
                Concepto = " ",
                Monto = 0.00,
                Balance = 0
            });
        }
    }
}
