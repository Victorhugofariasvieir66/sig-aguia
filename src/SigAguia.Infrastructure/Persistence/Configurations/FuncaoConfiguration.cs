using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Funcoes;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class FuncaoConfiguration : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.ToTable("funcao");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("id");

            builder.Property(f => f.Nome)
                .HasColumnName("nome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(500);

            builder.Property(f => f.Ativa)
                .HasColumnName("ativa")
                .IsRequired();

            builder.Property(f => f.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(f => f.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();
        }
    }
}