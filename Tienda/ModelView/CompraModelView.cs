using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class CompraModelView
	{
		TiendaDataContext db =new TiendaDataContext();

		private bool _IsReadOnlyNumeroDocumento = true;
		private bool _IsReadOnlyCodigoProveedor = true;
		private bool _IsReadOnlyTotal = true;
		private ObservableCollection<Compra> _Compras;

		public bool IsReadOnlyNumeroDocumento
		{
			get
			{
				return this._IsReadOnlyNumeroDocumento;
			}
			set
			{
				this._IsReadOnlyNumeroDocumento = value;
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
		public bool IsReadOnlyTotal
		{
			get
			{
				return this._IsReadOnlyTotal;
			}
			set
			{
				this._IsReadOnlyTotal = value;
			}
		}
		
		public ObservableCollection<Compra> Compras
		{
			get {
				if (this._Compras == null)
				{
					this._Compras = new ObservableCollection<Compra>();
					foreach(Compra elemento in db.Compras.ToList())
					{
						this._Compras.Add(elemento);
					}
				}
				return this._Compras;}
			set { this._Compras = value; }
		}
		public string Titulo { get; set; }
		public CompraModelView()
		{
			this.Titulo = "Compras";
		}

	}
}
