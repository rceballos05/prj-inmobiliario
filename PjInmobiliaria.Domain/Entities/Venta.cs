using System;
using System.Collections.Generic;

namespace PjInmobiliaria.Domain.Entities
{
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public int IdInmueble { get; set; }
        public int IdCliente { get; set; }
        public int IdCondicion { get; set; }
        public int IdForma { get; set; }
        public string? DescripcionVenta { get; set; }
        public int TotalVenta { get; set; }
        public int TotalIva { get; set; }
        public int Total { get; set; }
        public DateTime? FechaVenta { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual CondicionVenta IdCondicionNavigation { get; set; } = null!;
        public virtual FormaPago IdFormaNavigation { get; set; } = null!;
        public virtual Inmueble IdInmuebleNavigation { get; set; } = null!;
    }
}
