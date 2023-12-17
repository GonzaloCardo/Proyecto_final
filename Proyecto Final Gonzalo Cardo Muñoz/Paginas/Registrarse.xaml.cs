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
    /// Lógica de interacción para Registrarse.xaml
    /// </summary>
    public partial class Registrarse : Page
    {
        private BBDD miBase;
        MainWindow p;
        /// <summary>
        /// Constructor
        /// </summary>
        public Registrarse(MainWindow principal)
        {
            InitializeComponent();
            this.p = principal;
        }

        /// <summary>
        /// Este botón registra un nuevo usuario con la información escrita, el nombre de usuario no puede estar registrado en la base de datos
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text == "" || txtApellido1.Text == "" || txtApellido2.Text == "" || txtcontraseña.Text == "" || txtemail.Text == "")
            {
                MessageBox.Show("Por favor, rellena todos los campos.");
            }
            else
            {
                try
                {
                    miBase = new BBDD();
                    miBase.Registrar(txtnombre.Text, txtApellido1.Text, txtApellido2.Text, txtcontraseña.Text, txtemail.Text);

                    try
                    {
                        miBase.Conectar2(txtnombre.Text, txtcontraseña.Text);
                        if (miBase.cuenta == 0 || miBase.cuenta == 1 || miBase.cuenta == 2)
                        {
                            MessageBox.Show("Usuario registrado correctamente.");
                            VentanaAcceso newpag = new VentanaAcceso(p);
                            this.NavigationService.Navigate(newpag);
                        }
                    }
                    catch (Exception ef)
                    {
                        MessageBox.Show(ef.Message);
                    }
                }
                catch (Exception es)
                {
                   // MessageBox.Show("El nombre de usuario ya existe.");
                }
            }
        }
    }
}
