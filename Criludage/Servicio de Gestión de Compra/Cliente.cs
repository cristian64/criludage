using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca_de_Entidades_de_Negocio;
using System.Configuration;
using System.Data.SqlClient;

namespace Servicio_de_Gestión_de_Compra
{
    public class Cliente : ENCliente
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Cliente()
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
        /// Constructor sobrecargado para realizar un upcasting desde ENCliente a Cliente.
        /// </summary>
        /// <param name="desguace">Objeto ENCliente desde el que se va a crear el nuevo cliente.</param>
        public Cliente(ENCliente cliente)
        {
            Id = cliente.Id;
            Usuario = cliente.Usuario;
            Contrasena = cliente.Contrasena;
            Nombre = cliente.Nombre;
            CorreoElectronico = cliente.CorreoElectronico;
            Direccion = cliente.Direccion;
            Nif = cliente.Nif;
            InformacionAdicional = cliente.InformacionAdicional;
            Telefono = cliente.Telefono;
        }

        /// <summary>
        /// A partir de una consulta Sql extrae los valores de los atributos y los asigna al objeto.
        /// </summary>
        /// <param name="dataReader">Resultado de la consulta Sql que contiene los datos.</param>
        private static Cliente crearCliente(SqlDataReader dataReader)
        {
            Cliente cliente = new Cliente();
            cliente.Id = int.Parse(dataReader["id"].ToString());
            cliente.Usuario = dataReader["usuario"].ToString();
            cliente.Contrasena = dataReader["contrasena"].ToString();
            cliente.Nombre = dataReader["nombre"].ToString();
            cliente.CorreoElectronico = dataReader["correoElectronico"].ToString();
            cliente.Direccion = dataReader["direccion"].ToString();
            cliente.Nif = dataReader["nif"].ToString();
            cliente.InformacionAdicional = dataReader["informacionAdicional"].ToString();
            cliente.Telefono = dataReader["telefono"].ToString();
            return cliente;
        }

        /// <summary>
        /// Consulta la base de datos para obtener el cliente a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Cliente Obtener(int id)
        {
            Cliente cliente = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from clientes where id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    cliente = crearCliente(dataReader);
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

            return cliente;
        }
    }
}
