using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class TelefonoClienteModelView
	{
		TiendaDataContext db =new TiendaDataContext();

		private bool _IsReadOnlyNumero = true;
		private bool _IsReadOnlyDescripcion = true;
		private bool _IsReadOnlyNit = true;
		private ObservableCollection<TelefonoCliente> _TelefonoClientes;

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
		public ObservableCollection<TelefonoCliente> TelefonoClientes
		{
			get {
				if(this._TelefonoClientes== null)
				{
					this._TelefonoClientes = new ObservableCollection<TelefonoCliente>();
					foreach(TelefonoCliente elemento in db.TelefonoClientes.ToList())
					{
						this._TelefonoClientes.Add(elemento);
					}
				}
				return this._TelefonoClientes; }
			set { this._TelefonoClientes = value; }
		}
		public string Titulo { get; set; }
		public TelefonoClienteModelView()
		{
			this.Titulo = "Telefono Clientes";
		}
	}
}
