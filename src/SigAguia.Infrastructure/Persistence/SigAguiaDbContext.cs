using Microsoft.EntityFrameworkCore;
using SigAguia.Domain.Pessoas;
using SigAguia.Domain.Unidades;
using SigAguia.Domain.Membros;


namespace SigAguia.Infrastructure.Persistence
{
    public class SigAguiaDbContext : DbContext
    {
        public SigAguiaDbContext(DbContextOptions<SigAguiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<MembroUnidade> MembrosUnidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(SigAguiaDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}