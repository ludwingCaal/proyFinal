using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Model
{
	public class DetalleFactura
	{
		public int CodigoDetalle { get; set; }
		public int NumeroFactura { get; set; }
		public int CodigoProducto { get; set; }
		public int Cantidad { get; set; }
		public Decimal Precio { get; set; }
		public Decimal Descuento { get; set; }
		public virtual Producto Producto { get; set; }
		public virtual Factura Factura { get; set; }
	}
}
