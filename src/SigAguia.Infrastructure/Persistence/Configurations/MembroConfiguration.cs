using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Membros;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class MembroConfiguration : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.ToTable("membro");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id");

            builder.Property(m => m.PessoaId)
                .HasColumnName("pessoa_id")
                .IsRequired();

            builder.Property(m => m.DataIngresso)
                .HasColumnName("data_ingresso");

            builder.Property(m => m.Situacao)
                .HasColumnName("situacao")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(m => m.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(m => m.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();

            builder.HasOne<SigAguia.Domain.Pessoas.Pessoa>()
                .WithOne()
                .HasForeignKey<Membro>(m => m.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}