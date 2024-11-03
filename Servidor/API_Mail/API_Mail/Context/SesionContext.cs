using API_Mail.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_Mail.Context
{
    public class SesionContext : DbContext
    {
        public SesionContext(DbContextOptions<SesionContext> options)
            : base(options)
        {
        }
        public DbSet<Sesion> sesion { get; set; }

        public async Task<List<Sesion>> ConsultarSesionPorEmailAsync(string email)
        {
            var emailParam = new SqlParameter("@Email", email);

            // Llama al procedimiento almacenado con FromSqlRaw
            return await sesion.FromSqlRaw("EXEC sp_ConsultaEInsertaEnSesion @Email", emailParam).ToListAsync();
        }
    }
}
