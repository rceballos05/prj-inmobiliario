using System;
using System.Collections.Generic;

namespace PjInmobiliaria.Domain.Entities
{
    public partial class Tipo
    {
        public Tipo()
        {
            Inmuebles = new HashSet<Inmueble>();
        }

        public int IdTipo { get; set; }
        public string? DescripcionTipo { get; set; }

        public virtual ICollection<Inmueble> Inmuebles { get; set; }
    }
}
