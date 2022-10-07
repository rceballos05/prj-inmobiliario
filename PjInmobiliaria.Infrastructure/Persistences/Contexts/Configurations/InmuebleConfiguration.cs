using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PjInmobiliaria.Domain.Entities;

namespace PjInmobiliaria.Infrastructure.Persistences.Contexts.Configurations
{
    public class InmuebleConfiguration : IEntityTypeConfiguration<Inmueble>
    {
        public void Configure(EntityTypeBuilder<Inmueble> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__Inmueble__82C5A28286B2D1D6");

            builder.ToTable("Inmueble");

            builder.Property(e => e.Id).HasColumnName("id_inmueble");

            builder.Property(e => e.DescripcionInmueble)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_inmueble");

            builder.Property(e => e.IdCondicion).HasColumnName("id_condicion");

            builder.Property(e => e.IdTipo).HasColumnName("id_tipo");

            builder.Property(e => e.TipoDivisa)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tipo_divisa");

            builder.Property(e => e.Ubicacion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            builder.Property(e => e.ValorInmueble).HasColumnName("valor_inmueble");

            builder.HasOne(d => d.IdCondicionNavigation)
                .WithMany(p => p.Inmuebles)
                .HasForeignKey(d => d.IdCondicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_condicion_inmueble");

            builder.HasOne(d => d.IdTipoNavigation)
                .WithMany(p => p.Inmuebles)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipo");
        }
    }
}
