using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Visor_de_Registro
{
    public class Registro
    {
        private int id;
        private String tipo;
        private DateTime fecha;
        private String usuario;
        private String descripcion;

        public Registro()
        {
            id = 0;
            tipo = "";
            fecha = DateTime.Now;
            usuario = "";
            descripcion = "";
        }

        /// <summary>
        /// Identificador.
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Tipo de mensaje.
        /// </summary>
        public String Tipo
        {
            get { return tipo; }
        }

        /// <summary>
        /// Fecha en la que se registró.
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
        }

        /// <summary>
        /// Nombre de usuario que realizó la operación.
        /// </summary>
        public String Usuario
        {
            get { return usuario; }
        }

        /// <summary>
        /// Descripción del mensaje.
        /// </summary>
        public String Descripcion
        {
            get { return descripcion; }
        }

        /// <summary>
        /// A partir de una consulta Sql extrae los valores de los atributos y los asigna al objeto.
        /// </summary>
        /// <param name="dataReader">Resultado de la consulta Sql que contiene los datos.</param>
        private static Registro crearSolicitud(MySqlDataReader dataReader)
        {
            Registro registro = new Registro();
            registro.id = int.Parse(dataReader["id"].ToString());
            registro.tipo = dataReader["tipo"].ToString();
            registro.descripcion = dataReader["descripcion"].ToString();
            registro.fecha = (DateTime)dataReader["fecha"];
            registro.usuario = dataReader["usuario"].ToString();
            return registro;
        }

        /// <summary>
        /// Obtiene todos los mensajes posteriores al mensaje indicado.
        /// </summary>
        /// <param name="id">Identificador del último mensaje que se recibió y desde el que se obtendrán los mensajes pendientes.</param>
        /// <returns>Una lista con todos los mensajes que estaban pendientes.</returns>
        public static ArrayList ObtenerDesde(int id)
        {
            ArrayList solicitudes = new ArrayList();
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from registro where id > @id";
                command.Parameters.AddWithValue("@id", id);

                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    solicitudes.Add(crearSolicitud(dataReader));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return solicitudes;
        }

        /// <summary>
        /// Escribe un mensaje en el registro.
        /// </summary>
        /// <param name="tipo">Tipo de registro: los que haya en el .sql en la restricción ck_registro_tipo.</param>
        /// <param name="usuario">Nombre de usuario que llevó a cabo la operación. Puede ser vacío si la operación era de "acceso".</param>
        /// <param name="descripcion">Descripción del mensaje.</param>
        public static void WriteLine(String tipo, String usuario, String descripcion)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "insert into registro (fecha, tipo, usuario, descripcion) " +
                    "values (@fecha, @tipo, @usuario, @descripcion); ";

                command.Parameters.AddWithValue("@fecha", DateTime.Now);
                command.Parameters.AddWithValue("@tipo", tipo);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
