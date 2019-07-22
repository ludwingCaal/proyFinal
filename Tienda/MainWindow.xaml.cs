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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tienda.Model;
using Tienda.View; 

namespace Tienda
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			new MenuPrincipal().ShowDialog();
        }
		/*
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			TiendaDataContext tdc = new TiendaDataContext();
			Categoria c = new Categoria();
			c.Descripcion = "Hi";
			tdc.Categorias.Add(c);
			tdc.SaveChanges();
			MessageBox.Show("Hola");
		}*/
	}
}
