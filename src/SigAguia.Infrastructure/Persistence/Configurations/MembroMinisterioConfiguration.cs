using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Membros;
using SigAguia.Domain.Ministerios;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class MembroMinisterioConfiguration
        : IEntityTypeConfiguration<MembroMinisterio>
    {
        public void Configure(EntityTypeBuilder<MembroMinisterio> builder)
        {
            builder.ToTable("membro_ministerio");

            builder.HasKey(mm => mm.Id);

            builder.Property(mm => mm.Id)
                .HasColumnName("id");

            builder.Property(mm => mm.MembroId)
                .HasColumnName("membro_id")
                .IsRequired();

            builder.Property(mm => mm.MinisterioId)
                .HasColumnName("ministerio_id")
                .IsRequired();

            builder.Property(mm => mm.DataInicio)
                .HasColumnName("data_inicio")
                .IsRequired();

            builder.Property(mm => mm.DataFim)
                .HasColumnName("data_fim");

            builder.Property(mm => mm.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(mm => mm.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();

            builder.HasOne<Membro>()
                .WithMany()
                .HasForeignKey(mm => mm.MembroId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Ministerio>()
                .WithMany()
                .HasForeignKey(mm => mm.MinisterioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}