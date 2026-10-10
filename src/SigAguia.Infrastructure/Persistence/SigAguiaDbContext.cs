using Microsoft.EntityFrameworkCore;
using SigAguia.Domain.Cargos;
using SigAguia.Domain.Funcoes;
using SigAguia.Domain.Membros;
using SigAguia.Domain.Ministerios;
using SigAguia.Domain.Pessoas;
using SigAguia.Domain.Unidades;



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
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<MembroCargo> MembrosCargos { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<MembroFuncao> MembrosFuncoes { get; set; }
        public DbSet<Ministerio> Ministerios { get; set; }
        public DbSet<MembroMinisterio> MembrosMinisterios { get; set; }
        public DbSet<LiderancaMinisterio> LiderancasMinisterios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(SigAguiaDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}