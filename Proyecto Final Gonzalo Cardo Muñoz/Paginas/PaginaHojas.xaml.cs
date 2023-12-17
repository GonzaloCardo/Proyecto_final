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
    /// Lógica de interacción para PaginaHojas.xaml
    /// </summary>
    public partial class PaginaHojas : Page
    {
        BBDD datos;
        int NHC;

        /// <summary>
        /// Constructor
        /// </summary>
        public PaginaHojas(BBDD datos, int NHC)
        {
            InitializeComponent();
            this.datos = datos;
            this.NHC = NHC;
            Busqueda(NHC);
        }

        /// <summary>
        /// Este método carga la información (si la hay) en los texttbox
        /// </summary>
        private void Busqueda(int NHC)
        {
            try
            {
                txtEsp.Text = datos.BuscarPrep(NHC)[0];
                txtProp.Text = datos.BuscarPrep(NHC)[1];
                txtDosis.Text = datos.BuscarPrep(NHC)[2];
                txtAdm.Text = datos.BuscarPrep(NHC)[3];
                txtFrec.Text = datos.BuscarPrep(NHC)[4];
                txtfin.Text = datos.BuscarPrep(NHC)[5];
            }
            catch (Exception es)
            {
                //MessageBox.Show(es.ToString());
            }
        }

        /// <summary>
        /// Este botón guarda la información escrita en el paciente
        /// </summary>
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (datos.ComprobarPrep(NHC) == false)
            {
                if (txtEsp.Text == "")
                {
                    MessageBox.Show("El campo \"Especialidad\" es necesario.");
                }
                else
                {
                    datos.CrearPrep(txtEsp.Text, txtProp.Text, txtDosis.Text, txtAdm.Text, txtFrec.Text, txtfin.Text, NHC);
                    MessageBox.Show("Datos del paciente guardados.");
                }
            }
            else
            {
                MessageBox.Show("Este paciente ya tiene este documento asignado, si quieres realizar cambios actualízalo.");
            }
        }

        /// <summary>
        /// Este botón actualiza la información escrita del paciente
        /// </summary>
        private void btnActu_Click(object sender, RoutedEventArgs e)
        {          
            if (datos.ComprobarPrep(NHC) == true)
            {
                if (txtEsp.Text == "")
                {
                    MessageBox.Show("No puedes actualizar una alerta con el campo \"Especialidad\" vacío.");
                }
                else
                {
                    datos.ActualizarPrep(txtEsp.Text, txtProp.Text, txtDosis.Text, txtAdm.Text, txtFrec.Text, txtfin.Text, NHC);
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
