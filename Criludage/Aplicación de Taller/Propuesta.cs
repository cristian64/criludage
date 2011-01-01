using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace Aplicación_de_Taller
{
    public class Propuesta : SGC.ENPropuesta
    {
        private String informacionAdicional;
        private int idEmpleado;

        public Propuesta()
        {
            Id = 0;
            IdSolicitud = 0;
            IdDesguace = 0;
            Descripcion = "";
            FechaEntrega = DateTime.Now.AddDays(1);
            Precio = 0.0f;
            Estado = SGC.ENEstadosPieza.USADA;
            informacionAdicional = "";
            idEmpleado = 0;
        }

        public String Texto()
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
            propuesta.IdDesguace = int.Parse(dataReader["idCliente"].ToString());
            propuesta.IdSolicitud = int.Parse(dataReader["idCliente"].ToString());
            propuesta.Descripcion = dataReader["descripcion"].ToString();
            propuesta.Estado = (SGC.ENEstadosPieza)Enum.Parse(typeof(SGC.ENEstadosPieza), dataReader["estado"].ToString());
            propuesta.FechaEntrega = (DateTime)dataReader["fechaEntrega"];
            propuesta.Precio = float.Parse(dataReader["precioMax"].ToString());
            propuesta.informacionAdicional = dataReader["informacionAdicional"].ToString();
            try
            {
                propuesta.idEmpleado = int.Parse(dataReader["idEmpleado"].ToString());
            }
            catch (Exception)
            {
                propuesta.idEmpleado = 0;
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
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["criludage"].ConnectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                if (Propuesta.Obtener(Id) == null)
                {
                    command.CommandText = "insert into propuestas (id, idDesguace, idSolicitud, descripcion, estado, fechaEntrega, precio, informacionAdicional, idEmpleado) " +
                                            "values (@id, @idDesguace, @idSolicitud, @descripcion, @estado, @fechaEntrega, @precio, @informacionAdicional, @idEmpleado);";
                }
                else
                {
                    command.CommandText = "update propuestas set idDesguace = @idDesguace, idSolicitud = @idSolicitud, descripcion = @descripcion, estado = @estado, fechaEntrega = @fechaEntrega, precio = @precio, informacionAdicional = @informacionAdicional, idEmpleado = @idEmpleado where id = @id";
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
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["criludage"].ConnectionString);

            try
            {
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
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["criludage"].ConnectionString);

            try
            {
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
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["criludage"].ConnectionString);

            try
            {
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
