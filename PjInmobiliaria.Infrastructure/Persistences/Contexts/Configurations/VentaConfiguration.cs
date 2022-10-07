using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PjInmobiliaria.Domain.Entities;

namespace PjInmobiliaria.Infrastructure.Persistences.Contexts.Configurations
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.HasKey(e => e.IdVenta)
                     .HasName("PK__Venta__459533BF7B73140B");

            builder.Property(e => e.IdVenta).HasColumnName("id_venta");

            builder.Property(e => e.DescripcionVenta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_venta");

            builder.Property(e => e.FechaVenta)
                .HasColumnType("datetime")
                .HasColumnName("fecha_venta");

            builder.Property(e => e.IdCliente).HasColumnName("id_cliente");

            builder.Property(e => e.IdCondicion).HasColumnName("id_condicion");

            builder.Property(e => e.IdForma).HasColumnName("id_forma");

            builder.Property(e => e.IdInmueble).HasColumnName("id_inmueble");

            builder.Property(e => e.Total).HasColumnName("total");

            builder.Property(e => e.TotalIva).HasColumnName("total_iva");

            builder.Property(e => e.TotalVenta).HasColumnName("total_venta");

            builder.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.Ventas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cliente");

            builder.HasOne(d => d.IdCondicionNavigation)
                .WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCondicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_condicion_venta");

            builder.HasOne(d => d.IdFormaNavigation)
                .WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdForma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_forma_pago");

            builder.HasOne(d => d.IdInmuebleNavigation)
                .WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inmueble");
        }
    }
}
