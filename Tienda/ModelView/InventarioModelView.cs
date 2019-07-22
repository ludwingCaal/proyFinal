using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class InventarioModelView
	{
		TiendaDataContext db = new TiendaDataContext();

		private bool _IsReadOnlyCodigoProducto = true;
		private bool _IsReadOnlyTipoRegistro = true;
		private bool _IsReadOnlyPrecio = true;
		private bool _IsReadOnlyEntradas = true;
		private bool _IsReadOnlySalidas = true;
		private ObservableCollection<Inventario> _Inventarios;

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
		public bool IsReadOnlyTipoRegistro
		{
			get
			{
				return this._IsReadOnlyTipoRegistro;
			}
			set
			{
				this._IsReadOnlyTipoRegistro = value;
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
		public bool IsReadOnlyEntradas
		{
			get
			{
				return this._IsReadOnlyEntradas;
			}
			set
			{
				this._IsReadOnlyEntradas = value;
			}
		}
		public bool IsReadOnlySalidas
		{
			get
			{
				return this._IsReadOnlySalidas;
			}
			set
			{
				this._IsReadOnlySalidas = value;
			}
		}
		public ObservableCollection<Inventario> Inventarios
		{
			get {
				if (this._Inventarios == null)
				{
					this._Inventarios = new ObservableCollection<Inventario>();
					foreach(Inventario elemento in db.Inventarios.ToList())
					{
						this._Inventarios.Add(elemento);
					}
				}
				return this._Inventarios; }
			set { this._Inventarios = value; }
		}

		public string Titulo { get; set; }
		public InventarioModelView()
		{
			this.Titulo = "Inventarios";
		}
	}
}
