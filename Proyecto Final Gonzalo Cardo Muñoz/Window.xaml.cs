using Proyecto_Final_Gonzalo_Cardo_Muñoz.Datos;
using Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas;
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

namespace Proyecto_Final_Gonzalo_Cardo_Muñoz
{
    /// <summary>
    /// Lógica de interacción para Window.xaml
    /// </summary>
    public partial class Window : NavigationWindow
    {
        MainWindow principal;
        BBDD datos;
        VentanaVerFormulario vf;
        public Window(MainWindow p, BBDD datos)
        {
            InitializeComponent();
            this.datos = datos;
            principal = p;
            this.vf = vf;
            //p.Close();
            MenuPrincipal pag = new MenuPrincipal(datos, this);
            this.NavigationService.Navigate(pag);
        }

        public Window(VentanaVerFormulario vf)
        {
            this.vf = vf;
        }

        private void NavigationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MenuPrincipal nuevaPagina = new MenuPrincipal(datos, this);
            this.NavigationService.Navigate(nuevaPagina);
            //principal.Close();
        }
    }
}
