using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Model
{
	public class Producto
	{
		public int CodigoProducto { get; set; }
		public int CodigoCategoria { get; set; }
		public int CodigoEmpaque { get; set; }
		public string Descripcion { get; set; }
		public Decimal PrecioUnitario { get; set; }
		public Decimal PrecioPorDocena { get; set; }
		public Decimal PrecioPorMayor { get; set; }
		public int Existencia { get; set; }
		public string Imagen { get; set; }
		public virtual Categoria Categoria { get; set; }
		public virtual ICollection<Inventario> Inventarios { get; set; }
		public virtual TipoEmpaque TipoEmpaque { get; set; }
		public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
		public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }

	}
}
