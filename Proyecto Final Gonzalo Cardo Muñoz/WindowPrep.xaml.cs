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
    /// Lógica de interacción para WindowPrep.xaml
    /// </summary>
    public partial class WindowPrep : NavigationWindow
    {
        BBDD datos;
        int cama;
        //  int NHC
        public WindowPrep(BBDD datos, int NHC)
        {
            InitializeComponent();
            this.datos = datos;
            //   this.cama = cama;
            PaginaHojas pag = new PaginaHojas(datos, NHC);
            this.NavigationService.Navigate(pag);
        }
    }
}
