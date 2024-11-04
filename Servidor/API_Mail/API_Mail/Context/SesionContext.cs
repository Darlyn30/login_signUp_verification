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

        /*
        esta funcion se encarga de ejecutar el SP, que inserta los datos en la tabla sesion
        para controlar la sesion con la cuenta que esta iniciada, no debe permitir 2 sesiones al mismo tiempo
        almenos desde el mismo pc, aunque esta en local y no es algo 'profesional'
         
        */
        public async Task<List<Sesion>> ConsultarSesionPorEmailAsync(string email)
        {
            var emailParam = new SqlParameter("@Email", email);

            // Llama al procedimiento almacenado con FromSqlRaw
            return await sesion.FromSqlRaw("EXEC sp_ConsultaEInsertaEnSesion @Email", emailParam).ToListAsync();
        }
    }
}
