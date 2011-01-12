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
        /// <param name="desguace">Objeto ENDesguace desde el que se va a crear el nuevo desguace.</param>
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
        /// Devuelve el desguace compatible con ENDesguace. Es decir, realiza un downcasting del desguace.
        /// </summary>
        public ENDesguace ENDesguace
        {
            get
            {
                ENDesguace desguace = new ENDesguace();
                desguace.Id = Id;
                desguace.Usuario = Usuario;
                desguace.Contrasena = Contrasena;
                desguace.Nombre = Nombre;
                desguace.CorreoElectronico = CorreoElectronico;
                desguace.Direccion = Direccion;
                desguace.Nif = Nif;
                desguace.InformacionAdicional = InformacionAdicional;
                desguace.Telefono = Telefono;
                return desguace;
            }
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

        /// <summary>
        /// Consulta la base de datos para obtener el desguace a partir del nombre de usuario.
        /// </summary>
        /// <param name="usuario">Nombre de usuario del desguace.</param>
        /// <returns>Devuelve un objeto de la clase Desguace con todos atributos. Si no existe, devuelve null.</returns>
        public static Desguace Obtener(string usuario)
        {
            Desguace desguace = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from desguaces where usuario = @usuario";
                command.Parameters.AddWithValue("@usuario", usuario);

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

        /// <summary>
        /// Comprueba si el desguace es correcto. Es decir, si existe el desguace y además coincide con la contraseña indicada.
        /// </summary>
        /// <param name="usuario">Nombre de usuario.</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>Devuelve verdadero si el usuario existe.</returns>
        public static bool Autentificar(string usuario, string contrasena)
        {
            Desguace desguace = Obtener(usuario);
            if (desguace != null)
                return desguace.Contrasena.Equals(contrasena);
            else
                return false;
        }

        /// <summary>
        /// Guarda el desguace en la base de datos y actualiza la id.
        /// Si ya existía, actualiza sus valores.
        /// </summary>
        /// <returns>Devuelve verdadero si ha podido guardar o actualizar el desguace.</returns>
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
                                          "insert into desguaces (usuario,contrasena,nombre,nif,correoElectronico,direccion,telefono,informacionAdicional) " +
                                          "values (@usuario, @contrasena, @nombre, @nif, @correoElectronico, @direccion, @telefono, @informacionAdicional); " +
                                          "select max(id) as nuevaId from desguaces " +
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
                    command.CommandText = "update desguaces set usuario = @usuario, contrasena = @contrasena, nombre = @nombre, nif = @nif, correoElectronico = @correoElectronico, direccion = @direccion, telefono = @telefono, informacionAdicional = @informacionAdicional where id = @id";

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
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return resultado;
        }
    }
}
