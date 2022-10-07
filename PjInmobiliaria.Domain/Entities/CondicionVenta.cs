using System;
using System.Collections.Generic;

namespace PjInmobiliaria.Domain.Entities
{
    public partial class CondicionVenta
    {
        public CondicionVenta()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdCondicion { get; set; }
        public string? CondicionVenta1 { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
