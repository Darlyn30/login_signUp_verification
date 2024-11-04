using API_Mail.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API_Mail.Context
{
    public class CuentasContext : DbContext
    {
        public CuentasContext(DbContextOptions<CuentasContext> options)
    : base(options)
        {
        }

        public DbSet<Cuentas> cuentas { get; set; }

        //esto ejecuta un trigger, que almacena el pin que recibe esa cuenta por correo, para poder verificarlo
        // al verificar que el pin es correcto, todo lo que se almaceno a traves de este trigger, es eliminado
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuentas>()
                .ToTable(tb => tb.HasTrigger("almacenarPin"));
        }


    }
}
