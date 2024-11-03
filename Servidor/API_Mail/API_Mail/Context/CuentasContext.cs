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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuentas>()
                .ToTable(tb => tb.HasTrigger("almacenarPin"));
        }


    }
}
