using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PjInmobiliaria.Domain.Entities;

namespace PjInmobiliaria.Infrastructure.Persistences.Contexts.Configurations
{
    public class CondicionInmuebleConfiguration : IEntityTypeConfiguration<CondicionInmueble>
    {
        public void Configure(EntityTypeBuilder<CondicionInmueble> builder)
        {
            builder.HasKey(e => e.IdCondicionInmueble)
                    .HasName("PK__Condicio__43E848AF8C793D05");

            builder.ToTable("Condicion_Inmueble");

            builder.Property(e => e.IdCondicionInmueble).HasColumnName("id_condicion_inmueble");

            builder.Property(e => e.Condicion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("condicion");
        }
    }
}
