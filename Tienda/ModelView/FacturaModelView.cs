using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class FacturaModelView
	{
		TiendaDataContext db =new TiendaDataContext();

		private bool _IsReadOnlyNit = true;
		private bool _IsReadOnlyTotal = true;
		private ObservableCollection<Factura> _Facturas;

		public bool IsReadOnlyNit
		{
			get
			{
				return this._IsReadOnlyNit;
			}
			set
			{
				this._IsReadOnlyNit = value;
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
		public ObservableCollection<Factura> Facturas
		{
			get {
				if (this._Facturas == null)
				{
					this._Facturas = new ObservableCollection<Factura>();
					foreach(Factura elemento in db.Facturas.ToList())
					{
						this._Facturas.Add(elemento);
					}
				}
				return this._Facturas; }
			set { this._Facturas = value; }
		}
		public string Titulo { get; set; }
		public FacturaModelView()
		{
			this.Titulo = "Facturas";
		}
	}
}
