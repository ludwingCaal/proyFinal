﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Model
{
    public class Categoria
    {

        public int CodigoCategoria { get; set; }
        public string Descripcion { get; set; }
		public virtual ICollection<Producto> Productos { get; set; }
    }
}
