using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Model
{
	public class Factura
	{
		public int NumeroFactura { get; set; }
		public string Nit { get; set; }
		public DateTime Fecha { get; set; }
		public Decimal Total { get; set; }
		public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
		public virtual Cliente Cliente { get; set; }
	}
}
