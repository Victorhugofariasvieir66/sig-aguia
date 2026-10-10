using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Ministerios;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class MinisterioConfiguration : IEntityTypeConfiguration<Ministerio>
    {
        public void Configure(EntityTypeBuilder<Ministerio> builder)
        {
            builder.ToTable("ministerio");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id");

            builder.Property(m => m.Nome)
                .HasColumnName("nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(m => m.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(500);

            builder.Property(m => m.Ativo)
                .HasColumnName("ativo")
                .IsRequired();

            builder.Property(m => m.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(m => m.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();
        }
    }
}