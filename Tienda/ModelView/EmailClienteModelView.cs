using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class EmailClienteModelView
	{
		TiendaDataContext db = new TiendaDataContext();
		private bool _IsReadOnlyEmail = true;
		private bool _IsReadOnlyNit = true;
		private ObservableCollection<EmailCliente> _EmailClientes;

		public bool IsReadOnlyEmail
		{
			get
			{
				return this._IsReadOnlyEmail;
			}
			set
			{
				this._IsReadOnlyEmail = value;
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
		public ObservableCollection <EmailCliente> EmailClientes
		{
			get {
				if (this._EmailClientes == null)
				{
					this._EmailClientes = new ObservableCollection<EmailCliente>();
					foreach(EmailCliente elemento in db.EmailClientes.ToList())
					{
						this._EmailClientes.Add(elemento);
					}
				}
				return this._EmailClientes; }
			set { this._EmailClientes = value; }
		}

		public string Titulo { get; set; }
		public EmailClienteModelView()
		{
			this.Titulo = "Email De Clientes";
		}
	}
}
