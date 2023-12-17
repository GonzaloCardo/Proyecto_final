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
    /// Lógica de interacción para PaginaAlerta.xaml
    /// </summary>
    public partial class PaginaAlerta : Page
    {
        BBDD datos;
        int cama;
        int NHC;
        MenuPrincipal m;
        string codigo;
        public bool existe { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PaginaAlerta(WindowLittle v, BBDD datos, int cama, int NHC, MenuPrincipal m)
        {
            InitializeComponent();
            this.cama = cama;
            this.datos = datos;
            this.NHC = NHC;
            this.m = m;
            txtalerta.Text = datos.BuscarAlertaNombre(NHC);
            txtfecha.Text = datos.BuscarAlertaFecha(NHC);
            txtdetalles.Text = datos.BuscarAlertaObservacion(NHC);
            if (txtalerta.Text == "")
            {
                existe = false;
            }
            else
            {
                existe = true;
            }
        }

        /// <summary>
        /// Este botón guarda la información escrite sobre una alerta de un paciente en la base de datos
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (datos.ComprobarAlerta(NHC) == false)
            {
                if (txtalerta.Text == "" || txtfecha.Text == "" || txtdetalles.Text == "")
                {
                    MessageBox.Show("No puedes guardar una alerta con campos vacíos.");
                }
                else
                {
                    datos.CrearAlerta(txtalerta.Text, txtfecha.Text, txtdetalles.Text, NHC);
                    codigo = datos.SacarCodigoAlerta(txtalerta.Text);
                    datos.InsertarAlertaPaciente(NHC, codigo);
                    MessageBox.Show("Alerta guardada sobre el paciente.");
                    existe = true;
                    m.Refrescar();
                }
            }
            else
            {
                MessageBox.Show("Ya existe una alerta asignada a este paciente.");
            }
           
        }

        /// <summary>
        /// Este botón borra la alerta de la base de datos
        /// </summary>
        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                codigo = datos.SacarCodigoAlerta(txtalerta.Text);
                datos.BorrarAlertaPaciente(NHC);
                datos.BorrarAlerta(Int32.Parse(codigo));
                txtalerta.Text = "";
                txtfecha.Text = "";
                txtdetalles.Text = "";
                MessageBox.Show("La alerta se ha borrado correctamente.");
                existe = false;
                m.Refrescar();
            } catch (Exception es)
            {

            }
           
        }

        /// <summary>
        /// Este botón actualiza la alerta de la base de datos
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (datos.ComprobarAlerta(NHC) == true)
            {
                if (txtalerta.Text == "" || txtfecha.Text == "" || txtdetalles.Text == "")
                {
                    MessageBox.Show("No puedes actualizar una alerta con campos vacíos.");
                }
                else
                {
                    codigo = datos.SacarCodigoAlerta(txtalerta.Text);
                    datos.ActualizarAlerta(codigo, txtalerta.Text, txtfecha.Text, txtdetalles.Text, NHC);
                    MessageBox.Show("Alerta actualizada sobre el paciente.");
                    existe = true;
                }
            }
            else
            {
                MessageBox.Show("No es posible actualizar una alerta que no esta previamente guardada.");
            }
        }
    }
}
