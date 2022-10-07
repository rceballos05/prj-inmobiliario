using System;
using System.Collections.Generic;

namespace PjInmobiliaria.Domain.Entities
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdForma { get; set; }
        public string? FormaPago1 { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
