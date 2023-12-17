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
    /// Lógica de interacción para WindowProcesos.xaml
    /// </summary>
    public partial class WindowProcesos : NavigationWindow
    {
        BBDD datos;
        int cama;
        int NHC;
        // , int cama
        public WindowProcesos(BBDD datos, int NHC)
        {
            InitializeComponent();
            this.datos = datos;
            this.NHC = NHC;
            //   this.cama = cama;
            PaginaProcesos pag = new PaginaProcesos(this, datos, NHC);
            this.NavigationService.Navigate(pag);
        }
    }
}
