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
    /// Lógica de interacción para Informe.xaml
    /// </summary>
    public partial class Informe : NavigationWindow
    {
        Window ventana;
        public Informe(Window v)
        {
            InitializeComponent();
            ventana = v;
            VentanaDarAlta pag = new VentanaDarAlta(this);
            this.NavigationService.Navigate(pag);
            // v.Close();
        }
    }
}
