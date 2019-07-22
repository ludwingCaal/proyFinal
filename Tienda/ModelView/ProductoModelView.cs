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
	public class ProductoModelView : INotifyPropertyChanged, ICommand
	{
		TiendaDataContext db = new TiendaDataContext();

		private bool _IsReadOnlyCodigoCategoria=true;
		private bool _IsReadOnlyCodigoEmpaque = true;
		private bool _IsReadOnlyDescripcion = true;
		private bool _IsReadOnlyPrecioPorUnidad = true;
		private bool _IsReadOnlyPrecioPorDocena = true;
		private bool _IsReadOnlyPrecioPorMayor = true;
		private bool _IsReadOnlyExistencia = true;
		private string _CodigoCategoria;
		private string _CodigoEmpaque;
		private string _Descripcion;
		private string _PrecioPorUnidad;
		private string _PrecioPorDocena;
		private string _PrecioPorMayor;
		private string _Existencia;
		private ProductoModelView _Instacia;
		private ObservableCollection<Producto> _Productos;

		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler CanExecuteChanged;

		public bool IsReadOnlyCodigoCategoria
		{
			get
			{
				return this._IsReadOnlyCodigoCategoria;
			}
			set
			{
				this._IsReadOnlyCodigoCategoria = value;
				NotificarCambio("IsReadOnlyCodigoCategoria");
			}
		}
		public bool IsReadOnlyCodigoEmpaque
		{
			get
			{
				return this._IsReadOnlyCodigoEmpaque;
			}
			set
			{
				this._IsReadOnlyCodigoEmpaque = value;
				NotificarCambio("IsReadOnlyCodigoEmpaque");
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
				NotificarCambio("IsReadOnlyDescripcion");
			}
		}
		public bool IsReadOnlyPrecioPorUnidad
		{
			get
			{
				return this._IsReadOnlyPrecioPorUnidad;
			}
			set
			{
				this._IsReadOnlyPrecioPorUnidad = value;
				NotificarCambio("IsReadOnlyPrecioPorUnidad");
			}
		}
		public bool IsReadOnlyPrecioPorDocena
		{
			get
			{
				return this._IsReadOnlyPrecioPorDocena;
			}
			set
			{
				this._IsReadOnlyPrecioPorDocena = value;
				NotificarCambio("IsReadOnlyPrecioPorDocena");
			}
		}
		public bool IsReadOnlyPrecioPorMayor
		{
			get
			{
				return this._IsReadOnlyPrecioPorMayor;
			}
			set
			{
				this._IsReadOnlyPrecioPorMayor = value;
				NotificarCambio("IsReadOnlyPrecioPorMayor");
			}
		}
		public bool IsReadOnlyExistencia
		{
			get
			{
				return this._IsReadOnlyExistencia;
			}
			set
			{
				this._IsReadOnlyExistencia = value;
				NotificarCambio("IsReadOnlyExistencia");
			}
		}
		public string CodigoCategoria
		{
			get
			{
				return this._CodigoCategoria;
			}
			set
			{
				this._CodigoCategoria = value;
				NotificarCambio("CodigoCategoria");
			}
		}
		public string CodigoEmpaque
		{
			get
			{
				return this._CodigoEmpaque;
			}
			set
			{
				this._CodigoEmpaque = value;
				NotificarCambio("CodigoEmpaque");
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
		public string PrecioPorUnidad
		{
			get
			{
				return this._PrecioPorUnidad;
			}
			set
			{
				this._PrecioPorUnidad = value;
				NotificarCambio("PrecioPorUnidad");
			}
		}
		public string PrecioPorDocena
		{
			get
			{
				return this._PrecioPorDocena;
			}
			set
			{
				this._PrecioPorDocena = value;
				NotificarCambio("PrecioPorDocena");
			}
		}
		public string PrecioPorMayor
		{
			get
			{
				return this._PrecioPorMayor;
			}
			set
			{
				this._PrecioPorMayor = value;
				NotificarCambio("PrecioPorMayor");
			}
		}
		public string Existencia
		{
			get
			{
				return this._Existencia;
			}
			set
			{
				this._Existencia = value;
				NotificarCambio("Existencia");
			}
		}

		public ProductoModelView Instancia
		{
			get
			{
				return this._Instacia;
			}
			set
			{
				this._Instacia = value;
			}
		}
		public ObservableCollection<Producto> Productos
		{
			get {
				if (this._Productos == null)
				{
					this._Productos = new ObservableCollection<Producto>();
					foreach(Producto elemento in db.Productos.ToList())
					{
						this._Productos.Add(elemento);
					}
				}
				return this._Productos; }
			set { this._Productos = value; }
		}
		public string Titulo { get; set; }

		public ProductoModelView()
		{
			this.Titulo = "Productos";
			this.Instancia = this;
		}

		public bool CanExecute(object parameter)//permite devolver un valor bool si todo lo que implementemos esta bien.
		{
			return true;
		}

		public void NotificarCambio(string propiedad)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propiedad)); 
			}
		}
		public void Execute(object parameter)
		{
			if (parameter.Equals("Agregar"))
			{
				this.IsReadOnlyCodigoCategoria = false;
				this.IsReadOnlyCodigoEmpaque = false;
				this.IsReadOnlyDescripcion = false;
				this.IsReadOnlyPrecioPorUnidad = false;
				this.IsReadOnlyPrecioPorDocena = false;
				this.IsReadOnlyPrecioPorMayor = false;
				this.IsReadOnlyExistencia = false;
			}
			if (parameter.Equals("Guardar"))
			{
				Producto nuevo = new Producto();
				nuevo.CodigoCategoria = Convert.ToInt16(this.CodigoCategoria);
				nuevo.CodigoEmpaque = Convert.ToInt16(this.CodigoEmpaque);
				nuevo.Descripcion = this.Descripcion;
				nuevo.PrecioUnitario = Convert.ToInt16(this.PrecioPorUnidad);
				nuevo.PrecioPorDocena = Convert.ToInt16(this.PrecioPorDocena);
				nuevo.PrecioPorMayor = Convert.ToInt16(this.PrecioPorMayor);
				nuevo.Existencia = Convert.ToInt16(this.Existencia);
				db.Productos.Add(nuevo);    
				db.SaveChanges();
				this.Productos.Add(nuevo);
				MessageBox.Show("Registro almacenado");
			}
		}
	}
}
