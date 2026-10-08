using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Unidades;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable("unidade");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Nome)
                .HasColumnName("nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.EhMatriz)
                .HasColumnName("eh_matriz")
                .IsRequired();

            builder.Property(u => u.Ativa)
                .HasColumnName("ativa")
                .IsRequired();

            builder.Property(u => u.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(u => u.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();

            builder.HasIndex(u => u.EhMatriz)
                .IsUnique()
                .HasFilter("eh_matriz = true");
        }
    }
}