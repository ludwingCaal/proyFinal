﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Model
{
	public class DetalleCompra
	{
		public int IdDetalle { get; set; }
		public int IdCompra { get; set; }
		public int CodigoProducto { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public virtual Producto Producto { get; set; }
		public virtual Compra Compra { get; set; }

	}
}
