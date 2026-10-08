using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Membros;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class MembroUnidadeConfiguration : IEntityTypeConfiguration<MembroUnidade>
    {
        public void Configure(EntityTypeBuilder<MembroUnidade> builder)
        {
            builder.ToTable("membro_unidade");

            builder.HasKey(mu => mu.Id);

            builder.Property(mu => mu.Id)
                .HasColumnName("id");

            builder.Property(mu => mu.MembroId)
                .HasColumnName("membro_id")
                .IsRequired();

            builder.Property(mu => mu.UnidadeId)
                .HasColumnName("unidade_id")
                .IsRequired();

            builder.Property(mu => mu.TipoVinculo)
                .HasColumnName("tipo_vinculo")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(mu => mu.DataInicio)
                .HasColumnName("data_inicio")
                .IsRequired();

            builder.Property(mu => mu.DataFim)
                .HasColumnName("data_fim");

            builder.Property(mu => mu.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(mu => mu.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();

            builder.HasOne<Membro>()
                .WithMany()
                .HasForeignKey(mu => mu.MembroId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<SigAguia.Domain.Unidades.Unidade>()
                .WithMany()
                .HasForeignKey(mu => mu.UnidadeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(mu => mu.MembroId)
                .IsUnique()
                .HasFilter("data_fim IS NULL AND tipo_vinculo = 'Principal'");
        }
    }
}