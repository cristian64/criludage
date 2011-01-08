using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Data;

namespace Aplicación_de_Escritorio
{
    public class Propuesta : SGC.ENPropuesta
    {
        private String informacionAdicional;
        private int idEmpleado;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Propuesta()
        {
            Id = 0;
            IdSolicitud = 0;
            IdDesguace = 0;
            Descripcion = "";
            FechaEntrega = DateTime.Now.AddDays(1);
            Precio = 0.0f;
            Estado = SGC.ENEstadosPieza.USADA;
            Foto = null;

            informacionAdicional = "";
            idEmpleado = 0;
        }

        /// <summary>
        /// Constructor sobrecargado para realizar un upcasting desde ENPropuesta a Propuesta.
        /// </summary>
        /// <param name="propuesta">Objeto ENPropuesta desde el que se va a crear la nueva propuesta.</param>
        public Propuesta(SGC.ENPropuesta propuesta)
        {
            Id = propuesta.Id;
            IdSolicitud = propuesta.IdSolicitud;
            IdDesguace = propuesta.IdDesguace;
            Descripcion = propuesta.Descripcion;
            FechaEntrega = propuesta.FechaEntrega;
            Precio = propuesta.Precio;
            Estado = propuesta.Estado;
            Foto = propuesta.Foto;

            informacionAdicional = "";
            idEmpleado = 0;
        }

        /// <summary>
        /// Sobreescritura del método ToString para convertir la propuesta en una cadena de caracteres.
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos de la propuesta separados por espacios.</returns>
        public override string ToString()
        {
            return Id + " " + IdSolicitud + " " + IdDesguace + " " + Descripcion + " " + Precio + " " + Estado + " " + FechaEntrega + " " + informacionAdicional + " " + idEmpleado;
        }

        /// <summary>
        /// Información adicional de la propuesta.
        /// </summary>
        public String InformacionAdicional
        {
            get { return informacionAdicional; }
            set { informacionAdicional = value; }
        }

        /// <summary>
        /// Identificador del empleado.
        /// Hay que establecer el valor 0 para representar que ningún empleado ha realizado la propuesta.
        /// </summary>
        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        /// <summary>
        /// Foto del empleado (tipo Image).
        /// Obtiene o establece la imagen para la pieza propuesta. Hace una conversión de byte[] a Image y viceversa.
        /// </summary>
        public Image Foto2
        {
            get
            {
                if (Foto != null)
                {
                    MemoryStream memoryStream = new MemoryStream(Foto);
                    return Image.FromStream(memoryStream);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    value.Save(memoryStream, value.RawFormat);
                    Foto = memoryStream.ToArray();
                }
                else
                {
                    Foto = null;
                }
            }
        }

        /// <summary>
        /// Devuelve la propuesta compatible con SGC.ENPropuesta. Es decir, realiza un downcasting de la propuesta.
        /// </summary>
        public SGC.ENPropuesta ENPropuesta
        {
            get
            {
                SGC.ENPropuesta propuesta = new SGC.ENPropuesta();
                propuesta.Id = Id;
                propuesta.IdDesguace = IdDesguace;
                propuesta.IdSolicitud = IdSolicitud;
                propuesta.Descripcion = Descripcion;
                propuesta.Estado = Estado;
                propuesta.FechaEntrega = FechaEntrega;
                propuesta.Precio = Precio;
                propuesta.Foto = Foto;
                return propuesta;
            }
        }

        /// <summary>
        /// Accede a base de datos y extrae el empleado que realizó la propuesta.
        /// </summary>
        /// <returns>Devuelve un objeto Empleado con todos los atributos. Si no hay empleado, devuelve null.</returns>
        public Empleado ObtenerEmpleado()
        {
            return Empleado.Obtener(idEmpleado);
        }

        /// <summary>
        /// Accede a base de datos y extrae la solicitud a la que está referida la propuesta.
        /// </summary>
        /// <returns>Devuelve un objeto Solicitud con todos sus atributos. Este método no debería devolver null nunca.</returns>
        public Solicitud ObtenerSolicitud()
        {
            return Solicitud.Obtener(IdSolicitud);
        }

        /// <summary>
        /// Consume el servicio web para obtener el desguace que realizó la propuesta.
        /// </summary>
        /// <returns>Devuelve un objeto Desguace con todos sus atributos. Este método no debería devolver null nunca.</returns>
        public Desguace ObtenerDesguace()
        {
            return Desguace.Obtener(IdDesguace);
        }

