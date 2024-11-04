using API_Mail.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Mail.Context
{
    public class TriggerContext : DbContext
    {
        public TriggerContext(DbContextOptions<TriggerContext> options)
            : base(options)
        {
        }
        public DbSet<Trigger> cuenta_creadas { get; set; }
        /*
        en esta funcion lo que ejecuta el trigger, al ingresar el codigo de virificacion que llega al correo de la cuenta
        cuando creas la cuenta, el campo de estatus, por default es falso, pero a traves de este trigger al "verificar"
        la cuenta, cambia el estatus a verdadero, osea activo
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trigger>()
                .ToTable(tb => tb.HasTrigger("changeEstatus"));
        }
    }
}
