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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trigger>()
                .ToTable(tb => tb.HasTrigger("changeEstatus"));
        }
    }
}
