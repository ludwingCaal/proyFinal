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

namespace Tienda.View
{
	/// <summary>
	/// Lógica de interacción para MenuPrincipal.xaml
	/// </summary>
	public partial class MenuPrincipal : Window
	{
		public MenuPrincipal()
		{
			InitializeComponent();

		}

		private void Button_ClickCategorias(object sender, RoutedEventArgs e)
		{
			CategoriaView categorias = new CategoriaView();
			categorias.ShowDialog();
		}
		private void Button_ClickClientes(object sender, RoutedEventArgs e)
		{
			ClienteView clientes = new ClienteView();
			clientes.ShowDialog();
		}
		private void Button_ClickCompras(object sender, RoutedEventArgs e)
		{
			CompraView compras = new CompraView();
			compras.ShowDialog();
		}
		private void Button_ClickDetalleCompras(object sender, RoutedEventArgs e)
		{
			DetalleCompraView dc = new DetalleCompraView();
			dc.ShowDialog();
		}
		private void Button_ClickDetalleFacturas(object sender, RoutedEventArgs e)
		{
			DetalleFacturaView df = new DetalleFacturaView();
			df.ShowDialog();
		}
		private void Button_ClickEmailClientes(object sender, RoutedEventArgs e)
		{
			EmailClienteView emailc = new EmailClienteView();
			emailc.ShowDialog();
		}
		private void Button_ClickEmailProveedores(object sender, RoutedEventArgs e)
		{
			EmailProveedorView emailp = new EmailProveedorView();
			emailp.ShowDialog();
		}
		private void Button_ClickFacturas(object sender, RoutedEventArgs e)
		{
			FacturaView facturas = new FacturaView();
			facturas.ShowDialog();
		}
		private void Button_ClickInventarios(object sender, RoutedEventArgs e)
		{
			InventarioView inventarios = new InventarioView();
			inventarios.ShowDialog();
		}
		private void Button_ClickProductos(object sender, RoutedEventArgs e)
		{
			ProductoView productos = new ProductoView();
			productos.ShowDialog();
		}
		private void Button_ClickProveedores(object sender, RoutedEventArgs e)
		{
			ProveedorView proveedores = new ProveedorView();
			proveedores.ShowDialog();
		}
		private void Button_ClickTelefonoClientes(object sender, RoutedEventArgs e)
		{
			TelefonoClienteView telefonoclientes = new TelefonoClienteView();
			telefonoclientes.ShowDialog();
		}
		private void Button_ClickTelefonoProveedores(object sender, RoutedEventArgs e)
		{
			TelefonoProveedorView telefonoProveedores = new TelefonoProveedorView();
			telefonoProveedores.ShowDialog();
		}
		private void Button_ClickTipoEmpaque(object sender, RoutedEventArgs e)
		{
			TipoEmpaqueView tipoEmpaque = new TipoEmpaqueView();
			tipoEmpaque.ShowDialog();
		}
	}
}
