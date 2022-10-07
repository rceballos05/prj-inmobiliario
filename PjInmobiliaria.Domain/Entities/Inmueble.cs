using System;
using System.Collections.Generic;

namespace PjInmobiliaria.Domain.Entities
{
    public partial class Inmueble : BaseEntity
    {
        public Inmueble()
        {
            Venta = new HashSet<Venta>();
        }
        public int IdTipo { get; set; }
        public int IdCondicion { get; set; }
        public string DescripcionInmueble { get; set; } = null!;
        public int? ValorInmueble { get; set; }
        public string TipoDivisa { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;

        public virtual CondicionInmueble IdCondicionNavigation { get; set; } = null!;
        public virtual Tipo IdTipoNavigation { get; set; } = null!;
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
