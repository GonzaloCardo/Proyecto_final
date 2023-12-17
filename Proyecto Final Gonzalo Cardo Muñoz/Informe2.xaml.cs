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
    /// Lógica de interacción para Informe2.xaml
    /// </summary>
    public partial class Informe2 : NavigationWindow
    {
        MainWindow principal;
        public Informe2(Window v, BBDD datos, MainWindow p, string texto, int num, MenuPrincipal menu)
        {
            InitializeComponent();
            p = principal;
            VentanaVerFormulario pag = new VentanaVerFormulario(this, p, datos, texto, num, menu);
            this.NavigationService.Navigate(pag);
        }
    }
}
