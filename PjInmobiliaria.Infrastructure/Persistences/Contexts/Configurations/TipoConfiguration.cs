using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PjInmobiliaria.Domain.Entities;

namespace PjInmobiliaria.Infrastructure.Persistences.Contexts.Configurations
{
    public class TipoConfiguration : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipo__CF9010899E70FC29");

            builder.ToTable("Tipo");

            builder.Property(e => e.IdTipo).HasColumnName("id_tipo");

            builder.Property(e => e.DescripcionTipo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion_tipo");
        }
    }
}
