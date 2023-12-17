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
using static System.Net.Mime.MediaTypeNames;

namespace Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas
{
    /// <summary>
    /// Lógica de interacción para PaginaBalance.xaml
    /// </summary>
    public partial class PaginaBalance : Page
    {
        BBDD datos;
        int NHC;

        /// <summary>
        /// Constructor
        /// </summary>
        public PaginaBalance(BBDD datos, int NHC)
        {
            InitializeComponent();
            this.datos = datos;
            this.NHC = NHC;
            Busqueda(NHC);
        }

        /// <summary>
        /// Este botón guarda la información escrita en el paciente
        /// </summary>
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (datos.ComprobarBalance(NHC) == false)
            {
                if (txtLiq.Text == "")
                {
                    MessageBox.Show("El campo \"Ingesta de líquidos\" es necesario.");
                }
                else
                {
                    datos.CrearBalance(txtAlim.Text, txtLiq.Text, txtFluid.Text, txtHemo.Text, txtOtros.Text, txtDiu.Text, txtVomi.Text, txtHeces.Text, txtSonda.Text, txtDrenajes.Text, txtOtras.Text, txtTotal.Text, NHC);
                    MessageBox.Show("Datos del paciente guardados.");
                }
            }
            else
            {
                MessageBox.Show("Este paciente ya tiene este documento asignado, si quieres realizar cambios actualízalo.");
            }
        }

        /// <summary>
        /// Este método carga la información (si la hay) en los texttbox
        /// </summary>
        private void Busqueda(int NHC)
        {
            try
            {
                txtAlim.Text = datos.BuscarBalance(NHC)[0];
                txtLiq.Text = datos.BuscarBalance(NHC)[1];
                txtFluid.Text = datos.BuscarBalance(NHC)[2];
                txtHemo.Text = datos.BuscarBalance(NHC)[3];
                txtOtros.Text = datos.BuscarBalance(NHC)[4];
                txtDiu.Text = datos.BuscarBalance(NHC)[5];
                txtVomi.Text = datos.BuscarBalance(NHC)[6];
                txtHeces.Text = datos.BuscarBalance(NHC)[7];
                txtSonda.Text = datos.BuscarBalance(NHC)[8];
                txtDrenajes.Text = datos.BuscarBalance(NHC)[9];
                txtOtras.Text = datos.BuscarBalance(NHC)[10];
                txtTotal.Text = datos.BuscarBalance(NHC)[11];
            }
            catch (Exception es)
            {
                //MessageBox.Show(es.ToString());
            }
        }

        /// <summary>
        /// Este botón actualiza la información escrita del paciente
        /// </summary>
        private void btnActu_Click(object sender, RoutedEventArgs e)
        {
            
            if (datos.ComprobarBalance(NHC) == true)
            {
                if (txtLiq.Text == "")
                {
                    MessageBox.Show("No puedes actualizar una alerta con el campo \"Ingesta de líquidos\" vacío.");
                }
                else
                {
                    datos.ActualizarBalance(txtAlim.Text, txtLiq.Text, txtFluid.Text, txtHemo.Text, txtOtros.Text, txtDiu.Text, txtVomi.Text, txtHeces.Text, txtSonda.Text, txtDrenajes.Text, txtOtras.Text, txtTotal.Text, NHC);
                    MessageBox.Show("Paciente actualizado.");
                }
            }
            else
            {
                MessageBox.Show("No es posible actualizar este proceso si previamente no ha sido guardado sobre este paciente.");
            }
        }
    }
}
