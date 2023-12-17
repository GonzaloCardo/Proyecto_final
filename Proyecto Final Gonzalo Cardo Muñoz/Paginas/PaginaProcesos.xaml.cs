using Proyecto_Final_Gonzalo_Cardo_Muñoz.Datos;
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

namespace Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas
{
    /// <summary>
    /// Lógica de interacción para PaginaProcesos.xaml, esta página no la utilizo
    /// </summary>
    public partial class PaginaProcesos : Page
    {
        BBDD datos;
        int cama;
        int NHC;

        public PaginaProcesos(WindowProcesos p, BBDD datos, int NHC)
        {
            InitializeComponent();
            this.datos = datos;
            this.NHC = NHC;
        }

        private void Toma_Click(object sender, RoutedEventArgs e)
        {
            PaginaTCAE newpag = new PaginaTCAE(datos, NHC);
            this.NavigationService.Navigate(newpag);
        }

        private void Balance_Click(object sender, RoutedEventArgs e)
        {
            PaginaBalance newpag = new PaginaBalance(datos, NHC);
            this.NavigationService.Navigate(newpag);
        }

        private void Hojas_Click(object sender, RoutedEventArgs e)
        {
            PaginaHojas newpag = new PaginaHojas(datos, NHC);
            this.NavigationService.Navigate(newpag);
        }

        private void PAT_Click(object sender, RoutedEventArgs e)
        {
            PaginaPAT newpag = new PaginaPAT(datos, NHC);
            this.NavigationService.Navigate(newpag);
        }
    }
}
