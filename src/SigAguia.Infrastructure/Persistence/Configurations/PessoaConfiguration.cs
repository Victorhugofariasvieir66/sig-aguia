using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Pessoas;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.NomeCompleto)
                .HasColumnName("nome_completo")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("data_nascimento");

            builder.Property(p => p.Telefone)
                .HasColumnName("telefone")
                .HasMaxLength(30);

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasMaxLength(254);

            builder.Property(p => p.EstadoCivil)
                .HasColumnName("estado_civil")
                .HasMaxLength(30);

            builder.Property(p => p.FotoArquivoId)
                .HasColumnName("foto_arquivo_id");

            builder.Property(p => p.CriadoEm)
                .HasColumnName("criado_em");

            builder.Property(p => p.AtualizadoEm)
                .HasColumnName("atualizado_em");
        }
    }
}