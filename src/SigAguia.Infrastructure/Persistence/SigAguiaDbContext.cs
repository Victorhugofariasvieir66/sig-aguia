using Microsoft.EntityFrameworkCore;
using SigAguia.Domain.Pessoas;

namespace SigAguia.Infrastructure.Persistence
{
    public class SigAguiaDbContext : DbContext
    {
        public SigAguiaDbContext(DbContextOptions<SigAguiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(SigAguiaDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}