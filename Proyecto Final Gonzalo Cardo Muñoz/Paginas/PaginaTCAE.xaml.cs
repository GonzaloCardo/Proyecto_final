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
    /// Lógica de interacción para PaginaTCAE.xaml
    /// </summary>
    public partial class PaginaTCAE : Page
    {
        BBDD datos;
        int NHC;
        /// <summary>
        /// Constructor
        /// </summary>
        public PaginaTCAE(BBDD datos, int NHC)
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
            if (datos.ComprobarToma(NHC) == false)
            {
                if (txtTemperatura.Text == "")
                {
                    MessageBox.Show("El campo \"Temperatura\" es necesario.");
                }
                else
                {
                    datos.CrearToma(txtTemperatura.Text, txtTAsis.Text, txtTAdia.Text, txtFC.Text, txtFR.Text, txtPT.Text, txtIndice.Text, txtGC.Text, txtIngesta.Text, txtDep.Text, txtNauseas.Text, txtPrurito.Text, txtobservaciones.Text, NHC);
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
                txtTemperatura.Text = datos.BuscarToma(NHC)[0];
                txtTAsis.Text = datos.BuscarToma(NHC)[1];
                txtTAdia.Text = datos.BuscarToma(NHC)[2];
                txtFC.Text = datos.BuscarToma(NHC)[3];
                txtFR.Text = datos.BuscarToma(NHC)[4];
                txtPT.Text = datos.BuscarToma(NHC)[5];
                txtIndice.Text = datos.BuscarToma(NHC)[6];
                txtGC.Text = datos.BuscarToma(NHC)[7];
                txtIngesta.Text = datos.BuscarToma(NHC)[8];
                txtDep.Text = datos.BuscarToma(NHC)[9];
                txtNauseas.Text = datos.BuscarToma(NHC)[10];
                txtPrurito.Text = datos.BuscarToma(NHC)[11];
                txtobservaciones.Text = datos.BuscarToma(NHC)[12];
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
            if (datos.ComprobarToma(NHC) == true)
            {
                if (txtTemperatura.Text == "")
                {
                    MessageBox.Show("No puedes actualizar una alerta con el campo \"Temperatura\" vacío.");
                }
                else
                {
                    datos.ActualizarToma(txtTemperatura.Text, txtTAsis.Text, txtTAdia.Text, txtFC.Text, txtFR.Text, txtPT.Text, txtIndice.Text, txtGC.Text, txtIngesta.Text, txtDep.Text, txtNauseas.Text, txtPrurito.Text, txtobservaciones.Text, NHC);
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
