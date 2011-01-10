using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace Aplicación_de_Escritorio
{
    public class Solicitud : SGC.ENSolicitud
    {
        private String informacionAdicional;
        private int idEmpleado;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Solicitud()
        {
            Id = 0;
            IdCliente = 0;
            Descripcion = "";
            NegociadoAutomatico = false;
            PrecioMax = 0.0f;
            Estado = SGC.ENEstadosPieza.USADA;
            Fecha = DateTime.Now;
            FechaEntrega = DateTime.Now.AddDays(7);
            FechaRespuesta = DateTime.Now.Add(new TimeSpan(0, 5, 0));

            informacionAdicional = "";
            idEmpleado = 0;
        }

        /// <summary>
        /// Constructor sobrecargado para realizar un upcasting desde ENSolicitud a Solicitud.
        /// </summary>
        /// <param name="solicitud">Objeto ENSolicitud desde el que se va a crear la nueva solicitud.</param>
        public Solicitud(SGC.ENSolicitud solicitud)
        {
            Id = solicitud.Id;
            IdCliente = solicitud.IdCliente;
            Descripcion = solicitud.Descripcion;
            NegociadoAutomatico = solicitud.NegociadoAutomatico;
            PrecioMax = solicitud.PrecioMax;
            Estado = solicitud.Estado;
            Fecha = solicitud.Fecha;
            FechaEntrega = solicitud.FechaEntrega;
            FechaRespuesta = solicitud.FechaRespuesta;

            informacionAdicional = "";
            idEmpleado = 0;
        }

        /// <summary>
        /// Sobreescritura del método ToString para convertir la solicitud en una cadena de caracteres.
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos de la solicitud separados por espacios.</returns>
        public override string ToString()
        {
            return Id + " " + IdCliente + " " + Descripcion + " " + NegociadoAutomatico + " " + PrecioMax + " " + Estado + " " + Fecha + " " + FechaEntrega + " " + FechaRespuesta + " " + informacionAdicional + " " + idEmpleado;
        }

        /// <summary>
        /// Información adicional de la solicitud.
        /// </summary>
        public String InformacionAdicional
        {
            get { return informacionAdicional; }
            set { informacionAdicional = value; }
        }

        /// <summary>
        /// Identificador del empleado.
        /// Hay que establecer el valor 0 para representar que ningún empleado ha realizado la solicitud.
        /// </summary>
        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        /// <summary>
        /// Devuelve la solicitud compatible con SGC.ENSolicitud. Es decir, realiza un downcasting de la solicitud.
        /// </summary>
        public SGC.ENSolicitud ENSolicitud
        {
            get
            {
                SGC.ENSolicitud solicitud = new SGC.ENSolicitud();
                solicitud.Id = Id;
                solicitud.IdCliente = IdCliente;
                solicitud.Descripcion = Descripcion;
                solicitud.NegociadoAutomatico = NegociadoAutomatico;
                solicitud.PrecioMax = PrecioMax;
                solicitud.Estado = Estado;
                solicitud.Fecha = Fecha;
                solicitud.FechaEntrega = FechaEntrega;
                solicitud.FechaRespuesta = FechaRespuesta;
                return solicitud;
            }
        }

        /// <summary>
        /// Accede a base de datos y extrae el empleado que realizó la solicitud.
        /// </summary>
        /// <returns>Devuelve un objeto Empleado con todos los atributos. Si no hay empleado, devuelve null.</returns>
        public Empleado ObtenerEmpleado()
        {
            return Empleado.Obtener(idEmpleado);
        }

        /// <summary>
        /// Consume el servicio web para obtener el cliente que realizó la solicitud.
        /// </summary>
        /// <returns>Devuelve un objeto Cliente con todos sus atributos. Este método no debería devolver null nunca.</returns>
        public Cliente ObtenerCliente()
        {
            return Cliente.Obtener(IdCliente);
        }

        /// <summary>
        /// A partir de una consulta Sql extrae los valores de los atributos y los asigna al objeto.
        /// </summary>
        /// <param name="dataReader">Resultado de la consulta Sql que contiene los datos.</param>
        private static Solicitud crearSolicitud(SqlDataReader dataReader)
        {
            Solicitud solicitud = new Solicitud();
            solicitud.Id = int.Parse(dataReader["id"].ToString());
            solicitud.IdCliente = int.Parse(dataReader["idCliente"].ToString());
            solicitud.Descripcion = dataReader["descripcion"].ToString();
            solicitud.Estado = (SGC.ENEstadosPieza) Enum.Parse(typeof(SGC.ENEstadosPieza), dataReader["estado"].ToString());
            solicitud.Fecha = (DateTime) dataReader["fecha"];
            solicitud.FechaEntrega = (DateTime) dataReader["fechaEntrega"];
            solicitud.FechaRespuesta = (DateTime)dataReader["fechaRespuesta"];
            solicitud.PrecioMax = float.Parse(dataReader["precioMax"].ToString());
            solicitud.NegociadoAutomatico = int.Parse(dataReader["negociadoAutomatico"].ToString()) == 1 ? true : false;
            solicitud.informacionAdicional = dataReader["informacionAdicional"].ToString();
            try
            {
                solicitud.idEmpleado = int.Parse(dataReader["idEmpleado"].ToString());
            }
            catch (Exception)
            {
                solicitud.idEmpleado = 0;
            }
            return solicitud;
        }

        /// <summary>
        /// Guarda la solicitud en la base de datos.
        /// Si ya existía, actualiza sus valores.
        /// </summary>
        /// <returns>Devuelve verdadero si ha podido guardar o actualizar la solicitud.</returns>
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
                if (Solicitud.Obtener(Id) == null)
                {
                    command.CommandText = "insert into solicitudes (id, idCliente, descripcion, estado, fecha, fechaEntrega, fechaRespuesta, precioMax, negociadoAutomatico, informacionAdicional, idEmpleado) " +
                                            "values (@id, @idCliente, @descripcion, @estado, @fecha, @fechaEntrega, @fechaRespuesta, @precioMax, @negociadoAutomatico, @informacionAdicional, @idEmpleado);";
                }
                else
                {
                    command.CommandText = "update solicitudes set idCliente = @idCliente, descripcion = @descripcion, estado = @estado, fecha = @fecha, fechaEntrega = @fechaEntrega, fechaRespuesta = @fechaRespuesta, precioMax = @precioMax, negociadoAutomatico = @negociadoAutomatico, informacionAdicional = @informacionAdicional, idEmpleado = @idEmpleado where id = @id";
                }
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@idCliente", IdCliente);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@estado", Estado);
                command.Parameters.AddWithValue("@fecha", Fecha);
                command.Parameters.AddWithValue("@fechaEntrega", FechaEntrega);
                command.Parameters.AddWithValue("@fechaRespuesta", FechaRespuesta);
                command.Parameters.AddWithValue("@precioMax", PrecioMax);
                command.Parameters.AddWithValue("@negociadoAutomatico", NegociadoAutomatico ? 1 : 0);
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
        /// Extrae una solicitud desde la base de datos a partir del indentificador.
        /// </summary>
        /// <param name="id">Identificador de la solicitud</param>
        /// <returns></returns>
        public static Solicitud Obtener(int id)
        {
            Solicitud solicitud = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Configuracion.Default.bd);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from solicitudes where id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    solicitud = crearSolicitud(dataReader);
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

            return solicitud;
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
        /// Extrae todas las solicitudes de la base de datos.
        /// </summary>
        /// <returns>Devuelve una lista con todas las solicitudes. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerTodas()
        {
            ArrayList solicitudes = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Configuracion.Default.bd);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from solicitudes";

                SqlDataReader dataReader = command.ExecuteReader();
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
                connection.Close();
            }

            return solicitudes;
        }

        /// <summary>
        /// Accede a base de datos y cuenta todas las solicitudes que tiene un determinado empleado.
        /// </summary>
        /// <param name="idEmpleado">Identificador del empleado que se quiere comprobar.</param>
        /// <returns>Devuelve un número con la cantidad de solicitudes de un empleado.</returns>
        public static int ContarTodas(int idEmpleado)
        {
            return ObtenerTodas(idEmpleado).Count; //TODO es mejorable, haciendo un select count(*) ...
        }

        /// <summary>
        /// Extrae todas las solicitudes de la base de datos que haya realizado un determinado empleado.
        /// </summary>
        /// <param name="idEmpleado">Identificador del empleado.</param>
        /// <returns>Devuelve una lista con todas las solicitudes. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerTodas(int idEmpleado)
        {
            ArrayList solicitudes = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Configuracion.Default.bd);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from solicitudes where idEmpleado = @idEmpleado";
                command.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                SqlDataReader dataReader = command.ExecuteReader();
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
                connection.Close();
            }

            return solicitudes;
        }

        /// <summary>
        /// Accede a base de datos y cuenta todas las propuestas que tiene la solicitud.
        /// </summary>
        /// <returns>Devuelve una lista con todas las propuestas. Si no hay elementos, devuelve una lista sin elementos.</returns>
        public ArrayList ObtenerPropuestas()
        {
            return Propuesta.ObtenerTodas(Id);
        }

        /// <summary>
        /// Accede a base de datos y cuenta todas las propuestas que tiene la solicitud.
        /// </summary>
        /// <returns>Devuelve la cantidad de propuestas que tiene la solicitud.</returns>
        public int ContarPropuestas()
        {
            return Propuesta.ContarTodas(Id);
        }
    }
}
