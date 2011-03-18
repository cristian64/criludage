using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca_de_Entidades_de_Negocio;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

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
        /// Devuelve el cliente compatible con ENCliente. Es decir, realiza un downcasting del cliente.
        /// </summary>
        public ENCliente ENCliente
        {
            get
            {
                ENCliente cliente = new ENCliente();
                cliente.Id = Id;
                cliente.Usuario = Usuario;
                cliente.Contrasena = Contrasena;
                cliente.Nombre = Nombre;
                cliente.CorreoElectronico = CorreoElectronico;
                cliente.Direccion = Direccion;
                cliente.Nif = Nif;
                cliente.InformacionAdicional = InformacionAdicional;
                cliente.Telefono = Telefono;
                return cliente;
            }
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
                Registro.WriteLine("otro", "", e.Message);
                Registro.WriteLine("otro", "", e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return cliente;
        }

        /// <summary>
        /// Consulta la base de datos para obtener el cliente a partir del nombre de usuario.
        /// </summary>
        /// <param name="usuario">Nombre de usuario del cliente.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Cliente Obtener(string usuario)
        {
            Cliente cliente = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from clientes where usuario = @usuario";
                command.Parameters.AddWithValue("@usuario", usuario);

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    cliente = crearCliente(dataReader);
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("otro", "", e.Message);
                Registro.WriteLine("otro", "", e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return cliente;
        }

        /// <summary>
        /// Comprueba si el cliente es correcto. Es decir, si existe el cliente y además coincide con la contraseña indicada.
        /// </summary>
        /// <param name="usuario">Nombre de usuario.</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>Devuelve verdadero si el usuario existe.</returns>
        public static bool Autentificar(string usuario, string contrasena)
        {
            Cliente cliente = Obtener(usuario);
            if (cliente != null)
                return cliente.Contrasena.Equals(contrasena);
            else
                return false;
        }

        /// <summary>
        /// Guarda el cliente en la base de datos y actualiza la id.
        /// Si ya existía, actualiza sus valores.
        /// </summary>
        /// <returns>Devuelve verdadero si ha podido guardar o actualizar el cliente.</returns>
        public bool Guardar()
        {
            bool resultado = false;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                if (Id == 0)
                {
                    command.CommandText = "BEGIN TRAN " +
                                          "insert into clientes (usuario,contrasena,nombre,nif,correoElectronico,direccion,telefono,informacionAdicional) " +
                                          "values (@usuario, @contrasena, @nombre, @nif, @correoElectronico, @direccion, @telefono, @informacionAdicional); " +
                                          "select max(id) as nuevaId from clientes " +
                                          "COMMIT TRAN";

                    command.Parameters.AddWithValue("@usuario", Usuario);
                    command.Parameters.AddWithValue("@contrasena", Contrasena);
                    command.Parameters.AddWithValue("@nombre", Nombre);
                    command.Parameters.AddWithValue("@nif", Nif);
                    command.Parameters.AddWithValue("@correoElectronico", CorreoElectronico);
                    command.Parameters.AddWithValue("@direccion", Direccion);
                    command.Parameters.AddWithValue("@telefono", Telefono);
                    command.Parameters.AddWithValue("@informacionAdicional", InformacionAdicional);

                    // Se lee la nueva ID
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        // Se introduce en el propio objeto
                        Id = int.Parse(dataReader["nuevaId"].ToString());
                        resultado = true;
                    }
                }
                else
                {
                    command.CommandText = "update clientes set usuario = @usuario, contrasena = @contrasena, nombre = @nombre, nif = @nif, correoElectronico = @correoElectronico, direccion = @direccion, telefono = @telefono, informacionAdicional = @informacionAdicional where id = @id";

                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@usuario", Usuario);
                    command.Parameters.AddWithValue("@contrasena", Contrasena);
                    command.Parameters.AddWithValue("@nombre", Nombre);
                    command.Parameters.AddWithValue("@nif", Nif);
                    command.Parameters.AddWithValue("@correoElectronico", CorreoElectronico);
                    command.Parameters.AddWithValue("@direccion", Direccion);
                    command.Parameters.AddWithValue("@telefono", Telefono);
                    command.Parameters.AddWithValue("@informacionAdicional", InformacionAdicional);

                    if (command.ExecuteNonQuery() == 1)
                        resultado = true;
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("otro", "", e.Message);
                Registro.WriteLine("otro", "", e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene las solicitudes del cliente.
        /// </summary>
        /// <returns>Devuelve una lista con las solicitudes del cliente.</returns>
        public ArrayList ObtenerSolicitudes()
        {
            return Solicitud.ObtenerPorCliente(Id);
        }
    }
}
