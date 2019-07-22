using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace Tienda.ModelView
{
	public class ProveedorModelView:INotifyPropertyChanged,ICommand
	{
		TiendaDataContext db = new TiendaDataContext();

		private bool _IsReadOnlyNit = true;
		private bool _IsReadOnlyRazonSocial = true;
		private bool _IsReadOnlyDireccion = true;
		private bool _IsReadOnlyPaginaWeb = true;
		private bool _IsReadOnlyContactoPrincipal = true;
		private string _Nit;
		private string _RazonSocial;
		private string _Direccion;
		private string _PaginaWeb;
		private string _ContactoPrincipal;
		private ProveedorModelView _Instancia;
		private ObservableCollection<Proveedor> _Proveedores;

		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler CanExecuteChanged;

		public bool IsReadOnlyNit
		{
			get
			{
				return this._IsReadOnlyNit;
			}
			set
			{
				this._IsReadOnlyNit = value;
				NotificarCambio("IsReadOnlyNit");
			}
		}
		public bool IsReadOnlyRazonSocial
		{
			get
			{
				return this._IsReadOnlyRazonSocial;
			}
			set
			{
				this._IsReadOnlyRazonSocial = value;
				NotificarCambio("IsReadOnlyRazonSocial");
			}
		}
		public bool IsReadOnlyDireccion
		{
			get
			{
				return this._IsReadOnlyDireccion;
			}
			set
			{
				this._IsReadOnlyDireccion = value;
				NotificarCambio("IsReadOnlyDireccion");
			}
		}
		public bool IsReadOnlyPaginaWeb
		{
			get
			{
				return this._IsReadOnlyPaginaWeb;
			}
			set
			{
				this._IsReadOnlyPaginaWeb = value;
				NotificarCambio("IsReadOnlyPaginaWeb");
			}
		}
		public bool IsReadOnlyContactoPrincipal
		{
			get
			{
				return this._IsReadOnlyContactoPrincipal;
			}
			set
			{
				this._IsReadOnlyContactoPrincipal = value;
				NotificarCambio("IsReadOnlyContactoPrincipal");
			}
		}
		public string Nit
		{
			get
			{
				return this._Nit;
			}
			set
			{
				this._Nit = value;
				NotificarCambio("Nit");
			}
		}
		public string RazonSocial
		{
			get
			{
				return this._RazonSocial;
			}
			set
			{
				this._RazonSocial = value;
				NotificarCambio("RazonSocial");
			}
		}
		public string Direccion
		{
			get
			{
				return this._Direccion;
			}
			set
			{
				this._Direccion = value;
				NotificarCambio("Direccion");
			}
		}
		public string PaginaWeb
		{
			get
			{
				return this._PaginaWeb;
			}
			set
			{
				this._PaginaWeb = value;
				NotificarCambio("PaginaWeb");
			}
		}
		public string ContactoPrincipal
		{
			get
			{
				return this._ContactoPrincipal;
			}
			set
			{
				this._ContactoPrincipal = value;
				NotificarCambio("ContactoPrincipal");
			}
		}
	

		public ProveedorModelView Instancia
		{
			get
			{
				return this._Instancia;
			}
			set
			{
				this._Instancia = value;
			}

		}
		public ObservableCollection<Proveedor> Proveedores
		{
			get {
				if(this._Proveedores== null)
				{
					this._Proveedores = new ObservableCollection<Proveedor>();
					foreach(Proveedor elemento in db.Proveedores.ToList())
					{
						this._Proveedores.Add(elemento);
					}
				}
				return this._Proveedores; }
			set { this._Proveedores = value; }
		}
		public string Titulo { get; set; }
		public ProveedorModelView()
		{
			this.Titulo = "Proveedores";
			this.Instancia = this;
		}
		public void NotificarCambio(string propiedad)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
			}
		}
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if (parameter.Equals("Agregar"))
			{
				this.IsReadOnlyNit = false;
				this.IsReadOnlyRazonSocial = false;
				this.IsReadOnlyDireccion = false;
				this.IsReadOnlyPaginaWeb = false;
				this.IsReadOnlyContactoPrincipal = false;
			}
			if (parameter.Equals("Guardar"))
			{
				Proveedor nuevo = new Proveedor();
				nuevo.Nit = this.Nit;
				nuevo.RazonSocial = this.RazonSocial;
				nuevo.Direccion = this.Direccion;
				nuevo.PaginaWeb = this.PaginaWeb;
				nuevo.ContactoPrincipal = this.ContactoPrincipal;
				db.Proveedores.Add(nuevo);
				db.SaveChanges();
				this.Proveedores.Add(nuevo);
				MessageBox.Show("Registro Almacenado");
			}
		}
	}
}
