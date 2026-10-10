using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Funcoes;
using SigAguia.Domain.Membros;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class MembroFuncaoConfiguration : IEntityTypeConfiguration<MembroFuncao>
    {
        public void Configure(EntityTypeBuilder<MembroFuncao> builder)
        {
            builder.ToTable("membro_funcao");

            builder.HasKey(mf => mf.Id);

            builder.Property(mf => mf.Id)
                .HasColumnName("id");

            builder.Property(mf => mf.MembroId)
                .HasColumnName("membro_id")
                .IsRequired();

            builder.Property(mf => mf.FuncaoId)
                .HasColumnName("funcao_id")
                .IsRequired();

            builder.Property(mf => mf.DataInicio)
                .HasColumnName("data_inicio")
                .IsRequired();

            builder.Property(mf => mf.DataFim)
                .HasColumnName("data_fim");

            builder.Property(mf => mf.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(mf => mf.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();

            builder.HasOne<Membro>()
                .WithMany()
                .HasForeignKey(mf => mf.MembroId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Funcao>()
                .WithMany()
                .HasForeignKey(mf => mf.FuncaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}