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
    /// Lógica de interacción para PaginaPAT.xaml
    /// </summary>
    public partial class PaginaPAT : Page
    {
        BBDD datos;
        int NHC;

        /// <summary>
        /// Constructor
        /// </summary>
        public PaginaPAT(BBDD datos, int NHC)
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
                txtFS.Text = datos.BuscarPAT(NHC)[0];
                txFD.Text = datos.BuscarPAT(NHC)[1];
                txtSin.Text = datos.BuscarPAT(NHC)[2];
                txtDia.Text = datos.BuscarPAT(NHC)[3];
                txtEsp.Text = datos.BuscarPAT(NHC)[4];
                txtCod.Text = datos.BuscarPAT(NHC)[5];
                txtNHC.Text = datos.BuscarPAT(NHC)[6];
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
            if (datos.ComprobarPAT(NHC) == false)
            {
                if (txtCod.Text == "")
                {
                    MessageBox.Show("El campo \"Codificación\" es necesario.");
                }
                else
                {
                    datos.CrearPAT(txtFS.Text, txFD.Text, txtSin.Text, txtDia.Text, txtEsp.Text, txtCod.Text, txtNHC.Text, NHC);
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
            if (datos.ComprobarPAT(NHC) == true)
            {
                if (txtCod.Text == "")
                {
                    MessageBox.Show("No puedes actualizar una alerta con el campo \"Codificación\" vacío.");
                }
                else
                {
                    datos.ActualizarPAT(txtFS.Text, txFD.Text, txtSin.Text, txtDia.Text, txtEsp.Text, txtCod.Text, txtNHC.Text, NHC);
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
