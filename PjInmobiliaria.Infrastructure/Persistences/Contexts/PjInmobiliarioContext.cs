using Microsoft.EntityFrameworkCore;
using PjInmobiliaria.Domain.Entities;
using System.Reflection;

namespace PjInmobiliaria.Infrastructure.Persistences.Contexts
{
    public partial class PjInmobiliarioContext : DbContext
    {
        public PjInmobiliarioContext()
        {
        }

        public PjInmobiliarioContext(DbContextOptions<PjInmobiliarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<CondicionInmueble> CondicionInmuebles { get; set; } = null!;
        public virtual DbSet<CondicionVenta> CondicionVenta { get; set; } = null!;
        public virtual DbSet<FormaPago> FormaPagos { get; set; } = null!;
        public virtual DbSet<Inmueble> Inmuebles { get; set; } = null!;
        public virtual DbSet<Tipo> Tipos { get; set; } = null!;
        public virtual DbSet<Venta> Venta { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
