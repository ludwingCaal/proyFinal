using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tienda.Model;

namespace Tienda.ModelView
{
	public class CategoriaModelView : INotifyPropertyChanged, ICommand
	{
		private TiendaDataContext db = new TiendaDataContext(); //Enlace a la base de datos
		#region "Campos"
		private ACCION accion = ACCION.NINGUNO;
		private Boolean _IsReadOnlyDescripcion = true;
		private string _Descripcion;
		private bool _IsEnableAgregar = true;
		private bool _IsEnableEliminar = true;
		private bool _IsEnableActualizar = true;
		private bool _IsEnableCancelar = false;
		private bool _IsEnableGuardar = false;
		private Categoria _SelectCategoria;
		private CategoriaModelView _Instancia;
		private ObservableCollection<Categoria> _Categoria;
		#endregion
		#region "Propiedades"
		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler CanExecuteChanged;
		public Boolean IsReadOnlyDescripcion
		{
			get
			{
				return this._IsReadOnlyDescripcion;
			}
			set
			{
				this._IsReadOnlyDescripcion = value;
				NotificarCambio("IsReadOnlyDescripcion");
			}
		}
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				this._Descripcion = value;
				NotificarCambio("Descripcion");
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
		public CategoriaModelView Instancia
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
		public Categoria SelectCategoria
		{
			get
			{
				return this._SelectCategoria;
			}
			set
			{
				if (value != null)
				{
					this._SelectCategoria = value;
					this.Descripcion = value.Descripcion;
					NotificarCambio("SelectCliente");
				}
			}
		}
		public ObservableCollection<Categoria> Categorias
		{
			get
			{
				if (this._Categoria == null)
				{
					this._Categoria = new ObservableCollection<Categoria>();
					foreach (Categoria elemento in db.Categorias.ToList())
					{
						this._Categoria.Add(elemento);
					}
				}

				return this._Categoria;
			}
			set { this._Categoria = value; }
		}
		#endregion
		#region "Constructores"
		public string Titulo { get; set; }
		public CategoriaModelView()
		{
			this.Titulo = "Categorias";
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

		public bool CanExecute(object parameter) //permite o no ejecutar un evento.
		{
			return true;
		}

		public void Execute(object parameter)//ejecuta evento
		{
			if (parameter.Equals("Agregar"))
			{
				this.IsReadOnlyDescripcion = false;
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
						Categoria nuevo = new Categoria();
						nuevo.Descripcion = this.Descripcion;
						db.Categorias.Add(nuevo);
						db.SaveChanges();
						this.Categorias.Add(nuevo);
						MessageBox.Show("Registro Almacenado");
						break;
					case ACCION.ACTUALIZAR:
						try
						{
							int posicion = this.Categorias.IndexOf(this.SelectCategoria);
							var updateCategoria = this.db.Categorias.Find(this.SelectCategoria.CodigoCategoria);
							updateCategoria.Descripcion = this.Descripcion;
							this.db.Entry(updateCategoria).State = EntityState.Modified;
							this.db.SaveChanges();
							this.Categorias.RemoveAt(posicion);
							this.Categorias.Insert(posicion, updateCategoria);
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
				this.IsReadOnlyDescripcion = true;
			}

			else if (parameter.Equals("Actualizar"))
			{
				this.accion = ACCION.ACTUALIZAR;
				this.IsReadOnlyDescripcion = false;
				this.IsEnableAgregar = false;
				this.IsEnableEliminar = false;
				this.IsEnableActualizar = false;
				this.IsEnableCancelar = true;
				this.IsEnableGuardar = true;
			}
			else if (parameter.Equals("Eliminar"))
			{
				if (this.SelectCategoria != null)
				{
					var respuesta = MessageBox.Show("Esta seguro de eliminar el registo?", "Eliminar", MessageBoxButton.YesNo);
					if (respuesta == MessageBoxResult.Yes)
					{
						try
						{
							db.Categorias.Remove(this.SelectCategoria);
							db.SaveChanges();
							this.Categorias.Remove(this.SelectCategoria);
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
				this._IsReadOnlyDescripcion = true;
			}
		}
		#endregion
	}
}