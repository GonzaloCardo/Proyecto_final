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

namespace Proyecto_Final_Gonzalo_Cardo_Muñoz.Controles
{
    /// <summary>
    /// Lógica de interacción para Busqueda.xaml
    /// </summary>
    public partial class Busqueda : UserControl
    {
        BBDD datos;
        public delegate void MiEvento();
        public event MiEvento miEvento;
        public delegate void AbrirInforme();
        public event AbrirInforme abrirInforme;
        public delegate void GuardarPaciente();
        public event GuardarPaciente guardarPaciente;

        /// <summary>
        /// Propiedad que guarda el dato con el que se busca al paciente
        /// </summary>
        public string texto { get; set; }
        /// <summary>
        /// Propiedad que guarda un número
        /// </summary>
        public int num { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Busqueda()
        {
            InitializeComponent();
            datos = new BBDD();
        }

        /// <summary>
        /// Este botón confirma la búsqueda cogiendo como información el texto del textbox. Esto lo hace mediante eventos
        /// </summary>
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (btnSS.IsChecked == true)
            {
                if (abrirInforme != null)
                {
                    texto = txtbuscar.Text;
                    num = 0;
                    abrirInforme(); // se lanza el evento
                    
                }
            }
            if (btnDNI.IsChecked == true)
            {
                if (abrirInforme != null)
                {
                    texto = txtbuscar.Text;
                    num = 1;
                    abrirInforme(); // se lanza el evento
                    
                }
            }
            if (btnSS.IsChecked == false & btnDNI.IsChecked == false)
            {
                MessageBox.Show("Es necesario marcar una opción, número de seguridad social o DNI/NIF.");
            }
        }

        /// <summary>
        /// Este botón cierra el user control mediante un evento
        /// </summary>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtbuscar.Text = "";
            btnSS.IsChecked = false;
            btnDNI.IsChecked = false;
            if (miEvento != null)
            {
                miEvento(); // se lanza el evento
            }
        }

        /// <summary>
        /// Este botón guarda en una propiedad la información del textbox
        /// </summary>
        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (btnSS.IsChecked == true)
                {
                    if (txtbuscar.Text != "")
                    {
                        texto = txtbuscar.Text;
                        num = 0;
                        if (datos.ComprobarPacienteSS(texto) != false)
                        {
                            datos.ComprobarPacienteSS(texto);
                            guardarPaciente();
                            MessageBox.Show("Paciente seleccionado.");
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido encontrar al paciente que quieres seleccionar.");
                        }
                    }
                }
                if (btnDNI.IsChecked == true)
                {
                    if (txtbuscar.Text != "")
                    {
                        texto = txtbuscar.Text;
                        num = 1;
                        if (datos.ComprobarPaciente(texto) != false)
                        {
                            MessageBox.Show("Para seleccionar un paciente, por favor hágalo usando el Número de Seguridad Social.");
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido encontrar al paciente que quieres seleccionar.");
                        }
                    }
                }
                else if (btnSS.IsChecked == false & btnDNI.IsChecked == false)
                {
                    MessageBox.Show("Es necesario marcar una opción, número de seguridad social o DNI/NIF.");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ha habido un error.");
            }
                   
        }
    }
}
