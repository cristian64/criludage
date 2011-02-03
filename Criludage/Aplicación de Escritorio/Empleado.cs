using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Data;

namespace Aplicación_de_Escritorio
{
    public class Empleado
    {
        private int id;
        private String usuario;
        private String contrasena;
        private String nombre;
        private String nif;
        private String correoElectronico;
        private bool administrador;
        private Image foto;

        /// <summary>
        /// Sobreescritura del método ToString para convertir el empleado en una cadena de caracteres.
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos del empleado separados por espacios.</returns>
        public override string ToString()
        {
            return id + " " + usuario + " " + contrasena + " " + nombre + " " + nif + " " + correoElectronico + " " + administrador;
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Empleado()
        {
            id = 0;
            usuario = "";
            contrasena = "";
            nombre = "";
            nif = "";
            correoElectronico = "";
            administrador = false;
            foto = null;
        }

        /// <summary>
        /// Identificador del empleado.
        /// Es de sólo lectura porque será la base de datos quien proporcione el identificador al introducir un nuevo empleado.
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Nombre de usuario del empleado.
        /// </summary>
        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Contraseña del empleado codificada en sha-1.
        /// El valor que se asigne deberá convertirse previamente a sha-1.
        /// El valor que se obtenga estará ya en sha-1.
        /// Es decir, este atributo siempre almacena la contraseña después de aplicarle sha-1.
        /// </summary>
        public String Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        /// <summary>
        /// Nombre completo del empleado.
        /// </summary>
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Correo electrónico.
        /// No se comprueba que sea válido.
        /// </summary>
        public String CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        /// <summary>
        /// Número de identificación fiscal.
        /// No se comprueba que sea válido.
        /// </summary>
        public String Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        /// <summary>
        /// Indica si el empleado tiene privilegios de administrador o no.
        /// </summary>
        public bool Administrador
        {
            get { return administrador; }
            set { administrador = value; }
        }

        /// <summary>
        /// Obtiene o establece la foto de la propuesta.
        /// 
        /// </summary>
        public Image Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        /// <summary>
        /// A partir de una consulta Sql extrae los valores de los atributos y los asigna al objeto.
        /// </summary>
        /// <param name="dataReader">Resultado de la consulta Sql que contiene los datos.</param>
        private static Empleado crearEmpleado(SqlDataReader dataReader)
        {
            Empleado empleado = new Empleado();
            empleado.id = int.Parse(dataReader["id"].ToString());
            empleado.usuario = dataReader["usuario"].ToString();
            empleado.contrasena = dataReader["contrasena"].ToString();
            empleado.nombre = dataReader["nombre"].ToString();
            empleado.nif = dataReader["nif"].ToString();
            empleado.correoElectronico = dataReader["correoElectronico"].ToString();
            empleado.administrador = int.Parse(dataReader["administrador"].ToString()) == 1 ? true : false;
            try
            {
                // Se extraen los bytes de la imagen y se convierte a Image.
                byte[] fotoBytes = (byte[]) dataReader["foto"];
                MemoryStream memoryStream = new MemoryStream(fotoBytes);
                empleado.foto = Image.FromStream(memoryStream);
            }
            catch (Exception)
            {
                empleado.foto = null;
            }
            return empleado;
        }

        /// <summary>
        /// Guarda el empleado en la base de datos.
        /// Si ya existe, actualizará los atributos en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si pudo guardar el empleado correctamente.</returns>
        public bool Guardar()
        {
            bool resultado = false;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Configuracion.Default.bd);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                if (id == 0)
                {
                    command.CommandText = "insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador, foto) " +
                                            "values (@usuario, @contrasena, @nombre, @nif, @correoElectronico, @administrador, @foto);";
                }
                else
                {
                    command.CommandText = "update empleados set usuario = @usuario, contrasena = @contrasena, nombre = @nombre, correoElectronico = @correoElectronico, nif = @nif, administrador = @administrador, foto = @foto where id = @id";
                    command.Parameters.AddWithValue("@id", id);
                }
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contrasena", contrasena);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@correoElectronico", correoElectronico);
                command.Parameters.AddWithValue("@nif", nif);
                command.Parameters.AddWithValue("@administrador", administrador ? 1 : 0);
                if (foto != null)
                {
                    // Se convierte el objeto Image en bytes y se guarda.
                    MemoryStream memoryStream = new MemoryStream();
                    foto.Save(memoryStream, foto.RawFormat);
                    byte[] fotoBytes = memoryStream.ToArray();
                    command.Parameters.AddWithValue("@foto", fotoBytes);
                }
                else
                {
                    command.Parameters.AddWithValue("@foto", DBNull.Value).SqlDbType = SqlDbType.Image;
                }

                if (command.ExecuteNonQuery() == 1)
                {
                    resultado = true;

                    // Si era un nuevo empleado, hay que extraer su identificador.
                    if (id == 0)
                        id = Empleado.Obtener(usuario).id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return resultado;
        }

        /// <summary>
        /// Elimina el empleado de la base de datos.
        /// Una vez eliminado, el objeto que invocó el método no debería utilizarse más (salvo que se vuelva a guardar).
        /// Una vez eliminado, establece el identificador del empleado a 0.
        /// </summary>
        /// <returns>Devuelve verdadero si ha podido borrarlo correctamente.</returns>
        public bool Eliminar()
        {
            bool resultado = false;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Configuracion.Default.bd);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "delete from empleados where id = @id";
                command.Parameters.AddWithValue("@id", id);

                if (command.ExecuteNonQuery() == 1)
                {
                    resultado = true;
                    id = 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return resultado;
        }

        /// <summary>
        /// Extrae un empleado de la base de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador del empleado que se quiere extraer.</param>
        /// <returns>Devuelve un objeto Empleado con todos sus atributos. Si no lo encuentra, devuelve null.</returns>
        public static Empleado Obtener(int id)
        {
            Empleado empleado = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Configuracion.Default.bd);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from empleados where id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    empleado = crearEmpleado(dataReader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return empleado;
        }

        /// <summary>
        /// Extrae un empleado de la base de datos a partir de su nombre de usuario.
        /// </summary>
        /// <param name="usuario">Nombre de usuario del empleado que se quiere extraer.</param>
        /// <returns>Devuelve un objeto Empleado con todos sus atributos. Si no lo encuentra, devuelve null.</returns>
        public static Empleado Obtener(String usuario)
        {
            Empleado empleado = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Configuracion.Default.bd);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from empleados where usuario = @usuario";
                command.Parameters.AddWithValue("@usuario", usuario);

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    empleado = crearEmpleado(dataReader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return empleado;
        }

        /// <summary>
        /// Extrae todos los empleados que hay en la base de datos.
        /// </summary>
        /// <returns>Devuelve una lista con objetos de tipo Empleado. Si no hay empleados, devuelve un sin elementos.</returns>
        public static ArrayList ObtenerTodos()
        {
            ArrayList empleados = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Configuracion.Default.bd);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from empleados";

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    empleados.Add(crearEmpleado(dataReader));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return empleados;
        }

        /// <summary>
        /// Extrae todas las solicitudes que ha rellenado el empleado.
        /// </summary>
        /// <returns>Devuelve una lista con las solicitudes. Si no hay ninguna, devuelve una lista vacía.</returns>
        public ArrayList ObtenerSolicitudes()
        {
            return Solicitud.ObtenerTodas(id);
        }
    }
}
