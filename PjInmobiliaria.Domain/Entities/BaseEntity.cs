﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjInmobiliaria.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int Estado { get; set; }
    }
}
