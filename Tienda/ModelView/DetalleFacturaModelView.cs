using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class DetalleFacturaModelView
	{
		TiendaDataContext db = new TiendaDataContext();
		private bool _IsReadOnlyNumeroFactura = true;
		private bool _IsReadOnlyCodigoProducto = true;
		private bool _IsReadOnlyCantidad = true;
		private bool _IsReadOnlyPrecio = true;
		private bool _IsReadOnlyDescuento = true;

		public bool IsReadOnlyNumeroFactura
		{
			get
			{
				return this._IsReadOnlyNumeroFactura;
			}
			set
			{
				this._IsReadOnlyNumeroFactura = value;
			}
		}
		public bool IsReadOnlyCodigoProducto
		{
			get
			{
				return this._IsReadOnlyCodigoProducto;
			}
			set
			{
				this._IsReadOnlyCodigoProducto = value;
			}
		}
		public bool IsReadOnlyCantidad
		{
			get
			{
				return this._IsReadOnlyCantidad;
			}
			set
			{
				this._IsReadOnlyCantidad = value;
			}
		}
		public bool IsReadOnlyPrecio
		{
			get
			{
				return this._IsReadOnlyPrecio;
			}
			set
			{
				this._IsReadOnlyPrecio = value;
			}
		}
		public bool IsReadOnlyDescuento
		{
			get
			{
				return this._IsReadOnlyDescuento;
			}
			set
			{
				this._IsReadOnlyDescuento = value;
			}
		}
		private ObservableCollection<DetalleFactura> _DetalleFacturas;
		public ObservableCollection<DetalleFactura> DetalleFacturas
		{
			get {
				if (this._DetalleFacturas == null)
				{
					this._DetalleFacturas = new ObservableCollection<DetalleFactura>();
					foreach(DetalleFactura elemento in db.DetalleFacturas.ToList())
					{
						this._DetalleFacturas.Add(elemento);
					}
				}
				return this._DetalleFacturas; }
			set { this._DetalleFacturas = value; }
		}

		public string Titulo { get; set; }
		public DetalleFacturaModelView()
		{
			this.Titulo = "Detalle de Facturas";
		}
	}
}
