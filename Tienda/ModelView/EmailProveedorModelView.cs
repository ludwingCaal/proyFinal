using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class EmailProveedorModelView
	{
		TiendaDataContext db = new TiendaDataContext();

		private bool _IsReadOnlyEmail = true;
		private bool _IsReadOnlyCodigoProveedor = true;
		private ObservableCollection<EmailProveedor> _EmailProveedores;

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
		public bool IsReadOnlyCodigoProveedor
		{
			get
			{
				return this._IsReadOnlyCodigoProveedor;
			}
			set
			{
				this._IsReadOnlyCodigoProveedor=value;
			}
		}
		public ObservableCollection<EmailProveedor> EmailProveedores
		{
			get {
				if(this._EmailProveedores== null)
				{
					this._EmailProveedores = new ObservableCollection<EmailProveedor>();
					foreach(EmailProveedor elemento in db.EmailProveedores.ToList())
					{
						this._EmailProveedores.Add(elemento);
					}
				}
				return this._EmailProveedores; }
			set { this._EmailProveedores = value; }
		}

		public string Titulo { get; set; }
		public EmailProveedorModelView()
		{
			this.Titulo = "Email Proveedores";
		}
	}
}
