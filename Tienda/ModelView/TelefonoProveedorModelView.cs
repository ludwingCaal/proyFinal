using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class TelefonoProveedorModelView
	{
		TiendaDataContext db = new TiendaDataContext();

		private bool _IsReadOnlyNumero = true;
		private bool _IsReadOnlyDescripcion = true;
		private bool _IsReadOnlyCodigoProveedor = true;
		private ObservableCollection<TelefonoProveedor> _TelefonoProveedores;

		public bool IsReadOnlyNumero
		{
			get
			{
				return this._IsReadOnlyNumero;
			}
			set
			{
				this._IsReadOnlyNumero = value;
			}
		}
		public bool IsReadOnlyDescripcion
		{
			get
			{
				return this._IsReadOnlyDescripcion;
			}
			set
			{
				this._IsReadOnlyDescripcion = value;
			}
		}
		public bool IsReadOnlyCodigoProveedor
		{
			get
			{
				return this._IsReadOnlyCodigoProveedor;
			}
			set
			{
				this._IsReadOnlyCodigoProveedor = value;
			}
		}
		public ObservableCollection<TelefonoProveedor> TelefonoProveedores
		{
			get {
				if (this._TelefonoProveedores == null)
				{
					this._TelefonoProveedores = new ObservableCollection<TelefonoProveedor>();
					foreach(TelefonoProveedor elemento in db.TelefonoProveedores.ToList())
					{
						this._TelefonoProveedores.Add(elemento);
					}
				}
				return this._TelefonoProveedores; }
			set { this._TelefonoProveedores = value; }
		}
		public string Titulo { get; set; }
		public TelefonoProveedorModelView()
		{
			this.Titulo = "Telefono Proveedores";
		}
	}
}
