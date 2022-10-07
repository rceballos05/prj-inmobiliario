using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PjInmobiliaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjInmobiliaria.Infrastructure.Persistences.Contexts.Configurations
{
    public class CondicionVentaConfiguration : IEntityTypeConfiguration<CondicionVenta>
    {
        public void Configure(EntityTypeBuilder<CondicionVenta> builder)
        {
            builder.HasKey(e => e.IdCondicion)
                    .HasName("PK__Condicio__C92374003627E8DD");

            builder.ToTable("Condicion_Venta");

            builder.Property(e => e.IdCondicion).HasColumnName("id_condicion");

            builder.Property(e => e.CondicionVenta1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("condicion_venta");
        }
    }
}
