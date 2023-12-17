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
    /// Lógica de interacción para VentanaDarAlta.xaml
    /// </summary>
    public partial class VentanaDarAlta : Page
    {
        MainWindow principal;
        Informe inform;
        BBDD datos;
        int fallecido;
        string nacionalidad;
        string nacimiento;

        /// <summary>
        /// Constructor
        /// </summary>
        public VentanaDarAlta(Informe informe)
        {
            InitializeComponent();
            datos = new BBDD();
            this.inform = informe;
            RellenarComunidades();
            RellenarProvincias();
            RellenarAreas();
            RellenarCentros();
            RellenarZonas();
            RellenarCastilla();
        }

        /// <summary>
        /// Este botón guarda a un nuevo paciente con los datos escritos en la base de datos
        /// </summary>
        private void btnDarAlta_Click(object sender, RoutedEventArgs e)
        {

            if (txtNIF.Text == "" || txtNSS.Text == "" || txtSexo.Text == "")
            {
                MessageBox.Show("Es obligatorio que exista un NIF/DNI, un número de la Seguridad Social, y un género.");
            }
            else if (cboAmbito.Text != "Hospitalización" || cboEstado.Text != "Hospitalización")
            {
                MessageBox.Show("Los campos \"Estado HC\" y \"Ámbito\" deben ser \"Hospitalización\".");
            }
            else
            {
                datos.DarAlta(cboEstado.Text, cboAmbito.Text, txtNombre.Text, txtAp1.Text, txtap2.Text, txtSexo.Text, txtFchN.Text, txtTlf1.Text, txtTlf2.Text, txtmov.Text, txtCivil.Text, txtEst.Text, fallecido, txtFch.Text, txthora.Text, nacionalidad, txtNIF.Text, cboComun.Text, cboPro.Text, txtPob.Text, txtCP.Text, txtDir.Text, txtNSS.Text, txtreg.Text, txtMP.Text, txtZBS.Text, nacimiento, txtCA.Text, txtprov.Text, txtpob.Text, txttitu.Text, txtTIS.Text, txtCAP.Text, txtAS.Text, txtedad.Text);
                MessageBox.Show("Paciente dado de alta.");
            }
        }

        private void cktitu_Checked(object sender, RoutedEventArgs e)
        {
            txttitu.IsEnabled = true;
        }

        private void cktitu_Click(object sender, RoutedEventArgs e)
        {
            txttitu.Text = "";
            if (cktitu.IsChecked == true)
            {
                txttitu.IsEnabled = true;
            }
            if (cktitu.IsChecked == false)
            {
                txttitu.IsEnabled = false;
            }
        }

        /// <summary>
        /// Este botón cierra la ventana
        /// </summary>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = new Window(principal, datos);
            inform.Close();
        }

        /// <summary>
        /// Este método hace que el checkbox sea falso
        /// </summary>
        private void ckNac_Click(object sender, RoutedEventArgs e)
        {
            ckEx.IsChecked = false;
        }

        /// <summary>
        /// Este método hace que el checkbox sea falso
        /// </summary>
        private void ckEx_Click(object sender, RoutedEventArgs e)
        {
            ckNac.IsChecked = false;
        }

        /// <summary>
        /// Este método hace que el combobox sea falso y le da valor a un string
        /// </summary>
        private void ckEx2_Click(object sender, RoutedEventArgs e)
        {
            ckNac2.IsChecked = false;
            nacimiento = "Extranjero";
        }

        /// <summary>
        /// Este método hace que el checkbox sea falso y le da valor a un string
        /// </summary>
        private void ckNac2_Click(object sender, RoutedEventArgs e)
        {
            ckEx2.IsChecked = false;
            nacimiento = "Nacional";
        }

        /// <summary>
        /// Este método hace que el checkbox sea falso
        /// </summary>
        private void ckFall_Click(object sender, RoutedEventArgs e)
        {
            txtFch.Text = "";
            txthora.Text = "";
            if (ckFall.IsChecked == true)
            {
                txtFch.IsEnabled = true;
                txthora.IsEnabled = true;
                fallecido = 1;
            }
            if (ckFall.IsChecked == false)
            {
                txtFch.IsEnabled = false;
                txthora.IsEnabled = false;
                fallecido = 0;
            }
        }

        /// <summary>
        /// Este método le da un valor a un int
        /// </summary>
        private void ckFall_Checked(object sender, RoutedEventArgs e)
        {
            fallecido = 1;
        }

        /// <summary>
        /// Este método le da valor a un string
        /// </summary>
        private void ckNac_Checked(object sender, RoutedEventArgs e)
        {
            nacionalidad = "Nacional";
        }

        /// <summary>
        /// Este método le da valor a un string
        /// </summary>
        private void ckEx_Checked(object sender, RoutedEventArgs e)
        {
            nacionalidad = "Extranjera";
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Este método altera otro combobox según la selección
        /// </summary>
        private void cboComun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboPro.Items.Clear();

                List<string> provincias = datos.SeleccionarProvincias(cboComun.SelectedIndex);
                foreach (string d in provincias)
                {
                    cboPro.Items.Add(d);
                }         
        }

        private void cboPro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        /// <summary>
        /// Este método altera otro combobox según la selección
        /// </summary>
        private void txtCA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtprov.Items.Clear();
            List<string> provincias = datos.SeleccionarProvincias(txtCA.SelectedIndex);
            foreach (string d in provincias)
            {
                txtprov.Items.Add(d);
            }
        }

        private void txtprov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        /// <summary>
        /// Este método rellena una lista tipo string
        /// </summary>
        public void RellenarComunidades()
        {
            List<string> comunidades = datos.SeleccionarComunidades();
            foreach (string d in comunidades)
            {
                cboComun.Items.Add(d);
                txtCA.Items.Add(d);
            }
        }

        // <summary>
        /// Este método rellena una lista tipo string
        /// </summary>
        public void RellenarProvincias()
        {
            List<string> provincias = datos.SeleccionarProvinciasTodas();
            foreach (string d in provincias)
            {
                cboPro.Items.Add(d);
                txtprov.Items.Add(d);
            }
        }

        // <summary>
        /// Este método rellena una lista tipo string
        /// </summary>
        public void RellenarAreas()
        {
            List<string> areas = datos.SeleccionarAreaSalud();
            foreach (string d in areas)
            {
                txtAS.Items.Add(d);
            }
        }

        // <summary>
        /// Este método rellena una lista tipo string
        /// </summary>
        public void RellenarZonas()
        {
            List<string> zonas = datos.SeleccionarTodasZonaBasicas();
            foreach (string d in zonas)
            {
                txtZBS.Items.Add(d);
            }
        }

        // <summary>
        /// Este método rellena una lista tipo string
        /// </summary>
        public void RellenarCentros()
        {
            List<string> centros = datos.SeleccionarTodosCentroSalud();
            foreach (string d in centros)
            {
                txtCAP.Items.Add(d);
            }
        }

        // <summary>
        /// Este método rellena una lista tipo string
        /// </summary>
        public void RellenarCastilla()
        {
            List<string> comunidades = datos.SeleccionarCastilla();
            foreach (string d in comunidades)
            {
                Castilla.Items.Add(d);
            }
        }

        /// <summary>
        /// Este método altera otro combobox según la selección
        /// </summary>
        private void txtAS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtAS.SelectedIndex != 0)
            {
                txtZBS.Items.Clear();
                List<string> zonas = datos.SeleccionarZonaBasica(txtAS.SelectedIndex);
                foreach (string d in zonas)
                {
                    txtZBS.Items.Add(d);
                }
            }
        }

        /// <summary>
        /// Este método altera otro combobox según la selección
        /// </summary>
        private void Castilla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Castilla.SelectedIndex != 0)
            {
                txtCAP.Items.Clear();
                List<string> centros = datos.SeleccionarCentros(Castilla.SelectedIndex);
                foreach (string d in centros)
                {
                    txtCAP.Items.Add(d);
                }
            }          
        }
    }
}
