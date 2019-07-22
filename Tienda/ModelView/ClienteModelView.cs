using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Data.Entity;

namespace Tienda.ModelView
{
	enum ACCION
	{
		NINGUNO,
		NUEVO,
		GUARDAR,
		ACTUALIZAR
	};
	public class ClienteModelView:INotifyPropertyChanged, ICommand
	{
		TiendaDataContext db = new TiendaDataContext();

		private ACCION accion = ACCION.NINGUNO;
		#region "Campos"
		private bool _IsReadOnlyNit = true;
		private bool _IsReadOnlyDpi = true;
		private bool _IsReadOnlyNombre = true;
		private bool _IsReadOnlyDireccion = true;
		private bool _IsEnableAgregar = true;
		private bool _IsEnableEliminar = true;
		private bool _IsEnableActualizar = true;
		private bool _IsEnableCancelar = false;
		private bool _IsEnableGuardar = false;
		private string _Nit;
		private string _Dpi;
		private string _Nombre;
		private string _Direccion;
		private Cliente _SelectCliente;
		private ClienteModelView _Instancia;
		private ObservableCollection<Cliente> _Clientes;//Variable creada a nivel de clase
		#endregion
		#region "Propiedades"
		public string Titulo { get; set; }
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
		public bool IsReadOnlyDpi
		{
			get
			{
				return this._IsReadOnlyDpi;
			}
			set
			{
				this._IsReadOnlyDpi = value;
				NotificarCambio("IsReadOnlyDpi");
			}
		}
		public bool IsReadOnlyNombre
		{
			get
			{
				return this._IsReadOnlyNombre;
			}
			set
			{
				this._IsReadOnlyNombre = value;
				NotificarCambio("IsReadOnlyNombre");
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
		public bool IsEnableAgregar
		{
			get
			{
				return this._IsEnableAgregar;
			}
			set
			{
				this._IsEnableAgregar = value;
				NotificarCambio("IsEnableAgregar");
			}
		}
		public bool IsEnableEliminar
		{
			get
			{
				return this._IsEnableEliminar;
			}
			set
			{
				this._IsEnableEliminar = value;
				NotificarCambio("IsEnableEliminar");
			}
		}
		public bool IsEnableActualizar
		{
			get
			{
				return this._IsEnableActualizar;
			}
			set
			{
				this._IsEnableActualizar = value;
				NotificarCambio("IsEnableActualizar");
			}
		}
		public bool IsEnableCancelar
		{
			get
			{
				return this._IsEnableCancelar;
			}
			set
			{
				this._IsEnableCancelar = value;
				NotificarCambio("IsEnableCancelar");
			}
		}
		public bool IsEnableGuardar
		{
			get
			{
				return this._IsEnableGuardar;
			}
			set
			{
				this._IsEnableGuardar = value;
				NotificarCambio("IsEnableGuardar");
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
		public string Dpi
		{
			get
			{
				return this._Dpi;
			}
			set
			{
				this._Dpi = value;
				NotificarCambio("Dpi");
			}
		}
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				this._Nombre = value;
				NotificarCambio("Nombre");
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
		public Cliente SelectCliente
		{
			get
			{
				return this._SelectCliente;
			}
			set
			{
				if (value!=null)
				{ 
					this._SelectCliente = value;
					this.Nit = value.Nit;
					this.Dpi = value.Dpi;
					this.Nombre = value.Nombre;
					this.Direccion = value.Direccion;
					NotificarCambio("SelectCliente");
				}
			}
		}
		public ClienteModelView Instancia
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
		public ObservableCollection<Cliente> Clientes //Propiedad creada para retornar u obtener valor de tipo cliente
		{
			get
			{
				if (this._Clientes == null)
				{
					this._Clientes = new ObservableCollection<Cliente>();
					foreach (Cliente elemento in db.Clientes.ToList())
					{
						this._Clientes.Add(elemento);
					}
				}
				return this._Clientes;
			}
			set { this._Clientes = value; }
		}
		#endregion
		#region "Constructores"
		public ClienteModelView()
		{
			this.Titulo = "Clientes";
			this.Instancia = this;
		}
		#endregion
		#region "Metodos"
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
				this.IsReadOnlyDpi = false;
				this.IsReadOnlyNombre = false;
				this.IsReadOnlyDireccion = false;
				this.accion = ACCION.NUEVO;
				this.IsEnableAgregar = false;
				this.IsEnableEliminar = false;
				this.IsEnableActualizar = false;
				this.IsEnableCancelar = true;
				this.IsEnableGuardar = true;
			}
			if (parameter.Equals("Guardar"))
			{
				switch (this.accion)
				{
					case ACCION.NUEVO:
						Cliente nuevo = new Cliente();
						nuevo.Nit = this.Nit;
						nuevo.Dpi = this.Dpi;
						nuevo.Nombre = this.Nombre;
						nuevo.Direccion = this.Direccion;
						db.Clientes.Add(nuevo);
						db.SaveChanges();
						this.Clientes.Add(nuevo);
						MessageBox.Show("Registro Almacenado");
						break;
					case ACCION.ACTUALIZAR:
						try
						{
							int posicion = this.Clientes.IndexOf(this.SelectCliente);
							var updateCliente = this.db.Clientes.Find(this.SelectCliente.Nit);
							updateCliente.Nit = this.Nit;
							updateCliente.Dpi = this.Dpi;
							updateCliente.Nombre = this.Nombre;
							updateCliente.Direccion = this.Direccion;
							this.db.Entry(updateCliente).State = EntityState.Modified;
							this.db.SaveChanges();
							this.Clientes.RemoveAt(posicion);
							this.Clientes.Insert(posicion, updateCliente);
							MessageBox.Show("Registro Actualizado!!!");
						}
						catch (Exception e)
						{
							MessageBox.Show(e.Message);
						}
						break;
				}
				this.IsEnableAgregar = true;
				this.IsEnableEliminar = true;
				this.IsEnableActualizar = true;
				this.IsEnableCancelar = false;
				this.IsEnableGuardar = false;
				this.IsReadOnlyNit = true;
				this.IsReadOnlyDpi = true;
				this.IsReadOnlyNombre = true;
				this.IsReadOnlyDireccion = true;
			}

			else if (parameter.Equals("Actualizar"))
			{
				this.accion = ACCION.ACTUALIZAR;
				this.IsReadOnlyNit = false;
				this.IsReadOnlyDpi = false;
				this.IsReadOnlyNombre = false;
				this.IsReadOnlyDireccion = false;
				this.IsEnableAgregar = false;
				this.IsEnableEliminar = false;
				this.IsEnableActualizar = false;
				this.IsEnableCancelar = true;
				this.IsEnableGuardar = true;
			}
			else if (parameter.Equals("Eliminar"))
			{
				if (this.SelectCliente!=null)
				{
					var respuesta = MessageBox.Show("Esta seguro de eliminar el registo?", "Eliminar", MessageBoxButton.YesNo);
					if (respuesta==MessageBoxResult.Yes)
					{
						try
						{
							db.Clientes.Remove(this.SelectCliente);
							db.SaveChanges();
							this.Clientes.Remove(this.SelectCliente);
						}
						catch (Exception e)
						{
							MessageBox.Show(e.Message);
						}
						
						MessageBox.Show("Registro eliminado correctamente!!");
					}
				}
				else
				{
					MessageBox.Show("Debe seleccionar un registro", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else if (parameter.Equals("Cancelar"))
			{
				this.IsEnableAgregar = true;
				this.IsEnableEliminar = true;
				this.IsEnableActualizar = true;
				this.IsEnableCancelar = false;
				this.IsEnableGuardar = false;
				this.IsReadOnlyNit = true;
				this.IsReadOnlyDpi = true;
				this.IsReadOnlyNombre = true;
				this._IsReadOnlyDireccion = true;
			}
		}
		#endregion
	}
}
