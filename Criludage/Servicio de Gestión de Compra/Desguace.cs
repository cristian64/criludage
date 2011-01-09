using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Biblioteca_de_Entidades_de_Negocio;
using System.Data.SqlClient;
using System.Configuration;

namespace Servicio_de_Gestión_de_Compra
{
    public class Desguace : ENDesguace
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Desguace()
        {
            Id = 0;
            Usuario = "";
            Contrasena = "";
            Nombre = "";
            CorreoElectronico = "";
            Direccion = "";
            Nif = "";
            InformacionAdicional = "";
            Telefono = "";
        }

        /// <summary>
        /// Constructor sobrecargado para realizar un upcasting desde ENDesguace a Desguace.
        /// </summary>
        /// <param name="desguace">Objeto ENDesguace desde el que se va a crear la nueva solicitud.</param>
        public Desguace(ENDesguace desguace)
        {
            Id = desguace.Id;
            Usuario = desguace.Usuario;
            Contrasena = desguace.Contrasena;
            Nombre = desguace.Nombre;
            CorreoElectronico = desguace.CorreoElectronico;
            Direccion = desguace.Direccion;
            Nif = desguace.Nif;
            InformacionAdicional = desguace.InformacionAdicional;
            Telefono = desguace.Telefono;
        }

        /// <summary>
        /// A partir de una consulta Sql extrae los valores de los atributos y los asigna al objeto.
        /// </summary>
        /// <param name="dataReader">Resultado de la consulta Sql que contiene los datos.</param>
        private static Desguace crearDesguace(SqlDataReader dataReader)
        {
            Desguace desguace = new Desguace();
            desguace.Id = int.Parse(dataReader["id"].ToString());
            desguace.Usuario = dataReader["usuario"].ToString();
            desguace.Contrasena = dataReader["contrasena"].ToString();
            desguace.Nombre = dataReader["nombre"].ToString();
            desguace.CorreoElectronico = dataReader["correoElectronico"].ToString();
            desguace.Direccion = dataReader["direccion"].ToString();
            desguace.Nif = dataReader["nif"].ToString();
            desguace.InformacionAdicional = dataReader["informacionAdicional"].ToString();
            desguace.Telefono = dataReader["telefono"].ToString();
            return desguace;
        }

        /// <summary>
        /// Consulta la base de datos para obtener el desguace a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del desguace.</param>
        /// <returns>Devuelve un objeto de la clase Desguace con todos atributos. Si no existe, devuelve null.</returns>
        public static Desguace Obtener(int id)
        {
            Desguace desguace = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from desguaces where id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    desguace = crearDesguace(dataReader);
                }
            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return desguace;
        }
    }
}
