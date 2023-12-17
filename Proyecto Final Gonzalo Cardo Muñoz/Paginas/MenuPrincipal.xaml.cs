using Proyecto_Final_Gonzalo_Cardo_Muñoz.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Page
    {
        private BBDD datos;
        Window ventana;
        bool visible = false;
        Informe2 inform;
        MainWindow ventanaPrincipal = new MainWindow();
        int idPaciente;
        private ToggleButton botonelegido;
        string NHC;
        string NHCcama;
        string comprobar;
        bool existepaciente;
        string alerta;
        bool hab;
        bool pacama;
        string nhc2;
        string etiqueta;
        bool r;

        /// <summary>
        /// Propiedad que guarda al paciente
        /// </summary>
        public string textob { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MenuPrincipal(BBDD datos, Window v)
        {
            InitializeComponent();
            ventana = v;
            bus.miEvento += MiEventoEventHandler;
            bus.abrirInforme += AbrirInformeEventHandler;
            bus.guardarPaciente += GuardarPacienteEventHandler;
            this.datos = datos;
            if (datos.cuenta == 1)
            {
                btnAdmin.Visibility = Visibility.Visible;
            }
            if (datos.cuenta == 0)
            {   
                btnDarAlta.IsEnabled = false;
                btnBuscar.IsEnabled = false;
                btnDeshabilitar.IsEnabled = false;
                btnHabilitar.IsEnabled = false;
                btnAltaH.IsEnabled = false;
                btnInforme.IsEnabled = false;
                btnPAT.IsEnabled = false;
                btnNotas.IsEnabled = false;
                btnPrescripcion.IsEnabled = false;
                btnAlertas.IsEnabled = false;
                btnIngresar.IsEnabled = false;

                btnDarAlta.Visibility = Visibility.Hidden;
                btnBuscar.Visibility = Visibility.Hidden;
                btnDeshabilitar.Visibility = Visibility.Hidden;
                btnHabilitar.Visibility = Visibility.Hidden;
                btnAltaH.Visibility = Visibility.Hidden;
                btnInforme.Visibility = Visibility.Hidden;
                btnPAT.Visibility = Visibility.Hidden;
                btnNotas.Visibility = Visibility.Hidden;
                btnPrescripcion.Visibility = Visibility.Hidden;
                btnAlertas.Visibility = Visibility.Hidden;
                btnIngresar.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Este botón hace visible el apartado de búsqueda, un user control cuya función es buscar y seleccionar pacientes
        /// </summary>
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (visible == true)
            {
                bus.Visibility = Visibility.Hidden;
                visible = false;
            }
            else
            {
                bus.Visibility = Visibility.Visible;
                visible = true;
            }
        }

        /// <summary>
        /// Este botón abre una ventana que contiene una página cuya función es dar de alta a los paciente (registralos)
        /// </summary>
        private void btnDarAlta_Click(object sender, RoutedEventArgs e)
        {
            Informe inform = new Informe(ventana);
            inform.Show();          
        }

        /// <summary>
        /// Este botón te devuelve a la ventana de acceso, deberás volver a iniciar sesión
        /// </summary>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            VentanaAcceso newpag = new VentanaAcceso(ventanaPrincipal);
            this.NavigationService.Navigate(newpag);
            ventanaPrincipal.Show();
            ventana.Close();
        }

        /// <summary>
        /// Handler de método "Ocultar búsqueda"
        /// </summary>
        private void MiEventoEventHandler()
        {
            OcultarBusqueda();
        }

        /// <summary>
        /// Método que oculta el user control de búsqueda
        /// </summary>
        private void OcultarBusqueda()
        {
            bus.Visibility = Visibility.Hidden;
            visible = false;
        }

        /// <summary>
        /// Handler de método AbrirInforme
        /// </summary>
        private void AbrirInformeEventHandler()
        {
            AbrirInforme();
        }

        /// <summary>
        /// Método que abre la ventana de Informe2, la cual contiene una página donde se ven y editan los datos de los pacientes buscados
        /// </summary>
        private void AbrirInforme()
        {
            inform = new Informe2(ventana, datos, ventanaPrincipal, bus.texto, bus.num, this);
            textob = bus.texto;
            inform.Show();
        }

        /// <summary>
        /// Handler del método GuardarPaciente
        /// </summary>
        private void GuardarPacienteEventHandler()
        {
            GuardarPaciente();
        }

        /// <summary>
        /// Método que guarda en un string el texto seleccionado del control de usuario búsqueda
        /// </summary>
        private void GuardarPaciente()
        {
            textob = bus.texto;
        }

        /// <summary>
        /// Este botón ingresa un paciente en una cama, tomando las precauciones necesarias
        /// </summary>
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textob != null)
                {
                    try
                    {

                        if (botonelegido != null )
                        {
                            if (botonelegido.Background != Brushes.Red)
                            {
                                alerta = "";                                             
                                idPaciente = Int32.Parse(datos.BuscarSS(textob)[0]);

                                if (bus.num == 0)
                                {
                                    NHC = datos.ConseguirNHCconSS(textob);
                                }
                                if (bus.num == 1)
                                {
                                    NHC = datos.ConseguirNHCconDNI(textob);
                                }
                                pacama = datos.ComprobarExistePacienteCama(Int32.Parse(NHC));
                                if (pacama == true)
                                {
                                    nhc2 = datos.ConseguirCamadePaciente(Int32.Parse(NHC));
                                    datos.BorrarNHCCama(Int32.Parse(nhc2));
                                }
                                datos.IngresarPacienteCama(Int32.Parse(botonelegido.Name.Split("_")[1]), idPaciente);
                                if (datos.ComprobarAlerta(Int32.Parse(NHC)) == true)
                                {
                                    alerta = datos.BuscarAlerta(Int32.Parse(NHC));
                                }
                                else
                                {
                                    alerta = "";
                                }
                                Image imagen = new Image();
                                BitmapImage bi3 = new BitmapImage();
                                bi3.BeginInit();
                                if (alerta != "")
                                {
                                    if (datos.ComprobarGenero(NHC) == "Hombre")
                                    {
                                        bi3.UriSource = new Uri("/Resources/camachicoalerta2.png", UriKind.Relative);
                                    }
                                    else if (datos.ComprobarGenero(NHC) == "Mujer")
                                    {
                                        bi3.UriSource = new Uri("/Resources/camachicaalerta2.png", UriKind.Relative);
                                    }
                                    else if (datos.ComprobarGenero(NHC) == "Otro")
                                    {
                                        bi3.UriSource = new Uri("/Resources/camaotroalerta2.png", UriKind.Relative);
                                    }
                                }
                                else
                                {
                                    if (datos.ComprobarGenero(NHC) == "Hombre")
                                    {
                                        bi3.UriSource = new Uri("/Resources/camachico2.png", UriKind.Relative);
                                    }
                                    if (datos.ComprobarGenero(NHC) == "Mujer")
                                    {
                                        bi3.UriSource = new Uri("/Resources/camachica2.png", UriKind.Relative);
                                    }
                                    if (datos.ComprobarGenero(NHC) == "Otro")
                                    {
                                        bi3.UriSource = new Uri("/Resources/camaotro2.png", UriKind.Relative);
                                    }
                                }
                                bi3.EndInit();
                                imagen.Source = bi3;
                                botonelegido.Content = imagen;
                                Refrescar();
                            }
                            else
                            {
                                MessageBox.Show("Esta cama está deshabilitada.");
                            }
                        }
                            
                        else
                        {
                            MessageBox.Show("Por favor, seleccione primero una cama.");
                        }
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Para agregar un paciente, primero debes seleccionar su DNI/NIF o su código de la Seguridad Social en la ventana de búsqueda");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }          
        }

        /// <summary>
        /// Este botón abre la ventana WindowLittle, que contiene una página donde se guardan o alteran las alertas de los pacientes
        /// </summary>
        private void btnAlertas_Click(object sender, RoutedEventArgs e)
        {
            
            if (botonelegido != null)
            {
                existepaciente = datos.ComprobarPacienteCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                NHCcama = datos.BuscarNHCCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                if (existepaciente == true)
                {
                    WindowLittle w = new WindowLittle(this, datos, Int32.Parse(botonelegido.Name.Split("_")[1]), Int32.Parse(NHCcama));
                    w.Show();
                }
                else
                {
                    MessageBox.Show("Esta cama no tiene ningún paciente.");
                }              
            }
        }

        /// <summary>
        /// Este botón deshabilita la cama seleccionada
        /// </summary>
        private void btnDeshabilitar_Click(object sender, RoutedEventArgs e)
        {
            if (botonelegido != null)
            {
                existepaciente = datos.ComprobarPacienteCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                NHCcama = datos.BuscarNHCCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                if (existepaciente == false)
                {
                    if (datos.habilitado == 0)
                    {
                        botonelegido.Background = Brushes.Red;
                        datos.DeshabilitarCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                        botonelegido.IsChecked = false;
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Solo se pueden deshabilitar camas vacías.");
                }
            }                   
        }

        /// <summary>
        /// Este botón habilita la cama seleccionada
        /// </summary>
        private void btnHabilitar_Click(object sender, RoutedEventArgs e)
        {
            if (botonelegido != null)
            {                         
                botonelegido.Background = Brushes.White;
                datos.HabilitarCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                botonelegido.IsChecked = false;
            }
        }

        /// <summary>
        /// Este método deja la cama clicada seleccionada (es un botón)
        /// </summary>
        private void Button_Checked(object sender, RoutedEventArgs e)
        {
            if (botonelegido != null && botonelegido != sender)
            {
                botonelegido.IsChecked = false;
            }
            botonelegido = (ToggleButton)sender;
            NHCcama = datos.BuscarNHCCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
            etiqueta = datos.BuscarPlantaCama(Int32.Parse(botonelegido.Name.Split("_")[1])) + datos.BuscarLetraCama(Int32.Parse(botonelegido.Name.Split("_")[1])) + ". " + datos.BuscarHabCama(Int32.Parse(botonelegido.Name.Split("_")[1]));

            try
            {              
                if (NHCcama != "")
                {
                    etalerta.Content = "Alertas: " + datos.BuscarAlertaNombre(Int32.Parse(NHCcama));
                    etdesc.Content = datos.BuscarAlertaObservacion(Int32.Parse(NHCcama));
                    etnumcama.Content = "Cama: " + etiqueta;
                    etnombre.Content = "Nombre: " + datos.BuscarNHC(NHCcama)[3];
                    etap1.Content = "Apellidos: " + datos.BuscarNHC(NHCcama)[4];
                    etap2.Content = datos.BuscarNHC(NHCcama)[5];
                    etedad.Content = "Edad: " + datos.BuscarNHC(NHCcama)[35];
                }
                else
                { 
                    etalerta.Content = "";
                    etnombre.Content = "";
                    etap1.Content = "";
                    etap2.Content = "";
                    etedad.Content = "";
                    etnumcama.Content = "";
                    etdesc.Content = "";
                }
                
                
            }
            catch (Exception es)
            {
                //MessageBox.Show(es.ToString());
            }                   
        }

        /// <summary>
        /// Este método deja la cama clicada sin seleccionar (es un botón)
        /// </summary>
        private void Button_Unchecked(object sender, RoutedEventArgs e)
        {
            if (botonelegido == sender)
            {
                botonelegido = null;
                etalerta.Content = "";
                etnombre.Content = "";
                etap1.Content = "";
                etap2.Content = "";
                etedad.Content = "";
                etnumcama.Content = "";
                etdesc.Content = "";
            }
        }

        /// <summary>
        /// Este método de comboBox genera y quita las camas en pantalla cuando se selecciona un ItemCombobox suyo
        /// </summary>
        private void planta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (planta1.IsEnabled == false || planta2.IsEnabled == false || planta3.IsEnabled == false || planta4.IsEnabled == false)
            {
                planta0.Content = "Vaciar";
                planta1.IsEnabled = true;
                planta2.IsEnabled = true;
                planta3.IsEnabled = true;
                planta4.IsEnabled = true;
                btnRefrescar.IsEnabled = true;
                btnRefrescar.Background = Brushes.White;
            }
            panel.Children.Clear();
            if (planta.Text != "")
            {               
                foreach (string cama in datos.SeleccionarCamas(planta.SelectedIndex))
                {

                    ToggleButton button = new ToggleButton();
                    string c = "c_";
                    button.Name = c + cama;
                    
                    NHCcama = datos.ConseguirPacienteCama(Int32.Parse(button.Name.Split("_")[1]));
                    if (datos.ComprobarAlerta(Int32.Parse(NHCcama)) == true)
                    {
                        alerta = datos.BuscarAlerta(Int32.Parse(NHCcama));
                    }
                    else
                    {
                        alerta = "";
                    } 
                    Grid grid = new Grid();
                    Image imagen = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    hab = datos.ComprobarCama(Int32.Parse(button.Name.Split("_")[1]));
                    if ( hab == true)
                    {
                        button.Background = Brushes.Red;
                    }
                    else
                    {
                        button.Background = Brushes.White;
                    }
                    if ( alerta != "")
                    {
                        if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Hombre")
                        {
                            bi3.UriSource = new Uri("/Resources/camachicoalerta2.png", UriKind.Relative);
                        }
                        else if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Mujer")
                        {
                            bi3.UriSource = new Uri("/Resources/camachicaalerta2.png", UriKind.Relative);
                        }
                        else if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Otro")
                        {
                            bi3.UriSource = new Uri("/Resources/camaotroalerta2.png", UriKind.Relative);
                        }
                        else
                        {
                            bi3.UriSource = new Uri("/Resources/cama2.png", UriKind.Relative);
                        }
                    }
                    else
                    {
                        if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Hombre")
                        {
                            bi3.UriSource = new Uri("/Resources/camachico2.png", UriKind.Relative);
                        }
                        else if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Mujer")
                        {
                            bi3.UriSource = new Uri("/Resources/camachica2.png", UriKind.Relative);
                        }
                        else if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Otro")
                        {
                            bi3.UriSource = new Uri("/Resources/camaotro2.png", UriKind.Relative);
                        }
                        else
                        {
                            bi3.UriSource = new Uri("/Resources/cama2.png", UriKind.Relative);
                        }
                    }                    
                    bi3.EndInit();
                    imagen.Source = bi3;
                    etiqueta = datos.BuscarPlantaCama(Int32.Parse(cama)) + datos.BuscarLetraCama(Int32.Parse(cama)) + ". " + datos.BuscarHabCama(Int32.Parse(cama));

                    TextBlock textBlock = new TextBlock();
                    textBlock.Foreground = Brushes.DarkBlue;
                    textBlock.FontWeight = FontWeights.Bold;
                    textBlock.FontSize = 08;
                    textBlock.Text = etiqueta;
                    button.Content = grid;
                    button.Height = 90;
                    button.Width = 70;
                    button.Checked += Button_Checked;
                    button.Unchecked += Button_Unchecked;

                    grid.Children.Add(imagen);
                    grid.Children.Add(textBlock);
                    panel.Children.Add(button);
                }
            } 
        }

        /// <summary>
        /// Este botón abre la ventana de alta hospitalaria
        /// </summary>
        private void btnAltaH_Click(object sender, RoutedEventArgs e)
        {
            
            if (botonelegido != null)
            {
                existepaciente = datos.ComprobarPacienteCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                if (existepaciente == true)
                {
                    WindowAlta a = new WindowAlta(datos, Int32.Parse(botonelegido.Name.Split("_")[1]), this);
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Esta cama no tiene ningún paciente, prueba a refrescar la página.");
                }
                
            }
        }
        /// <summary>
        /// Este botón no está disponible
        /// </summary>
        private void btnInforme_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Esta función no está disponible por el momento.");
        }

        /// <summary>
        /// Este botón utiliza el método Refrescar, el cual se utiliza en varios métodos, tales como en ingrsear pacientes y en guardar o borrar alertas.
        /// </summary>
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            Refrescar();
        }

        /// <summary>
        /// Método que vuelve a cargar las camas, se utiliza cuando hay alteraciones en las mismas
        /// </summary>
        public void Refrescar()
        {
            /*
            Thread t = new Thread(Recargando);
            t.Start();
            
            if (r == true)
            {
                recargar.Content = "Recargando camas...";
            }
            */
            Thread.Sleep(2000);
            panel.Children.Clear();
            if (planta.Text != "")
            {
                foreach (string cama in datos.SeleccionarCamas(planta.SelectedIndex))
                {
                    
                    ToggleButton button = new ToggleButton();
                    string c = "c_";
                    button.Name = c + cama;

                    NHCcama = datos.ConseguirPacienteCama(Int32.Parse(button.Name.Split("_")[1]));
                    if (datos.ComprobarAlerta(Int32.Parse(NHCcama)) == true)
                    {
                        alerta = datos.BuscarAlerta(Int32.Parse(NHCcama));
                    }
                    else
                    {
                        alerta = "";
                    }
                    Grid grid = new Grid();
                    Image imagen = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    hab = datos.ComprobarCama(Int32.Parse(button.Name.Split("_")[1]));
                    if (hab == true)
                    {
                        button.Background = Brushes.Red;
                    }
                    else
                    {
                        button.Background = Brushes.White;
                    }
                    if (alerta != "")
                    {
                        if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Hombre")
                        {
                            bi3.UriSource = new Uri("/Resources/camachicoalerta2.png", UriKind.Relative);
                        }
                        else if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Mujer")
                        {
                            bi3.UriSource = new Uri("/Resources/camachicaalerta2.png", UriKind.Relative);
                        }
                        else if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Otro")
                        {
                            bi3.UriSource = new Uri("/Resources/camaotroalerta2.png", UriKind.Relative);
                        }
                        else
                        {
                            bi3.UriSource = new Uri("/Resources/cama2.png", UriKind.Relative);
                        }
                    }
                    else
                    {
                        if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Hombre")
                        {
                            bi3.UriSource = new Uri("/Resources/camachico2.png", UriKind.Relative);
                        }
                        else if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Mujer")
                        {
                            bi3.UriSource = new Uri("/Resources/camachica2.png", UriKind.Relative);
                        }
                        else if (datos.ComprobarGenero(datos.BuscarNHCCama(Int32.Parse(cama))) == "Otro")
                        {
                            bi3.UriSource = new Uri("/Resources/camaotro2.png", UriKind.Relative);
                        }
                        else
                        {
                            bi3.UriSource = new Uri("/Resources/cama2.png", UriKind.Relative);
                        }
                    }
                    bi3.EndInit();
                    imagen.Source = bi3;
                    etiqueta = datos.BuscarPlantaCama(Int32.Parse(cama)) + datos.BuscarLetraCama(Int32.Parse(cama)) + ". " + datos.BuscarHabCama(Int32.Parse(cama));
                    TextBlock textBlock = new TextBlock();
                    //textBlock.Text = cama;
                    textBlock.Text = etiqueta;
                    textBlock.Foreground = Brushes.DarkBlue;
                    textBlock.FontWeight = FontWeights.Bold;
                    textBlock.FontSize = 09;
                    button.Content = grid;
                    button.Height = 90;
                    button.Width = 70;
                    button.Checked += Button_Checked;
                    button.Unchecked += Button_Unchecked;

                    grid.Children.Add(imagen);
                    grid.Children.Add(textBlock);
                    panel.Children.Add(button);
                }
            }
            //MessageBox.Show("Camas recargadas.");            
        }
        /*
        public void Recargando()
        {
            try
            {
                r = true;
                Thread.Sleep(2000);
                Recargandont();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        public void Recargandont()
        {
            recargar.Content = "";
        }*/

        /// <summary>
        /// Este botón no está disponible
        /// </summary>
        private void btnProcesos_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Este botón abre la ventana que contiene las notas de enfermería del paciente
        /// </summary>
        private void btnNotas_Click(object sender, RoutedEventArgs e)
        {           
            if (botonelegido != null)
            {
                existepaciente = datos.ComprobarPacienteCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                NHCcama = datos.BuscarNHCCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                if (existepaciente == true)
                {
                    WindowProcesos p = new WindowProcesos(datos, Int32.Parse(NHCcama));
                    p.Show();
                }
                else
                {
                    MessageBox.Show("Esta cama no tiene ningún paciente.");
                }
            }
        }

        /// <summary>
        /// Este botón abre la ventana que contiene las hojas de prescripción del paciente
        /// </summary>
        private void btnPrescripcion_Click(object sender, RoutedEventArgs e)
        {       
            if (botonelegido != null)
            {
                existepaciente = datos.ComprobarPacienteCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                NHCcama = datos.BuscarNHCCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                if (existepaciente == true)
                {
                    WindowPrep p = new WindowPrep(datos, Int32.Parse(NHCcama));
                    p.Show();
                }
                else
                {
                    MessageBox.Show("Esta cama no tiene ningún paciente.");
                }
            }
        }

        /// <summary>
        /// Este botón abre la ventana que contiene las patología/alteración/trastorno
        /// </summary>
        private void btnPAT_Click(object sender, RoutedEventArgs e)
        {            
            if (botonelegido != null)
            {
                existepaciente = datos.ComprobarPacienteCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                NHCcama = datos.BuscarNHCCama(Int32.Parse(botonelegido.Name.Split("_")[1]));
                if (existepaciente == true)
                {
                    WindowPAT p = new WindowPAT(datos, Int32.Parse(NHCcama));
                    p.Show();
                }
                else
                {
                    MessageBox.Show("Esta cama no tiene ningún paciente.");
                }
            }
        }

        /// <summary>
        /// Este botón pasa a la página de administrador, solo visible para el administrador
        /// </summary>
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdministrarPagina newpag = new AdministrarPagina(datos);
            this.NavigationService.Navigate(newpag);
        }
    }
}
