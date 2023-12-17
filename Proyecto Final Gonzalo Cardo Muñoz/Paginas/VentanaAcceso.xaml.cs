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
    /// Lógica de interacción para VentanaAcceso.xaml
    /// </summary>
    public partial class VentanaAcceso : Page
    {
        MainWindow p;
        private BBDD miBase = new BBDD();

        /// <summary>
        /// Constructor
        /// </summary>
        public VentanaAcceso(MainWindow principal)
        {
            InitializeComponent();
            p = principal;
        }

        /// <summary>
        /// Este botón comprueba si la conexión es posible y oculta la ventana visible para hacer visible la siguiente
        /// </summary>
        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            miBase.Conectar(textousuario.Text, textoclave.Password);
            if (miBase.cuenta == 0 || miBase.cuenta == 1 || miBase.cuenta == 2)
            {
                etusuario.Visibility = Visibility.Hidden;
                etclave.Visibility = Visibility.Hidden;
                textousuario.Visibility = Visibility.Hidden;
                textoclave.Visibility = Visibility.Hidden;
                BtnAceptar.Visibility = Visibility.Hidden;
                BtnRegistrar.Visibility = Visibility.Hidden;
                texto.Visibility = Visibility.Hidden;

                texto2.Visibility = Visibility.Visible;
                lambito.Visibility = Visibility.Visible;
                ltuser.Visibility = Visibility.Visible;
                ambito.Visibility = Visibility.Visible;
                tusuario.Visibility = Visibility.Visible;
                btnAceptar2.Visibility = Visibility.Visible;
                btnCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                textousuario.Text = "";
                textoclave.Password = "";
            }
        }

        private void Acceso_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Este botón te lleva a la página de registro
        /// </summary>
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Registrarse newpag = new Registrarse(p);
            this.NavigationService.Navigate(newpag);
        }

        /// <summary>
        /// Este botón comprueba si el ambito y el tipo de usuario son correctos para dar paso a la siguiente ventana con el menú
        /// </summary>
        private void btnAceptar2_Click(object sender, RoutedEventArgs e)
        {
            if (hospitalizacion.IsSelected)
            {
                if (administrativo.IsSelected)
                {
                    Window ventana = new Window(p, miBase);
                    ventana.Show();
                    p.Close();
                }
                else
                {
                    MessageBox.Show("No está disponible un tipo de usuario que no sea \"Administrativo\".");
                }
            }
            else
            {
                MessageBox.Show("No está disponible un ámbito que no sea \"Hospitalización\".");
            }
        }

        /// <summary>
        /// Este botón te devuelve al apartado de inicio de sesión
        /// </summary>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            etusuario.Visibility = Visibility.Visible;
            etclave.Visibility = Visibility.Visible;
            textousuario.Visibility = Visibility.Visible;
            textoclave.Visibility = Visibility.Visible;
            BtnAceptar.Visibility = Visibility.Visible;
            BtnRegistrar.Visibility = Visibility.Visible;
            texto.Visibility = Visibility.Visible;

            texto2.Visibility = Visibility.Hidden;
            lambito.Visibility = Visibility.Hidden;
            ltuser.Visibility = Visibility.Hidden;
            ambito.Visibility = Visibility.Hidden;
            tusuario.Visibility = Visibility.Hidden;
            btnAceptar2.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;

        }
        private void BtnBase_Click(object sender, RoutedEventArgs e)
        {
            PaginaConfi newpag = new PaginaConfi();
            this.NavigationService.Navigate(newpag);
        }
    }
}
