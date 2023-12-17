using MySql.Data.MySqlClient;
using Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto_Final_Gonzalo_Cardo_Muñoz.Datos
{
    /// <summary>
    /// Esta clase se encarga de guardar lo métodos relacionados con buscar o alterar información de la base de datos. Tiene 2 propiedades y está llena de métodos
    /// </summary>
    public class BBDD
    {
        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataReader reader;
        private MySqlDataAdapter adaptador;
        PaginaConfi p = new PaginaConfi();

        /// <summary>
        /// Propiedad que guarda un int que indica el tipo de usuario
        /// </summary>
        public int cuenta { get; set; }

        /// <summary>
        /// Propiedad string
        /// </summary>
        public int habilitado { get; set; }

        /// <summary>
        /// Método que comprueba si el usuario y contraseña son correctos, especifica el tipo de usuario
        /// </summary>
        public int Conectar(string usuario, string contraseña)
        {
            if (conexion != null)
            {
                conexion.Close();
            }


            if (usuario == "" && contraseña == "")
            {
                cuenta = 0;//no usuario
            }
            else
            {
                try
                {
                    conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                    conexion.Open();
                    comando = new MySqlCommand("SELECT * FROM usuarios WHERE Nombre= '" + usuario + "' and Contraseña= '" + contraseña + "'", conexion);
                    adaptador = new MySqlDataAdapter(comando);

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["EsAdministrador"].ToString() == "1")
                        {
                            cuenta = 1;//admin
                        }
                        else if (reader["EsAdministrador"].ToString() == "2")
                        {
                            cuenta = 2;//usuario
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                        cuenta = -1;
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return cuenta;
        }

        /// <summary>
        /// Método que comprueba si un usuario y contraseña es correcto sin mensaje de error, especifica el tipo de usuario
        /// </summary>
        public int Conectar2(string usuario, string contraseña)
        {
            if (conexion != null)
            {
                conexion.Close();
            }


            if (usuario == "" && contraseña == "")
            {
                cuenta = 0;//no usuario
            }
            else
            {
                try
                {
                    conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                    conexion.Open();
                    comando = new MySqlCommand("SELECT * FROM usuarios WHERE Nombre= '" + usuario + "' and Contraseña= '" + contraseña + "'", conexion);
                    adaptador = new MySqlDataAdapter(comando);

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["EsAdministrador"].ToString() == "1")
                        {
                            cuenta = 1;//admin
                        }
                        else if (reader["EsAdministrador"].ToString() == "2")
                        {
                            cuenta = 2;//usuario
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Usuario o contraseña incorrectos.");
                        cuenta = -1;
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return cuenta;
        }

        /// <summary>
        /// Método que comprueba si un usario está en la base de datos, especifica el tipo de usuario
        /// </summary>
        public int ConectarLittle(string usuario)
        {
            if (conexion != null)
            {
                conexion.Close();
            }


            if (usuario == "")
            {
                cuenta = 0;//no usuario
            }
            else
            {
                try
                {
                    conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                    conexion.Open();
                    comando = new MySqlCommand("SELECT * FROM usuarios WHERE Nombre= '" + usuario + "'", conexion);
                    adaptador = new MySqlDataAdapter(comando);

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["EsAdministrador"].ToString() == "1")
                        {
                            cuenta = 1;//admin
                        }
                        else if (reader["EsAdministrador"].ToString() == "0")
                        {
                            cuenta = 2;//usuario
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Usuario o contraseña incorrectos.");
                        cuenta = -1;
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return cuenta;
        }

        /// <summary>
        /// Método para registrarse en la base de datos
        /// </summary>
        public void Registrar(string usuario, string apellido1, string apellido2, string contraseña, string email)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("INSERT INTO usuarios VALUES (null,'" + usuario + "', '" + apellido1 + "', '" + apellido2 + "', '" + contraseña + "', '" + email + "', 'otro', 2)", conexion);
                adaptador = new MySqlDataAdapter(comando);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("El nombre de usuario ya existe, prueba otro.");
            }
        }

        /// <summary>
        /// Método para actualizar los datos de un paciente
        /// </summary>
        public void Actualizar(string NHC, string NIF, string estadoHC, string ambito, string nombre, string apellido1, string apellido2, string sexo, string fechanac, string telefono1, string telefono2, string movil, string estadocivil, string estudios, int fallecido, string fechafall, string horafall, string selecnac, string cautonoma, string provincia, string poblacion, string cp, string direccion, string nss, string regimen, string medprimario, string zonabasica, string nacimiento, string cautonoma2, string provinica2, string poblacion2, string titual, string tis, string cap, string areasalud, string edad)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE pacientes SET NHC='" + NHC + "', EstadoHC = '" + estadoHC + "', Ambito = '" + ambito + "', Nombre = '" + nombre + "', Apellido1 = '" + apellido1 + "', Apellido2 = '" + apellido2 + "', Sexo = '" + sexo + "', FechaNac = '" + fechanac + "', Telefono1 = '" + telefono1 + "', Telefono2 = '" + telefono2 + "', Movil = '" + movil + "', EstadoCivil = '" + estadocivil + "', Estudios = '" + estudios + "', Fallecido = " + fallecido + ", FechaFall = '" + fechafall + "', HoraFall = '" + horafall + "', SelecNac = '" + selecnac + "', NIF = '" + NIF + "', Cautonoma = '" + cautonoma + "', Provincia = '" + provincia + "', Poblacion = '" + poblacion + "', CP = '" + cp + "', Direccion = '" + direccion + "', NumeroSS = '" + nss + "', Regimen = '" + regimen + "', MedicoPrimario = '" + medprimario + "', ZonaBasica = '" + zonabasica + "', Nacimiento = '" + nacimiento + "', Cautonoma2 = '" + cautonoma2 + "', Provincia2 = '" + provinica2 + "', Poblacion2 = '" + poblacion2 + "', Titular = '" + titual + "', TIS = '" + tis + "', CAP = '" + cap + "', AreaSalud = '" + areasalud + "', edad = '" + edad +"' where NHC= '" + NHC + "' ", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método para dar de alta a un paciente
        /// </summary>
        public void DarAlta(string estadoHC, string ambito, string nombre, string apellido1, string apellido2, string sexo, string fechanac, string telefono1, string telefono2, string movil, string estadocivil, string estudios, int fallecido, string fechafall, string horafall, string selecnac, string NIF, string cautonoma, string provincia, string poblacion, string cp, string direccion, string nss, string regimen, string medprimario, string zonabasica, string nacimiento, string cautonoma2, string provinica2, string poblacion2, string titual, string tis, string cap, string areasalud, string edad)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("INSERT INTO pacientes VALUES ( null, '" + estadoHC + "', '" + ambito + "', '" + nombre + "', '" + apellido1 + "', '" + apellido2 + "', '" + sexo + "', '" + fechanac + "', '" + telefono1 + "', '" + telefono2 + "', '" + movil + "', '" + estadocivil + "', '" + estudios + "', '" + fallecido + "', '" + fechafall + "', '" + horafall + "', '" + selecnac + "', '" + NIF + "', '" + cautonoma + "', '" + provincia + "', '" + poblacion + "', '" + cp + "', '" + direccion + "', '" + nss + "', '" + regimen + "', '" + medprimario + "', '" + zonabasica + "', '" + nacimiento + "', '" + cautonoma2 + "', '" + provinica2 + "', '" + poblacion2 + "', '" + titual + "', '" + tis + "', '" + cap + "', '" + areasalud + "', '" + edad + "', null, null)", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método para ingresar a un paciente en una cama
        /// </summary>
        public void IngresarPacienteCama(int cama, int MHC)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE cama SET NHC = " + MHC + " WHERE id_cama = " + cama + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que comprueba si una cama tiene un paciente
        /// </summary>
        public bool ComprobarExistePacienteCama(int NHC)
        {
            bool habilitado = false;
            string existe;
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT id_cama FROM cama where NHC = " + NHC + ";", conexion);

                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    existe = reader["id_cama"].ToString();
                    if (existe != "")
                    {
                        habilitado = true;
                    }
                    /*
                    else if (reader["habilitado"].ToString() == "0")
                    {
                        habilitado = 2;
                    }
                    */
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return habilitado;
        }

        /// <summary>
        /// Método que comprueba si una cama está habilitada
        /// </summary>
        public bool ComprobarCama(int cama)
        {
            bool habilitado = false;
            string existe;
            if (conexion != null)
                conexion.Close();
            
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT habilitado FROM cama WHERE id_cama = " + cama + ";", conexion);

                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    existe = reader["habilitado"].ToString();
                    if ( existe == "True")
                    {
                        habilitado = true;
                    }
                    /*
                    else if (reader["habilitado"].ToString() == "0")
                    {
                        habilitado = 2;
                    }
                    */
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return habilitado;
        }

        /// <summary>
        /// Método que habilita una cama cambiando el valor del campo a 0
        /// </summary>
        public void HabilitarCama(int cama)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE cama SET habilitado = 0 WHERE id_cama = " + cama + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que deshabilita una cama cambiando el valor del campo a 1
        /// </summary>
        public void DeshabilitarCama(int cama)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE cama SET habilitado = 1 WHERE id_cama = " + cama + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que selecciona la alerta del paciente
        /// </summary>
        public string BuscarAlerta(int NHC)
        {         
            if (conexion != null)
                conexion.Close();

            string mensaje = "";
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT codigo FROM pacientes WHERE NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    if ((reader["codigo"].ToString()) != "")
                    {
                        mensaje = reader["codigo"].ToString();
                    }
                    else
                    {
                        mensaje = "";
                    } 
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;           
        }

        /// <summary>
        /// Método que busca el nombre de la alerta del paciente
        /// </summary>
        public string BuscarAlertaNombre(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            string mensaje = "";
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT alertas.descripcion FROM alertas inner JOIN pacientes on alertas.NHC = pacientes.NHC WHERE alertas.NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    if ((reader["descripcion"].ToString()) != "")
                    {
                        mensaje = reader["descripcion"].ToString();
                    }
                    else
                    {
                        mensaje = "";
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que busca la fecha de la alerta del paciente
        /// </summary>
        public string BuscarAlertaFecha(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            string mensaje = "";
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT alertas.fecha FROM alertas inner JOIN pacientes on alertas.NHC = pacientes.NHC WHERE alertas.NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    if ((reader["fecha"].ToString()) != "")
                    {
                        mensaje = reader["fecha"].ToString();
                    }
                    else
                    {
                        mensaje = "";
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que busca las observaciones de la alerta del paciente
        /// </summary>
        public string BuscarAlertaObservacion(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            string mensaje = "";
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT alertas.observaciones FROM alertas inner JOIN pacientes on alertas.NHC = pacientes.NHC WHERE alertas.NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    if ((reader["observaciones"].ToString()) != "")
                    {
                        mensaje = reader["observaciones"].ToString();
                    }
                    else
                    {
                        mensaje = "";
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que comprueba si un paciente tiene una alerta asignada
        /// </summary>
        public bool ComprobarAlerta(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            bool mensaje = false;
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT codigo FROM pacientes WHERE NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["codigo"].ToString()) != "")
                    {
                        mensaje = true;
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que comrueba si un paciente tiene una hoja de P.A.T. asignada
        /// </summary>
        public bool ComprobarPAT(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            bool mensaje = false;
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT NHC FROM pat WHERE NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != "")
                    {
                        mensaje = true;
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que comprueba si un paciente tiene una hoja de balance asignada
        /// </summary>
        public bool ComprobarBalance(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            bool mensaje = false;
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT NHC FROM balance WHERE NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != "")
                    {
                        mensaje = true;
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que comprueba si un paciente tiene una hoja de balance asignada
        /// </summary>
        public bool ComprobarPrep(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            bool mensaje = false;
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT NHC FROM prescripcion WHERE NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != "")
                    {
                        mensaje = true;
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que si un paciente tiene una nota de enfermería asignada
        /// </summary>
        public bool ComprobarToma(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            bool mensaje = false;
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT NHC FROM tomas WHERE NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != "")
                    {
                        mensaje = true;
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que devuelve el NHC del paciente en la cama que está
        /// </summary>
        public string BuscarNHCCama(int cama)
        {
            if (conexion != null)
                conexion.Close();

            string mensaje = "";

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT NHC FROM cama WHERE id_cama = " + cama + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    mensaje = (reader["NHC"].ToString());                               
                }
                conexion.Close();
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que devuelve la planta en la que se encuentra una cama
        /// </summary>
        public string BuscarPlantaCama(int cama)
        {
            if (conexion != null)
                conexion.Close();

            string mensaje = "";

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT ID_PLANTA FROM cama WHERE id_cama = " + cama + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    mensaje = (reader["ID_PLANTA"].ToString());                
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que devuelve la letra de habitación de una cama
        /// </summary>
        public string BuscarLetraCama(int cama)
        {
            if (conexion != null)
                conexion.Close();

            string mensaje = "";

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT letra FROM cama WHERE id_cama = " + cama + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    mensaje = (reader["letra"].ToString());
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que devuelve el número de habitación en el que está
        /// </summary>
        public string BuscarHabCama(int cama)
        {
            if (conexion != null)
                conexion.Close();

            string mensaje = "";

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT habitacion FROM cama WHERE id_cama = " + cama + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    mensaje = (reader["habitacion"].ToString());
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }

        /// <summary>
        /// Método que crea una alerta
        /// </summary>
        public void CrearAlerta(string descripcion, string fecha, string observaciones, int NHC)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("Insert INTO alertas VALUES (null, 1, '" + descripcion + "', '" + fecha + "', '" + observaciones + "', null, " + NHC + ");", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que actualiza los datos de una alerta
        /// </summary>
        public void ActualizarAlerta(string codigo, string descripcion, string fecha, string observaciones, int NHC)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE alertas SET codigo = " + codigo + ", confirmada = 1, descripcion = '" + descripcion + "', fecha = '" + fecha + "', observaciones = '" + observaciones + "', ID_INGRESO = null, NHC = " + NHC + " WHERE NHC = " + NHC + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que devuelve el código de una alerta
        /// </summary>
        public string SacarCodigoAlerta(string alerta)
        {

            if (conexion != null)
                conexion.Close();

            string codigo = "";
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("Select codigo from alertas where descripcion = '" + alerta + "';", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    codigo = reader["codigo"].ToString();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return codigo;

        }

        /// <summary>
        /// Método que asigna una alerta a un paciente
        /// </summary>
        public void InsertarAlertaPaciente(int NHC, string codigo)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE pacientes SET codigo = '" + codigo + "' WHERE NHC = " + NHC + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que quita a su paciente asignado dejando el NHC a null
        /// </summary>
        public void QuitarPacienteCama(int cama)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE cama SET NHC = null WHERE id_cama = " + cama + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que quita la aignación de una alerta de un paciente
        /// </summary>
        public void BorrarAlertaPaciente(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE pacientes SET codigo = null WHERE NHC = " + NHC + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que borra una alerta de la base de datos
        /// </summary>
        public void BorrarAlerta(int codigo)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("DELETE FROM alertas WHERE codigo = " + codigo + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que guarda en una lista las comunidades autónomas de España
        /// </summary>
        public List<string> SeleccionarComunidades()
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT `nombre` FROM `hospital`.`comunidadautonoma`;", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista todas las provincias
        /// </summary>
        public List<string> SeleccionarProvinciasTodas()
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT `nombre` FROM `hospital`.`provincias`;", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }


        /// <summary>
        /// Método que guarda en una lista camas 
        /// </summary>
        public List<string> SeleccionarCamas(int planta)
        {
            if (conexion != null)
                conexion.Close();

            List<string> camas = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * FROM cama WHERE ID_PLANTA = " + planta + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    camas.Add(reader["id_cama"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return camas;
        }

        /// <summary>
        /// Método que guarda en una lista las áreas de salud
        /// </summary>
        public List<string> SeleccionarAreaSalud()
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT nombre FROM hospital.areasalud", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista las comunidades autónomas de Castilla La-Mancha
        /// </summary>
        public List<string> SeleccionarCastilla()
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT nombre FROM hospital.castilla", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista provincias dependiendo de la comunidad elegida
        /// </summary>
        public List<string> SeleccionarProvincias(int id)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT `provincias`.`nombre` FROM `hospital`.`provincias` inner JOIN `hospital`.`comunidadautonoma` on `provincias`.`id_cautonoma` = `comunidadautonoma`.`id_cautonoma` WHERE `comunidadautonoma`.`id_cautonoma` = " + id + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista los centros de salud dependiendo de la ciudad
        /// </summary>
        public List<string> SeleccionarCentroSalud(string castilla)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT centrosalud.nombre FROM centrosalud inner JOIN castilla on centrosalud.id_c = castilla.id_c WHERE castilla.nombre = '" + castilla + "';", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista todos los centros de salud
        /// </summary>
        public List<string> SeleccionarTodosCentroSalud()
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT centrosalud.nombre FROM centrosalud", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista las zonas básicas dependiendo del area 
        /// </summary>
        public List<string> SeleccionarZonaBasica(int id)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT zonabasica.nombre FROM zonabasica inner JOIN areasalud on zonabasica.id_area = areasalud.id_area WHERE areasalud.id_area = " + id + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista todsa las zonas básicas
        /// </summary>
        public List<string> SeleccionarTodasZonaBasicas()
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT zonabasica.nombre FROM zonabasica;", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista los centros de salud dependiendo de la ciudad
        /// </summary>
        public List<string> SeleccionarCentros(int id)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT centrosalud.nombre FROM centrosalud inner JOIN castilla on centrosalud.id_c = castilla.id_c WHERE castilla.id_c = '" + id + "';", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return info;
        }

        /// <summary>
        /// Método que guarda en una lista todos los usuarios de la base de datos
        /// </summary>
        public List<string> VerUsuarios()
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT Nombre FROM usuarios;", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["Nombre"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return info;
        }

        /// <summary>
        /// Método que borra un usuario de la base de datos
        /// </summary>
        public void BorrarUsuario(string usuario)
        {
            if (conexion != null)
                conexion.Close();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("DELETE FROM usuarios WHERE Nombre = '" + usuario + "';", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que borra todos los pacientes de la base de datos, sus alertas y hojas médicas
        /// </summary>
        public void BorrarTodo()
        {
            if (conexion != null)
                conexion.Close();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("DELETE FROM pacientes;", conexion);
                comando.ExecuteNonQuery();
                comando = new MySqlCommand("DELETE FROM alertas;", conexion);
                comando.ExecuteNonQuery();
                comando = new MySqlCommand("DELETE FROM tomas;", conexion);
                comando.ExecuteNonQuery();
                comando = new MySqlCommand("DELETE FROM alertas;", conexion);
                comando.ExecuteNonQuery();
                comando = new MySqlCommand("DELETE FROM prescripcion;", conexion);
                comando.ExecuteNonQuery();
                comando = new MySqlCommand("DELETE FROM pat;", conexion);
                comando.ExecuteNonQuery();
                comando = new MySqlCommand("DELETE FROM balance;", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que devuelve una lista con todos los datos del paciente mediante su DNI
        /// </summary>
        public List<string> BuscarDNI(string DNI)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NIF = '" + DNI + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["NHC"].ToString());
                    info.Add(reader["EstadoHC"].ToString());
                    info.Add(reader["Ambito"].ToString());
                    info.Add(reader["Nombre"].ToString());
                    info.Add(reader["Apellido1"].ToString());
                    info.Add(reader["Apellido2"].ToString());
                    info.Add(reader["Sexo"].ToString());
                    info.Add(reader["FechaNac"].ToString());
                    info.Add(reader["Telefono1"].ToString());
                    info.Add(reader["Telefono2"].ToString());
                    info.Add(reader["Movil"].ToString());
                    info.Add(reader["EstadoCivil"].ToString());
                    info.Add(reader["Estudios"].ToString());
                    info.Add(reader["Fallecido"].ToString());
                    info.Add(reader["FechaFall"].ToString());
                    info.Add(reader["HoraFall"].ToString());
                    info.Add(reader["SelecNac"].ToString());
                    info.Add(reader["NIF"].ToString());
                    info.Add(reader["Cautonoma"].ToString());
                    info.Add(reader["Provincia"].ToString());
                    info.Add(reader["Poblacion"].ToString());
                    info.Add(reader["CP"].ToString());
                    info.Add(reader["Direccion"].ToString());
                    info.Add(reader["NumeroSS"].ToString());
                    info.Add(reader["Regimen"].ToString());
                    info.Add(reader["MedicoPrimario"].ToString());
                    info.Add(reader["ZonaBasica"].ToString());
                    info.Add(reader["Nacimiento"].ToString());
                    info.Add(reader["Cautonoma2"].ToString());
                    info.Add(reader["Provincia2"].ToString());
                    info.Add(reader["Poblacion2"].ToString());
                    info.Add(reader["Titular"].ToString());
                    info.Add(reader["TIS"].ToString());
                    info.Add(reader["CAP"].ToString());
                    info.Add(reader["AreaSalud"].ToString());
                    info.Add(reader["edad"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return info;
        }

        /// <summary>
        /// Método que devuelve el NHC de un paciente mediante su DNI
        /// </summary>
        public bool ComprobarPaciente(string DNI)
        {
            if (conexion != null)
                conexion.Close();

            bool existe = false;

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NIF = '" + DNI + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != null)
                    {
                        existe = true;
                    }
                }
            }

            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            return existe;
        }

        /// <summary>
        /// Método que comprueba si un paciente existe
        /// </summary>
        public bool ComprobarPacienteNHC(string NHC)
        {
            if (conexion != null)
                conexion.Close();

            bool existe = false;

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NHC = '" + NHC + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != null)
                    {
                        existe = true;
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return existe;
        }

        /// <summary>
        /// Método que comprueba si hay un paciente en una cama
        /// </summary>
        public bool ComprobarPacienteCama(int cama)
        {
            if (conexion != null)
                conexion.Close();

            bool existe = false;

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT NHC from cama WHERE id_cama = '" + cama + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != "")
                    {
                        existe = true;
                    }
                }
            }

            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            return existe;
        }

        /// <summary>
        /// Método que devuelve el NHC de un paciente de una cama
        /// </summary>
        public string ConseguirPacienteCama(int cama)
        {
            if (conexion != null)
                conexion.Close();
            
            string NHC = "0";

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT NHC from cama WHERE id_cama = '" + cama + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != "")
                    {
                        NHC = reader["NHC"].ToString();
                    }
                }
            }

            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            return NHC;
        }

        /// <summary>
        /// Método que comprueba el género de un paciente
        /// </summary>
        public string ComprobarGenero(string MHC)
        {
            if (conexion != null)
                conexion.Close();

            string sexo = "";

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NHC = '" + MHC + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    sexo = reader["Sexo"].ToString();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return sexo;
        }

        /// <summary>
        /// Método que elimina el NHC de una cama, especificando que queda vacía
        /// </summary>
        public void BorrarNHCCama(int idcama)
        {
            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE cama SET NHC = null WHERE id_cama = " + idcama + ";", conexion);
                comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que devuelve el NHc de un paciente mediante su DNI
        /// </summary>
        public string ConseguirNHCconDNI(string DNI)
        {
            if (conexion != null)
                conexion.Close();

            string NHC = "";

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NIF = '" + DNI + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    NHC = reader["NHC"].ToString();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return NHC;
        }

        /// <summary>
        /// Método que consigue el NHC mediante el SS
        /// </summary>
        public string ConseguirNHCconSS(string SS)
        {
            if (conexion != null)
                conexion.Close();

            string NHC = "";

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NumeroSS = '" + SS + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    NHC = reader["NHC"].ToString();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return NHC;
        }

        /// <summary>
        /// Método que devuelve la cama de un paciente
        /// </summary>
        public string ConseguirCamadePaciente(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            string cama = "";
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT id_cama FROM cama WHERE NHC = " + NHC + ";", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    cama = reader["id_cama"].ToString();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return cama;
        }

        /// <summary>
        /// Método que comprueba si un paciente existe mediante su SS
        /// </summary>
        public bool ComprobarPacienteSS(string SS)
        {
            if (conexion != null)
                conexion.Close();

            bool existe = false;

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NumeroSS = '" + SS + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["NHC"].ToString()) != null)
                    {
                        existe = true;
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return existe;
        }

        /// <summary>
        /// Método que devuelve una lista con todos los datos de un paciente mediante su SS
        /// </summary>
        public List<string> BuscarSS(string SS)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NumeroSS = '" + SS + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    info.Add(reader["NHC"].ToString());
                    info.Add(reader["EstadoHC"].ToString());
                    info.Add(reader["Ambito"].ToString());
                    info.Add(reader["Nombre"].ToString());
                    info.Add(reader["Apellido1"].ToString());
                    info.Add(reader["Apellido2"].ToString());
                    info.Add(reader["Sexo"].ToString());
                    info.Add(reader["FechaNac"].ToString());
                    info.Add(reader["Telefono1"].ToString());
                    info.Add(reader["Telefono2"].ToString());
                    info.Add(reader["Movil"].ToString());
                    info.Add(reader["EstadoCivil"].ToString());
                    info.Add(reader["Estudios"].ToString());
                    info.Add(reader["Fallecido"].ToString());
                    info.Add(reader["FechaFall"].ToString());
                    info.Add(reader["HoraFall"].ToString());
                    info.Add(reader["SelecNac"].ToString());
                    info.Add(reader["NIF"].ToString());
                    info.Add(reader["Cautonoma"].ToString());
                    info.Add(reader["Provincia"].ToString());
                    info.Add(reader["Poblacion"].ToString());
                    info.Add(reader["CP"].ToString());
                    info.Add(reader["Direccion"].ToString());
                    info.Add(reader["NumeroSS"].ToString());
                    info.Add(reader["Regimen"].ToString());
                    info.Add(reader["MedicoPrimario"].ToString());
                    info.Add(reader["ZonaBasica"].ToString());
                    info.Add(reader["Nacimiento"].ToString());
                    info.Add(reader["Cautonoma2"].ToString());
                    info.Add(reader["Provincia2"].ToString());
                    info.Add(reader["Poblacion2"].ToString());
                    info.Add(reader["Titular"].ToString());
                    info.Add(reader["TIS"].ToString());
                    info.Add(reader["CAP"].ToString());
                    info.Add(reader["AreaSalud"].ToString());
                    info.Add(reader["edad"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return info;
        }

        /// <summary>
        /// Método que devuelve todos los datos de un paciente mediante su NHC
        /// </summary>
        public List<string> BuscarNHC(string NHC)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * from pacientes WHERE NHC = '" + NHC + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    /*
                    if ((reader["NHC"].ToString()) != reader["null"])
                    {
                    */
                        info.Add(reader["NHC"].ToString());
                    /*
                    }
                    else
                    {
                    
                        info.Add("");
                    
                    }
                    */
                    info.Add(reader["EstadoHC"].ToString());
                    info.Add(reader["Ambito"].ToString());
                    /*
                    if ((reader["Nombre"].ToString()) != reader["null"])
                    {
                    */
                        info.Add(reader["Nombre"].ToString());
                    /*
                    }
                    else
                    {
                    
                        info.Add("");
                    
                    }
                    if ((reader["Apellido1"].ToString()) != reader["null"])
                    {
                    */
                        info.Add(reader["Apellido1"].ToString());
                    /*
                    }
                    else
                    {
                        info.Add("");
                    }
                    if ((reader["Apellido2"].ToString()) != reader["null"])
                    {
                    */
                        info.Add(reader["Apellido2"].ToString());
                    /*
                    }
                    else
                    {
                        info.Add("");
                    }
                    */
                    info.Add(reader["Sexo"].ToString());
                    /*
                    if ((reader["FechaNac"].ToString()) != reader["null"])
                    {
                    */
                        info.Add(reader["FechaNac"].ToString());
                    /*
                    }
                    else
                    {
                        info.Add("");
                    }
                    */
                    info.Add(reader["Telefono1"].ToString());
                    info.Add(reader["Telefono2"].ToString());
                    info.Add(reader["Movil"].ToString());
                    info.Add(reader["EstadoCivil"].ToString());
                    info.Add(reader["Estudios"].ToString());
                    info.Add(reader["Fallecido"].ToString());
                    info.Add(reader["FechaFall"].ToString());
                    info.Add(reader["HoraFall"].ToString());
                    info.Add(reader["SelecNac"].ToString());
                    info.Add(reader["NIF"].ToString());
                    info.Add(reader["Cautonoma"].ToString());
                    info.Add(reader["Provincia"].ToString());
                    info.Add(reader["Poblacion"].ToString());
                    info.Add(reader["CP"].ToString());
                    info.Add(reader["Direccion"].ToString());
                    info.Add(reader["NumeroSS"].ToString());
                    info.Add(reader["Regimen"].ToString());
                    info.Add(reader["MedicoPrimario"].ToString());
                    info.Add(reader["ZonaBasica"].ToString());
                    info.Add(reader["Nacimiento"].ToString());
                    info.Add(reader["Cautonoma2"].ToString());
                    info.Add(reader["Provincia2"].ToString());
                    info.Add(reader["Poblacion2"].ToString());
                    info.Add(reader["Titular"].ToString());
                    info.Add(reader["TIS"].ToString());
                    info.Add(reader["CAP"].ToString());
                    info.Add(reader["AreaSalud"].ToString());
                    info.Add(reader["edad"].ToString());
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return info;
        }

        /// <summary>
        /// Método que actualiza la hoja de enfermería de un paciente
        /// </summary>
        public void ActualizarToma(string temperatura, string sistolica, string diastolica, string cardiaca, string respiratoria, string peso, string masa, string glucemia, string ingesta, string depo, string nauseas, string prurito, string observaciones, int NHC)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE tomas SET temperatura = '" + temperatura + "', sistolica = '" + sistolica + "', diastolica = '" + diastolica + "', cardiaca = '" + cardiaca + "', respiratoria = '" + respiratoria + "', peso = '" + peso + "', masa = '" + masa + "', glucemia = '" + glucemia + "', ingesta = '" + ingesta + "', depo = '" + depo + "', nauseas = '" + nauseas + "', prurito = '" + prurito + "', observaciones = '" + observaciones + "' WHERE NHC = '" + NHC + "';", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que crea una hoja de enfermería de un paciente
        /// </summary>
        public void CrearToma( string temperatura, string sistolica, string diastolica, string cardiaca, string respiratoria, string peso, string masa, string glucemia, string ingesta, string depo, string nauseas, string prurito, string observaciones, int NHC)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("INSERT INTO tomas VALUES ( null, '" + temperatura + "', '" + sistolica + "', '" + diastolica + "', '" + cardiaca + "', '" + respiratoria + "', '" + peso + "', '" + masa + "', '" + glucemia + "', '" + ingesta + "', '" + depo + "', '" + nauseas + "', '" + prurito + "', '" + observaciones + "', " + NHC + ")", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que busca los datos de la hoja de enfermería de un paciente
        /// </summary>
        public List<string> BuscarToma(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * FROM tomas inner JOIN pacientes on tomas.NHC = pacientes.NHC WHERE tomas.NHC = '" + NHC + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["temperatura"].ToString()) != "")
                    {
                        info.Add(reader["temperatura"].ToString());
                        info.Add(reader["sistolica"].ToString());
                        info.Add(reader["diastolica"].ToString());
                        info.Add(reader["cardiaca"].ToString());
                        info.Add(reader["respiratoria"].ToString());
                        info.Add(reader["peso"].ToString());
                        info.Add(reader["masa"].ToString());
                        info.Add(reader["glucemia"].ToString());
                        info.Add(reader["ingesta"].ToString());
                        info.Add(reader["depo"].ToString());
                        info.Add(reader["nauseas"].ToString());
                        info.Add(reader["prurito"].ToString());
                        info.Add(reader["observaciones"].ToString());
                    }
                    else
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            info.Add("");
                        }
                    }
                            
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return info;
        }

        /// <summary>
        /// Método que actualiza el balance de un paciente
        /// </summary>
        public void ActualizarBalance(string alimentos, string liquidos, string fluidoterapia, string hemo, string otros, string diu, string vomitos, string heces, string sonda, string drenaje, string otras, string total, int NHC)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE balance SET alimentos = '" + alimentos + "', liquidos = '" + liquidos + "', fluidoterapia = '" + fluidoterapia + "', hemo = '" + hemo + "', otros = '" + otros + "', diu = '" + diu + "', vomitos = '" + vomitos + "', heces = '" + heces + "', sonda = '" + sonda + "', drenaje = '" + drenaje + "', otras = '" + otras + "', total = '" + total + "' WHERE NHC = '" + NHC + "';", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que crea el balance de un paciente
        /// </summary>
        public void CrearBalance(string alimentos, string liquidos, string fluidoterapia, string hemo, string otros, string diu, string vomitos, string heces, string sonda, string drenaje, string otras, string total, int NHC)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("INSERT INTO balance VALUES ( null, '" + alimentos + "', '" + liquidos + "', '" + fluidoterapia + "', '" + hemo + "', '" + otros + "', '" + diu + "', '" + vomitos + "', '" + heces + "', '" + sonda + "', '" + drenaje + "', '" + otras + "', '" + total + "', " + NHC + ")", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que busca los datos del balance de un paciente
        /// </summary>
        public List<string> BuscarBalance(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * FROM balance WHERE NHC = '" + NHC + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["liquidos"].ToString()) != "")
                    {
                        info.Add(reader["alimentos"].ToString());
                        info.Add(reader["liquidos"].ToString());
                        info.Add(reader["fluidoterapia"].ToString());
                        info.Add(reader["hemo"].ToString());
                        info.Add(reader["otros"].ToString());
                        info.Add(reader["diu"].ToString());
                        info.Add(reader["vomitos"].ToString());
                        info.Add(reader["heces"].ToString());
                        info.Add(reader["sonda"].ToString());
                        info.Add(reader["drenaje"].ToString());
                        info.Add(reader["otras"].ToString());
                        info.Add(reader["total"].ToString());
                    }
                    else
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            info.Add("");
                        }
                        
                    }
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return info;
        }

        /// <summary>
        /// Método que actualiza la hoja de prescripcion de un paciente
        /// </summary>
        public void ActualizarPrep(string esp, string prin, string dosis, string via, string frecuencia, string fechaFin, int NHC)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                comando = new MySqlCommand("UPDATE prescripcion SET esp = '" + esp + "', prin = '" + prin + "', dosis = '" + dosis + "', via = '" + via + "', frecuencia = '" + frecuencia + "', fecha_fin = '" + fechaFin + "' WHERE NHC = " + NHC + ";", conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que crea la hoja de prescripcion de un paciente
        /// </summary>
        public void CrearPrep(string esp, string prin, string dosis, string via, string frecuencia, string fechaFin, int NHC)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("INSERT INTO prescripcion VALUES ( null, '" + esp + "', '" + prin + "', '" + dosis + "', '" + via + "', '" + frecuencia + "', '" + fechaFin + "', '" + NHC + "')", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que busca los datos de la hoja de prescripcion de un paciente
        /// </summary>
        public List<string> BuscarPrep(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * FROM prescripcion WHERE NHC = '" + NHC + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    if ((reader["esp"].ToString()) != "")
                    {
                        info.Add(reader["esp"].ToString());
                        info.Add(reader["prin"].ToString());
                        info.Add(reader["dosis"].ToString());
                        info.Add(reader["via"].ToString());
                        info.Add(reader["frecuencia"].ToString());
                        info.Add(reader["fecha_fin"].ToString());
                    }
                    else
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            info.Add("");
                        }

                    }                                      
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return info;
        }

        /// <summary>
        /// Método que actualiza la hoja de PAT de un paciente
        /// </summary>
        public void ActualizarPAT(string fechaInicio, string fechaDia, string sintomas, string diagnostico, string especialidad, string codi, string NHC1, int NHC)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("UPDATE pat SET fecha_inicio = '" + fechaInicio + "', fecha_dia = '" + fechaDia + "', sintomas = '" + sintomas + "', diagnostico = '" + diagnostico + "', especialidad = '" + especialidad + "', codi = '" + codi + "', NHC1 = '" + NHC1 + "' WHERE NHC = " + NHC + ";", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que crea la hoja de PAT de un paciente
        /// </summary>
        public void CrearPAT(string fechaInicio, string fechaDia, string sintomas, string diagnostico, string especialidad, string codi, string NHC1, int NHC)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("INSERT INTO pat VALUES ( null, '" + fechaInicio + "', '" + fechaDia + "', '" + sintomas + "', '" + diagnostico + "', '" + especialidad + "', '" + codi + "', '" + NHC1 + "', " + NHC + ")", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Método que busca los datos de la hoja PAT de un paciente
        /// </summary>
        public List<string> BuscarPAT(int NHC)
        {
            if (conexion != null)
                conexion.Close();

            List<string> info = new List<string>();
            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                conexion.Open();
                comando = new MySqlCommand("SELECT * FROM pat WHERE NHC = '" + NHC + "'", conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["codi"].ToString()) != "")
                    {
                        info.Add(reader["fecha_inicio"].ToString());
                        info.Add(reader["fecha_dia"].ToString());
                        info.Add(reader["sintomas"].ToString());
                        info.Add(reader["diagnostico"].ToString());
                        info.Add(reader["especialidad"].ToString());
                        info.Add(reader["codi"].ToString());
                        info.Add(reader["NHC1"].ToString());
                        info.Add(reader["NHC"].ToString());
                    }
                    else
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            info.Add("");
                        }
                    }
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return info;
        }

        /// <summary>
        /// Método que actualiza el nombre del administrador
        /// </summary>
        public void ActualizarNombreAdmin(string nombre)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                comando = new MySqlCommand("UPDATE usuarios SET Nombre = '" + nombre + "' WHERE idUsuarios = 1;", conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No puedes actualizar el nombre del administrador a uno que ya existe, ignora el siguiente mensaje.");
            }
        }

        /// <summary>
        /// Método que actualiza la contraseña del administrador
        /// </summary>
        public void ActualizarContraseñaAdmin(string contraseña)
        {

            if (conexion != null)
                conexion.Close();

            try
            {
                conexion = new MySqlConnection("server=" + p.server + "; ;port=" + p.port + ";user id=" + p.user + ";password=" + p.password + ";database=hospital;Allow Zero Datetime=true;CHARSET=latin1");
                comando = new MySqlCommand("UPDATE usuarios SET Contraseña = '" + contraseña + "' WHERE idUsuarios = 1;", conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
