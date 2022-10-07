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
    public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
    {
        public void Configure(EntityTypeBuilder<FormaPago> builder)
        {
            builder.HasKey(e => e.IdForma)
                    .HasName("PK__Forma_Pa__A8D6EBFE430E0BF1");

            builder.ToTable("Forma_Pago");

            builder.Property(e => e.IdForma).HasColumnName("id_forma");

            builder.Property(e => e.FormaPago1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("forma_pago");
        }
    }
}
