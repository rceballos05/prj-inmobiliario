using System;
using System.Collections.Generic;

namespace PjInmobiliaria.Domain.Entities
{
    public partial class CondicionInmueble
    {
        public CondicionInmueble()
        {
            Inmuebles = new HashSet<Inmueble>();
        }

        public int IdCondicionInmueble { get; set; }
        public string? Condicion { get; set; }

        public virtual ICollection<Inmueble> Inmuebles { get; set; }
    }
}
