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
    /// Lógica de interacción para WindowAlta.xaml
    /// </summary>
    public partial class WindowAlta : NavigationWindow
    {
        BBDD datos;
        int cama;
        MenuPrincipal m;
        public WindowAlta(BBDD datos, int cama, MenuPrincipal m)
        {
            InitializeComponent();
            this.datos = datos;
            this.cama = cama;
            this.m = m;
            PaginaAlta pag = new PaginaAlta(this, datos, cama, m);
            this.NavigationService.Navigate(pag);
        }
    }
}
