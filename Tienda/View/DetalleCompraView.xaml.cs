using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tienda.ModelView;

namespace Tienda.View
{
	/// <summary>
	/// Lógica de interacción para DetalleCompraView.xaml
	/// </summary>
	public partial class DetalleCompraView : Window
	{
		public DetalleCompraView()
		{
			InitializeComponent();
			this.DataContext = new DetalleCompraModelView();
		}
	}
}