        /// <summary>
        /// A partir de una consulta Sql extrae los valores de los atributos y los asigna al objeto.
        /// </summary>
        /// <param name="dataReader">Resultado de la consulta Sql que contiene los datos.</param>
        private static Propuesta crearPropuesta(SqlDataReader dataReader)
        {
            Propuesta propuesta = new Propuesta();
            propuesta.Id = int.Parse(dataReader["id"].ToString());
            propuesta.IdDesguace = int.Parse(dataReader["idDesguace"].ToString());
            propuesta.IdSolicitud = int.Parse(dataReader["idSolicitud"].ToString());
            propuesta.Descripcion = dataReader["descripcion"].ToString();
            propuesta.Estado = (SGC.ENEstadosPieza)Enum.Parse(typeof(SGC.ENEstadosPieza), dataReader["estado"].ToString());
            propuesta.FechaEntrega = (DateTime)dataReader["fechaEntrega"];
            propuesta.Precio = float.Parse(dataReader["precio"].ToString());
            propuesta.informacionAdicional = dataReader["informacionAdicional"].ToString();
            try
            {
                propuesta.idEmpleado = int.Parse(dataReader["idEmpleado"].ToString());
            }
            catch (Exception)
            {
                propuesta.idEmpleado = 0;
            }
            try
            {
                propuesta.Foto = (byte[]) dataReader["foto"];
            }
            catch (Exception)
            {
                propuesta.Foto = null;
            }
            return propuesta;
        }

        /// <summary>
        /// Guarda la propuesta en la base de datos.
        /// Si ya existía, actualiza sus valores.
        /// </summary>
        /// <returns>Devuelve verdadero si ha podido guardar o actualizar la propuesta.</returns>
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
                if (Propuesta.Obtener(Id) == null)
                {
                    command.CommandText = "insert into propuestas (id, idDesguace, idSolicitud, descripcion, estado, fechaEntrega, precio, informacionAdicional, idEmpleado, foto) " +
                                            "values (@id, @idDesguace, @idSolicitud, @descripcion, @estado, @fechaEntrega, @precio, @informacionAdicional, @idEmpleado, @foto);";
                }
                else
                {
                    command.CommandText = "update propuestas set idDesguace = @idDesguace, idSolicitud = @idSolicitud, descripcion = @descripcion, estado = @estado, fechaEntrega = @fechaEntrega, precio = @precio, informacionAdicional = @informacionAdicional, idEmpleado = @idEmpleado, foto = @foto where id = @id";
                }
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@IdSolicitud", IdSolicitud);
                command.Parameters.AddWithValue("@IdDesguace", IdDesguace);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@estado", Estado);
                command.Parameters.AddWithValue("@fechaEntrega", FechaEntrega);
                command.Parameters.AddWithValue("@precio", Precio);
                command.Parameters.AddWithValue("@informacionAdicional", informacionAdicional);
                if (idEmpleado > 0)
                    command.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                else
                    command.Parameters.AddWithValue("@idEmpleado", DBNull.Value);
                if (Foto != null)
                {
                    command.Parameters.AddWithValue("@foto", Foto);
                }
                else
                {
                    command.Parameters.AddWithValue("@foto", DBNull.Value).SqlDbType = SqlDbType.Image;
                }

                if (command.ExecuteNonQuery() == 1)
                    resultado = true;
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
        /// Extrae una propuesta desde la base de datos a partir del indentificador.
        /// </summary>
        /// <param name="id">Identificador de la propuesta</param>
        /// <returns></returns>
        public static Propuesta Obtener(int id)
        {
            Propuesta propuesta = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from propuestas where id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    propuesta = crearPropuesta(dataReader);
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

            return propuesta;
        }

        /// <summary>
        /// Accede a base de datos y cuenta todas las propuestas.
        /// </summary>
        /// <returns>Devuelve un número con la cantidad de propuestas.</returns>
        public static int ContarTodas()
        {
            return ObtenerTodas().Count; //TODO es mejorable, haciendo un select count(*) ...
        }

        /// <summary>
        /// Extrae todas las propuestas de la base de datos.
        /// </summary>
        /// <returns>Devuelve una lista con todas las propuestas. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerTodas()
        {
            ArrayList propuestas = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from propuestas";

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    propuestas.Add(crearPropuesta(dataReader));
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

            return propuestas;
        }

        /// <summary>
        /// Accede a base de datos y cuenta todas las propuestas que tiene una determinada solicitud.
        /// </summary>
        /// <param name="idSolicitud">Identificador de la solicitud que se quiere comprobar.</param>
        /// <returns>Devuelve un número con la cantidad de propuestas de una solicitud.</returns>
        public static int ContarTodas(int idSolicitud)
        {
            return ObtenerTodas(idSolicitud).Count; //TODO es mejorable, haciendo un select count(*) ...
        }

        /// <summary>
        /// Extrae todas las propuestas de la base de datos que pertenecen a una determinada solicitud.
        /// </summary>
        /// <param name="idSolicitud">Identificador de la solicitud que se quiere comprobar.</param>
        /// <returns>Devuelve una lista con todas las propuestas. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerTodas(int idSolicitud)
        {
            ArrayList propuestas = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from propuestas where idSolicitud = @idSolicitud";
                command.Parameters.AddWithValue("@idSolicitud", idSolicitud);

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    propuestas.Add(crearPropuesta(dataReader));
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

            return propuestas;
        }
    }
}
