using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigAguia.Domain.Cargos;
using SigAguia.Domain.Membros;

namespace SigAguia.Infrastructure.Persistence.Configurations
{
    public class MembroCargoConfiguration : IEntityTypeConfiguration<MembroCargo>
    {
        public void Configure(EntityTypeBuilder<MembroCargo> builder)
        {
            builder.ToTable("membro_cargo");

            builder.HasKey(mc => mc.Id);

            builder.Property(mc => mc.Id)
                .HasColumnName("id");

            builder.Property(mc => mc.MembroId)
                .HasColumnName("membro_id")
                .IsRequired();

            builder.Property(mc => mc.CargoId)
                .HasColumnName("cargo_id")
                .IsRequired();

            builder.Property(mc => mc.DataInicio)
                .HasColumnName("data_inicio")
                .IsRequired();

            builder.Property(mc => mc.DataFim)
                .HasColumnName("data_fim");

            builder.Property(mc => mc.CriadoEm)
                .HasColumnName("criado_em")
                .IsRequired();

            builder.Property(mc => mc.AtualizadoEm)
                .HasColumnName("atualizado_em")
                .IsRequired();

            builder.HasOne<Membro>()
                .WithMany()
                .HasForeignKey(mc => mc.MembroId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Cargo>()
                .WithMany()
                .HasForeignKey(mc => mc.CargoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}