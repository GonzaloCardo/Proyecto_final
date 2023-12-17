using Google.Protobuf.WellKnownTypes;
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
    /// Lógica de interacción para AdministrarPagina.xaml
    /// </summary>
    public partial class AdministrarPagina : Page
    {
        BBDD datos;
        /// <summary>
        /// Constructor
        /// </summary>
        public AdministrarPagina(BBDD datos)
        {
            InitializeComponent();
            this.datos = datos;
            Refrescar();
        }

        /// <summary>
        /// Este método genera una lista de usuarios
        /// </summary>
        private void Refrescar()
        {
            List<string> lista = datos.VerUsuarios();

            foreach (string d in lista)
            {
                ListaUsuarios.Items.Add(d);
            }
        }

        /// <summary>
        /// Este botón borra de la base de datos al usuario seleccionado
        /// </summary>
        private void BotonBorrar_Click(object sender, RoutedEventArgs e)
        {
            datos = new BBDD();
            if (textuser.Text == "")
            {
                MessageBox.Show("Por favor, introduce un nombre de usuario.");
            }
            else
            {
                datos.ConectarLittle(textuser.Text);
                if (datos.cuenta == 1)
                {
                    MessageBox.Show("No puedes eliminar un administrador.");
                }
                else if (datos.cuenta == -1)
                {
                    MessageBox.Show("Usuario no existente");
                }
                else if (datos.cuenta == 0)
                {
                    datos.BorrarUsuario(textuser.Text);
                    MessageBox.Show("El usuario " + textuser.Text + " ha sido borrado.");
                }
            }
            textuser.Text = "";
            ListaUsuarios.Items.Clear();
            Refrescar();
        }

        /// <summary>
        /// Este método de Listbox escribe el nombre del usuario seleccionado en la barra de búsqueda
        /// </summary>
        private void ListaUsuarios_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string user = ListaUsuarios.SelectedItem.ToString();
            textuser.Text = user;
        }

        /// <summary>
        /// Este botón elimina de la base de datos
        /// </summary>
        private void BotonBorrarTODO_Click(object sender, RoutedEventArgs e)
        {
            datos.BorrarTodo();
            MessageBox.Show("Todos los pacientes y sus datos han sido borrados.");
        }

        /// <summary>
        /// Este botón actualiza el nombre del administrador con el texto escrito en la barra
        /// </summary>
        private void BotonNombre_Click(object sender, RoutedEventArgs e)
        {
            if (textnombre.Text != "")
            {
                datos.ActualizarNombreAdmin(textnombre.Text);
                MessageBox.Show("Nombre del administrador cambiado a " + textnombre.Text + ".");
                ListaUsuarios.Items.Clear();
                Refrescar();
            }
            else
            {
                MessageBox.Show("No puedes actualizar el nombre estando el campo vacío.");
            }
        }

        /// <summary>
        /// Este botón actualiza la contraseña escrita, comprueba que sea la misma en ambos campos
        /// </summary>
        private void BotonContraseña_Click(object sender, RoutedEventArgs e)
        {
            if (txtcontra.Password != "" && txtcontra2.Password != "")
            {
                if (txtcontra.Password == txtcontra2.Password)
                {
                    datos.ActualizarContraseñaAdmin(txtcontra.Password);
                    MessageBox.Show("Contraseña del administrador cambiada.");
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                }
            }
            else
            {
                MessageBox.Show("No puedes actualizar la contraseña con uno de los campos vacíos.");
            }
        }
    }
}
