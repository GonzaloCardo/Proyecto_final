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
    /// Lógica de interacción para PaginaConfi.xaml
    /// </summary>
    public partial class PaginaConfi : Page
    {
        //CONFIGURACIÓN HERVÁS
        /*
         /// <summary>
        /// Propiedad para conectarse a la base
        /// </summary>
        public string server { get; set; } = "10.123.36.10";
        /// <summary>
        /// Propiedad para conectarse a la base
        /// </summary>
        public string port { get; set; } = "3306";
        /// <summary>
        /// Propiedad para conectarse a la base
        /// </summary>
        public string user { get; set; } = "Hervas";
        /// <summary>
        /// Propiedad para conectarse a la base
        /// </summary>
        public string password { get; set; } = "mambrino";
        */

        //MI CONFIGURACIÓN
        
        /// <summary>
        /// Propiedad para conectarse a la base
        /// </summary>
        public string server { get; set; } = "localhost";
        /// <summary>
        /// Propiedad para conectarse a la base
        /// </summary>
        public string port { get; set; } = "3306";
        /// <summary>
        /// Propiedad para conectarse a la base
        /// </summary>
        public string user { get; set; } = "root";
        /// <summary>
        /// Propiedad para conectarse a la base
        /// </summary>
        public string password { get; set; } = "1234";
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PaginaConfi()
        {
            InitializeComponent();
            txtserver.Text = server;
            txtport.Text = port;
            txtuser.Text = user;
            txtpassword.Text = password;
        }

        /// <summary>
        /// Este botón cambia el valor de las propiedades de la clase al valor escrito en los textbox 
        /// </summary>
        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtserver.Text != "" || txtport.Text != "" || txtuser.Text != "" || txtpassword.Text != "")
            {
                server = txtserver.Text;
                port = txtport.Text;
                user = txtuser.Text;
                password = txtpassword.Text;
                MessageBox.Show("Configuración establecida.");
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacíos.");
            }
           
        }
    }
}
