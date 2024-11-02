using API_Mail.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Mail.Context
{
    public class CuentasContext : DbContext
    {
        public CuentasContext(DbContextOptions<CuentasContext> options)
    : base(options)
        {
        }

        public DbSet<Cuentas> cuentas { get; set; }
    }
}
