using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PjInmobiliaria.Domain.Entities;

namespace PjInmobiliaria.Infrastructure.Persistences.Contexts.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__Cliente__677F38F5F2FA2E8E");

            builder.ToTable("Cliente");

            builder.Property(e => e.Id).HasColumnName("id_cliente");

            builder.Property(e => e.CodigoP).HasColumnName("codigo_p");

            builder.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");

            builder.Property(e => e.Fono).HasColumnName("fono");

            builder.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_cliente");

            builder.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("region");

            builder.Property(e => e.Rut)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rut");
        }
    }
}
