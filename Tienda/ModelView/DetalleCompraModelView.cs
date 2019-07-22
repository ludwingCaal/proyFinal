using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class DetalleCompraModelView
	{
		TiendaDataContext db = new TiendaDataContext();
		private bool _IsReadOnlyIdCompra = true;
		private bool _IsReadOnlyCodigoProducto = true;
		private bool _IsReadOnlyCantidad = true;
		private bool _IsReadOnlyPrecio = true;
		private ObservableCollection<DetalleCompra> _DetalleCompras;

		public bool IsReadOnlyIdCompra
		{
			get
			{
				return this._IsReadOnlyIdCompra;
			}
			set
			{
				this._IsReadOnlyIdCompra = value;
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
		public ObservableCollection<DetalleCompra> DetalleCompras
		{
			get {
				if (this._DetalleCompras == null)
				{
					this._DetalleCompras = new ObservableCollection<DetalleCompra>();
					foreach(DetalleCompra elemento in db.DetalleCompras.ToList())
					{
						this._DetalleCompras.Add(elemento);
					}
				}
				return this._DetalleCompras; }
			set { this._DetalleCompras = value; }
		}

		public string Titulo { get; set; }

		public DetalleCompraModelView()
		{
			this.Titulo = "Detalle de Compras";
		}
	}
}
