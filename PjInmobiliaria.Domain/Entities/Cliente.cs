using System;
using System.Collections.Generic;

namespace PjInmobiliaria.Domain.Entities
{
    public partial class Cliente : BaseEntity
    {
        public Cliente()
        {
            Ventas = new HashSet<Venta>();
        }

        public string NombreCliente { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Region { get; set; }
        public int? CodigoP { get; set; }
        public int? Fono { get; set; }
        public string? Rut { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
