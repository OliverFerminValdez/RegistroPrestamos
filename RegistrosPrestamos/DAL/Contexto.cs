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
            optionsBuilder.UseSqlite(@"Data Source= DATA\PrestamosControl.db");
        }
        
    }
}
