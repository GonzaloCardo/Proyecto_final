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
    /// Lógica de interacción para VentanaVerFormulario.xaml
    /// </summary>
    public partial class VentanaVerFormulario : Page
    {
        Informe2 inform;
        BBDD datos;
        MainWindow principal;
        int num;
        int fallecido;
        string nacionalidad;
        string nacimiento;
        MenuPrincipal menu;
        int idPaciente;

        /// <summary>
        /// Constructor
        /// </summary>
        public VentanaVerFormulario(Informe2 informe, MainWindow p, BBDD datos, string texto, int num, MenuPrincipal m)
        {
            InitializeComponent();
            texto = texto;
            principal = p;
            this.num = num;
            this.inform = informe;
            this.datos = datos;
            this.menu = m;            
            RellenarComunidades();
            RellenarProvincias();
            RellenarAreas();
            RellenarZonas();
            RellenarCentros();
            RellenarCastilla();
            Busqueda(texto, num);
        }

        /// <summary>
        /// Este botón cierra la ventana
        /// </summary>
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = new Window(principal, datos);
            inform.Close();
        }

        /// <summary>
        /// Este botón activa el modo edición, se pueden editar los datos y los botones cambian
        /// </summary>
        private void Editar_Click(object sender, RoutedEventArgs e)
        {

            if (cktitu.IsChecked == true)
            {
                txttitu.IsEnabled = true;
            }

            btnCancelar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Visible;
            Editar.Visibility = Visibility.Hidden;
            btnAceptar.Visibility = Visibility.Hidden;
            TodoEnabled();
        }

        private void txtCA_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Este botón cancela el modo edición
        /// </summary>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            btnCancelar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Hidden;
            Editar.Visibility = Visibility.Visible;
            btnAceptar.Visibility = Visibility.Visible;
            Busqueda(menu.textob, num);
            NadaEnabled();
        }

        /// <summary>
        /// Este botón guarda los cambios hechos
        /// </summary>
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            datos.Actualizar(txtMHC.Text, txtNIF.Text, cboEstado.Text, cboAmbito.Text, txtNombre.Text, txtAp1.Text, txtap2.Text, txtSexo.Text, txtFchN.Text, txtTlf1.Text, txtTlf2.Text, txtmov.Text, txtCivil.Text, txtEst.Text, fallecido, txtFch.Text, txthora.Text, nacionalidad, cboComun.Text, cboPro.Text, txtPob.Text, txtCP.Text, txtDir.Text, txtNSS.Text, txtreg.Text, txtMP.Text, txtZBS.Text, nacimiento, txtCA.Text, txtprov.Text, txtpob.Text, txttitu.Text, txtTIS.Text, txtCAP.Text, txtAS.Text, txtedad.Text);
            MessageBox.Show("Paciente actualizado.");
            btnAceptar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;
            Editar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Hidden;
            NadaEnabled();

        }

        /// <summary>
        /// Este método muestra los datos del paciente
        /// </summary>
        private void Busqueda(string texto, int num)
        {
            try
            {
                if (num == 0)
                {

                    txtMHC.Text = datos.BuscarSS(texto)[0];
                    cboEstado.Text = datos.BuscarSS(texto)[1];
                    cboAmbito.Text = datos.BuscarSS(texto)[2];
                    txtNombre.Text = datos.BuscarSS(texto)[3];
                    txtAp1.Text = datos.BuscarSS(texto)[4];
                    txtap2.Text = datos.BuscarSS(texto)[5];
                    txtSexo.Text = datos.BuscarSS(texto)[6];
                    txtFchN.Text = datos.BuscarSS(texto)[7];
                    txtTlf1.Text = datos.BuscarSS(texto)[8];
                    txtTlf2.Text = datos.BuscarSS(texto)[9];
                    txtmov.Text = datos.BuscarSS(texto)[10];
                    txtCivil.Text = datos.BuscarSS(texto)[11];
                    txtEst.Text = datos.BuscarSS(texto)[12];

                    if (datos.BuscarSS(texto)[13] == "1")
                    {
                        ckFall.IsChecked = true;
                        txtFch.Text = datos.BuscarSS(texto)[14];
                        txthora.Text = datos.BuscarSS(texto)[15];
                    }
                    else
                    {
                        ckFall.IsChecked = false;
                    }

                    if (datos.BuscarSS(texto)[16] == "Extranjera")
                    {
                        ckEx.IsChecked = true;
                    }
                    if (datos.BuscarSS(texto)[16] == "Nacional")
                    {
                        ckNac.IsChecked = true;
                    }

                    txtNIF.Text = datos.BuscarSS(texto)[17];
                    cboComun.Text = datos.BuscarSS(texto)[18];
                    cboPro.Text = datos.BuscarSS(texto)[19];
                    txtPob.Text = datos.BuscarSS(texto)[20];
                    txtCP.Text = datos.BuscarSS(texto)[21];
                    txtDir.Text = datos.BuscarSS(texto)[22];
                    txtNSS.Text = datos.BuscarSS(texto)[23];
                    txtreg.Text = datos.BuscarSS(texto)[24];
                    txtMP.Text = datos.BuscarSS(texto)[25];
                    txtZBS.Text = datos.BuscarSS(texto)[26];

                    if (datos.BuscarSS(texto)[27] == "Extranjero")
                    {
                        ckEx2.IsChecked = true;
                    }
                    if (datos.BuscarSS(texto)[27] == "Nacional")
                    {
                        ckNac2.IsChecked = true;
                    }

                    txtCA.Text = datos.BuscarSS(texto)[28];
                    txtprov.Text = datos.BuscarSS(texto)[29];
                    txtpob.Text = datos.BuscarSS(texto)[30];

                    if (datos.BuscarSS(texto)[31] != "null")
                    {
                        cktitu.IsChecked = true;
                        txttitu.Text = datos.BuscarSS(texto)[31];
                    }

                    txtTIS.Text = datos.BuscarSS(texto)[32];
                    txtCAP.Text = datos.BuscarSS(texto)[33];
                    txtAS.Text = datos.BuscarSS(texto)[34];
                    txtedad.Text = datos.BuscarSS(texto)[35];
                }
                if (num == 1)
                {
                    txtMHC.Text = datos.BuscarDNI(texto)[0];
                    cboEstado.Text = datos.BuscarDNI(texto)[1];
                    cboAmbito.Text = datos.BuscarDNI(texto)[2];
                    txtNombre.Text = datos.BuscarDNI(texto)[3];
                    txtAp1.Text = datos.BuscarDNI(texto)[4];
                    txtap2.Text = datos.BuscarDNI(texto)[5];
                    txtSexo.Text = datos.BuscarDNI(texto)[6];
                    txtFchN.Text = datos.BuscarDNI(texto)[7];
                    txtTlf1.Text = datos.BuscarDNI(texto)[8];
                    txtTlf2.Text = datos.BuscarDNI(texto)[9];
                    txtmov.Text = datos.BuscarDNI(texto)[10];
                    txtCivil.Text = datos.BuscarDNI(texto)[11];
                    txtEst.Text = datos.BuscarDNI(texto)[12];

                    if (datos.BuscarDNI(texto)[13] == "1")
                    {
                        ckFall.IsChecked = true;
                        txtFch.Text = datos.BuscarDNI(texto)[14];
                        txthora.Text = datos.BuscarDNI(texto)[15];
                    }
                    else
                    {
                        ckFall.IsChecked = false;
                    }

                    if (datos.BuscarDNI(texto)[16] == "Extranjera")
                    {
                        ckEx.IsChecked = true;
                    }
                    if (datos.BuscarDNI(texto)[16] == "Nacional")
                    {
                        ckNac.IsChecked = true;
                    }

                    txtNIF.Text = datos.BuscarDNI(texto)[17];
                    cboComun.Text = datos.BuscarDNI(texto)[18];
                    cboPro.Text = datos.BuscarDNI(texto)[19];
                    txtPob.Text = datos.BuscarDNI(texto)[20];
                    txtCP.Text = datos.BuscarDNI(texto)[21];
                    txtDir.Text = datos.BuscarDNI(texto)[22];
                    txtNSS.Text = datos.BuscarDNI(texto)[23];
                    txtreg.Text = datos.BuscarDNI(texto)[24];
                    txtMP.Text = datos.BuscarDNI(texto)[25];
                    txtZBS.Text = datos.BuscarDNI(texto)[26];

                    if (datos.BuscarDNI(texto)[27] == "Extranjero")
                    {
                        ckEx2.IsChecked = true;
                    }
                    if (datos.BuscarDNI(texto)[27] == "Nacional")
                    {
                        ckNac2.IsChecked = true;
                    }

                    txtCA.Text = datos.BuscarDNI(texto)[28];
                    txtprov.Text = datos.BuscarDNI(texto)[29];
                    txtpob.Text = datos.BuscarDNI(texto)[30];

                    if (datos.BuscarDNI(texto)[31] != "null")
                    {
                        cktitu.IsChecked = true;
                        txttitu.Text = datos.BuscarDNI(texto)[31];
                    }

                    txtTIS.Text = datos.BuscarDNI(texto)[32];
                    txtCAP.Text = datos.BuscarDNI(texto)[33];
                    txtAS.Text = datos.BuscarDNI(texto)[34];
                    txtedad.Text = datos.BuscarDNI(texto)[35];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se ha encontrado ningún paciente con esas credenciales.");
            }

        }

        private void cktitu_Checked(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Este método hace que el checkbox sea falso
        /// </summary>
        private void cktitu_Click(object sender, RoutedEventArgs e)
        {
            if (cktitu.IsChecked == true)
            {
                txttitu.IsEnabled = true;
            }
            if (cktitu.IsChecked == false)
            {
                txttitu.IsEnabled = false;
                txttitu.Text = "";
            }

        }

        /// <summary>
        /// Este método hace que el checkbox sea falso
        /// </summary>
        private void ckEx2_Click(object sender, RoutedEventArgs e)
        {
            ckNac2.IsChecked = false;
        }

        /// <summary>
        /// Este método hace que el checkbox sea falso
        /// </summary>
        private void ckNac2_Click(object sender, RoutedEventArgs e)
        {
            ckEx2.IsChecked = false;
        }

        /// <summary>
        /// Este método hace que el checkbox sea falso y altera varios textbox
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
        /// Este método modifica el valor de un int
        /// </summary>
        private void ckFall_Checked(object sender, RoutedEventArgs e)
        {
            fallecido = 1;
        }

        /// <summary>
        /// Este método modifica el valor de un string
        /// </summary>
        private void ckNac_Checked(object sender, RoutedEventArgs e)
        {
            nacionalidad = "Nacional";
        }

        /// <summary>
        /// Este método modifica el valor de un string
        /// </summary>
        private void ckEx_Checked(object sender, RoutedEventArgs e)
        {
            nacionalidad = "Nacional";
        }

        /// <summary>
        /// Este método modifica el valor de un string
        /// </summary>
        private void ckEx2_Checked(object sender, RoutedEventArgs e)
        {
            nacimiento = "Extranjero";
        }

        /// <summary>
        /// Este método modifica el valor de un string
        /// </summary>
        private void ckNac2_Checked(object sender, RoutedEventArgs e)
        {
            nacimiento = "Nacional";
        }

        /// <summary>
        /// Este método hace que los datos sean editables
        /// </summary>
        private void TodoEnabled()
        {
            cboEstado.IsEnabled = true;
            cboAmbito.IsEnabled = true;
            txtNombre.IsEnabled = true;
            txtAp1.IsEnabled = true;
            txtap2.IsEnabled = true;
            txtSexo.IsEnabled = true;
            txtFchN.IsEnabled = true;
            txtTlf1.IsEnabled = true;
            txtTlf2.IsEnabled = true;
            txtmov.IsEnabled = true;
            txtCivil.IsEnabled = true;
            txtEst.IsEnabled = true;
            cboComun.IsEnabled = true;
            cboPro.IsEnabled = true;
            txtPob.IsEnabled = true;
            txtCP.IsEnabled = true;
            txtDir.IsEnabled = true;
            txtNSS.IsEnabled = true;
            txtreg.IsEnabled = true;
            txtMP.IsEnabled = true;
            txtZBS.IsEnabled = true;
            txtCA.IsEnabled = true;
            txtprov.IsEnabled = true;
            txtpob.IsEnabled = true;
            txtTIS.IsEnabled = true;
            txtCAP.IsEnabled = true;
            txtAS.IsEnabled = true;
            txtNIF2.IsEnabled = true;
            ckEx.IsEnabled = true;
            ckNac.IsEnabled = true;
            ckFall.IsEnabled = true;
            ckNac2.IsEnabled = true;
            ckEx2.IsEnabled = true;
            cktitu.IsEnabled = true;
            txtedad.IsEnabled = true;
        }

        /// <summary>
        /// Este método hace que ningún sea editable
        /// </summary>
        private void NadaEnabled()
        {
            cboEstado.IsEnabled = false;
            cboAmbito.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtAp1.IsEnabled = false;
            txtap2.IsEnabled = false;
            txtSexo.IsEnabled = false;
            txtFchN.IsEnabled = false;
            txtTlf1.IsEnabled = false;
            txtTlf2.IsEnabled = false;
            txtmov.IsEnabled = false;
            txtCivil.IsEnabled = false;
            txtEst.IsEnabled = false;
            txtFch.IsEnabled = false;
            txthora.IsEnabled = false;
            txtNIF.IsEnabled = false;
            cboComun.IsEnabled = false;
            cboPro.IsEnabled = false;
            txtPob.IsEnabled = false;
            txtCP.IsEnabled = false;
            txtDir.IsEnabled = false;
            txtNSS.IsEnabled = false;
            txtreg.IsEnabled = false;
            txtMP.IsEnabled = false;
            txtZBS.IsEnabled = false;
            txtCA.IsEnabled = false;
            txtprov.IsEnabled = false;
            txtpob.IsEnabled = false;
            txttitu.IsEnabled = false;
            txtTIS.IsEnabled = false;
            txtCAP.IsEnabled = false;
            txtAS.IsEnabled = false;
            txtNIF2.IsEnabled = false;
            ckEx.IsEnabled = false;
            ckNac.IsEnabled = false;
            ckFall.IsEnabled = false;
            ckNac2.IsEnabled = false;
            ckEx2.IsEnabled = false;
            cktitu.IsEnabled = false;
            txtedad.IsEnabled = false;  
        }

        private void Seleccionar_Click(object sender, RoutedEventArgs e)
        {         
            //MessageBox.Show("Datos del paciente seleccionados.");             
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

        /// <summary>
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

        /// <summary>
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

        /// <summary>
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

        /// <summary>
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

        /// <summary>
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
        /// Este método rellena una lista tipo string
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
    }
}
