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
    /// Lógica de interacción para PaginaAlta.xaml
    /// </summary>
    public partial class PaginaAlta : Page
    {
        BBDD datos;
        int cama;
        MenuPrincipal m;

        /// <summary>
        /// Constructor
        /// </summary>
        public PaginaAlta(WindowAlta a, BBDD datos, int cama, MenuPrincipal m)
        {
            InitializeComponent();
            this.cama = cama;
            this.datos = datos;
            this.m = m;
        }

        /// <summary>
        /// Este botón da de alta hospitalaria a un paciente
        /// </summary>
        private void btnalta_Click(object sender, RoutedEventArgs e)
        {
            if (txtalerta.Text == "")
            {
                MessageBox.Show("Por favor, rellena todos los campos");
            }
            else
            {
                if (cbomotivo.Text == "")
                {
                    MessageBox.Show("Por favor, rellena todos los campos");
                }
                else
                {
                    datos.QuitarPacienteCama(cama);
                    m.Refrescar();
                    MessageBox.Show("Paciente dado de alta correctamente");
                }
            }                     
        }
    }
}
