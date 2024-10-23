using LogicaDeNegocios.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios;
        public Contexto(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(u => u.HasKey(u => u.Id));
          
            base.OnModelCreating(modelBuilder);
        }
    }
}
