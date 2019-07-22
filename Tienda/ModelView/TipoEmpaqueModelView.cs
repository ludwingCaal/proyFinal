using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Tienda.Model;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace Tienda.ModelView
{
	public class TipoEmpaqueModelView : INotifyPropertyChanged,ICommand
	{
		TiendaDataContext db = new TiendaDataContext();

		private bool _IsReadOnlyDescripcion = true;
		private string _Descripcion;
		private TipoEmpaqueModelView _Instancia;
		private ObservableCollection<TipoEmpaque> _TipoEmpaques;

		public event EventHandler CanExecuteChanged;
		public event PropertyChangedEventHandler PropertyChanged;

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
		public TipoEmpaqueModelView Instancia
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
		public ObservableCollection<TipoEmpaque> TipoEmpaques
		{
			get {
				if (this._TipoEmpaques == null)
				{
					this._TipoEmpaques = new ObservableCollection<TipoEmpaque>();
					foreach (TipoEmpaque elemento in db.TipoEmpaques.ToList())
					{
						this._TipoEmpaques.Add(elemento);
					}
				}
				return this._TipoEmpaques; }
			set { this._TipoEmpaques = value; }
		} 
		public string Titulo { get; set; }
		public TipoEmpaqueModelView()
		{
			this.Titulo = "Tipo de Empaques";
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
				this.IsReadOnlyDescripcion = false;
			}
			if (parameter.Equals("Guardar"))
			{
				TipoEmpaque nuevo = new TipoEmpaque();
				nuevo.Descripcion = this.Descripcion;
				db.TipoEmpaques.Add(nuevo);
				db.SaveChanges();
				this.TipoEmpaques.Add(nuevo);
				MessageBox.Show("Registro Almacenado");
			}
		}
	}
}
