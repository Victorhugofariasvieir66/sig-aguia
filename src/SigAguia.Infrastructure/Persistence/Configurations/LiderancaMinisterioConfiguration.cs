using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Membros;
using SigAguia.Domain.Ministerios;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class LiderancaMinisterioConfiguration
        : IEntityTypeConfiguration<LiderancaMinisterio>
    {
        public void Configure(EntityTypeBuilder<LiderancaMinisterio> builder)
        {
            builder.ToTable("lideranca_ministerio");

            builder.HasKey(lm => lm.Id);

            builder.Property(lm => lm.Id)
                .HasColumnName("id");

            builder.Property(lm => lm.MinisterioId)
                .HasColumnName("ministerio_id")
                .IsRequired();

            builder.Property(lm => lm.MembroId)
                .HasColumnName("membro_id")
                .IsRequired();

            builder.Property(lm => lm.TipoLideranca)
                .HasColumnName("tipo_lideranca")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(lm => lm.DataInicio)
                .HasColumnName("data_inicio")
                .IsRequired();

            builder.Property(lm => lm.DataFim)
                .HasColumnName("data_fim");

            builder.Property(lm => lm.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(lm => lm.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();

            builder.HasOne<Ministerio>()
                .WithMany()
                .HasForeignKey(lm => lm.MinisterioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Membro>()
                .WithMany()
                .HasForeignKey(lm => lm.MembroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}