using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Biblioteca_de_Entidades_de_Negocio;
using System.Collections;

namespace Servicio_de_Gestión_de_Compra
{
    public class Solicitud : ENSolicitud
    {
        private bool remitida;

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
            Estado = ENEstadosPieza.USADA;
            Fecha = DateTime.Now;
            FechaEntrega = DateTime.Now.AddDays(7);
            FechaRespuesta = DateTime.Now.Add(new TimeSpan(0, 5, 0));
            remitida = false;
        }

        /// <summary>
        /// Constructor sobrecargado para realizar un upcasting desde ENSolicitud a Solicitud.
        /// </summary>
        /// <param name="solicitud">Objeto ENSolicitud desde el que se va a crear la nueva solicitud.</param>
        public Solicitud(ENSolicitud solicitud)
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

            remitida = false;
        }

        /// <summary>
        /// Sobreescritura del método ToString para convertir la solicitud en una cadena de caracteres.
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos de la solicitud separados por espacios.</returns>
        public override string ToString()
        {
            return Id + " " + IdCliente + " " + Descripcion + " " + NegociadoAutomatico + " " + PrecioMax + " " + Estado + " " + Fecha + " " + FechaEntrega + " " + FechaRespuesta + " " + remitida;
        }

        /// <summary>
        /// Indica si está remitida la solicitud.
        /// </summary>
        public bool Remitida
        {
            get { return remitida; }
            set { remitida = value; }
        }

        /// <summary>
        /// Devuelve la solicitud compatible con SGC.ENSolicitud. Es decir, realiza un downcasting de la solicitud.
        /// </summary>
        public ENSolicitud ENSolicitud
        {
            get
            {
                ENSolicitud solicitud = new ENSolicitud();
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
        /// Consulta la base de datos para obtener el cliente que realizó la solicitud.
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
            solicitud.Estado = (ENEstadosPieza)Enum.Parse(typeof(ENEstadosPieza), dataReader["estado"].ToString());
            solicitud.Fecha = (DateTime)dataReader["fecha"];
            solicitud.FechaEntrega = (DateTime)dataReader["fechaEntrega"];
            solicitud.FechaRespuesta = (DateTime)dataReader["fechaRespuesta"];
            solicitud.PrecioMax = float.Parse(dataReader["precioMax"].ToString());
            solicitud.NegociadoAutomatico = int.Parse(dataReader["negociadoAutomatico"].ToString()) == 1 ? true : false;
            solicitud.Remitida = int.Parse(dataReader["remitida"].ToString()) == 1 ? true : false;
            return solicitud;
        }

        /// <summary>
        /// Guarda la solicitud en la base de datos y actualiza la id.
        /// Si ya existía, actualiza sus valores.
        /// </summary>
        /// <returns>Devuelve verdadero si ha podido guardar o actualizar la solicitud.</returns>
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
                                          "insert into solicitudes (idCliente, descripcion, estado, fecha, fechaEntrega, fechaRespuesta, precioMax, negociadoAutomatico, remitida) " +
                                          "values (@idCliente, @descripcion, @estado, @fecha, @fechaEntrega, @fechaRespuesta, @precioMax, @negociadoAutomatico, @remitida); " +
                                          "select max(id) as nuevaId from solicitudes; " +
                                          "COMMIT TRAN";

                    command.Parameters.AddWithValue("@idCliente", IdCliente);
                    command.Parameters.AddWithValue("@descripcion", Descripcion);
                    command.Parameters.AddWithValue("@estado", Estado);
                    command.Parameters.AddWithValue("@fecha", Fecha);
                    command.Parameters.AddWithValue("@fechaEntrega", FechaEntrega);
                    command.Parameters.AddWithValue("@fechaRespuesta", FechaRespuesta);
                    command.Parameters.AddWithValue("@precioMax", PrecioMax);
                    command.Parameters.AddWithValue("@negociadoAutomatico", NegociadoAutomatico ? 1 : 0);
                    command.Parameters.AddWithValue("@remitida", 0);

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
                    command.CommandText = "update solicitudes set idCliente = @idCliente, descripcion = @descripcion, estado = @estado, fecha = @fecha, fechaEntrega = @fechaEntrega, fechaRespuesta = @fechaRespuesta, precioMax = @precioMax, negociadoAutomatico = @negociadoAutomatico, remitida = @remitida where id = @id";

                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@remitida", remitida ? 1 : 0);
                    command.Parameters.AddWithValue("@idCliente", IdCliente);
                    command.Parameters.AddWithValue("@descripcion", Descripcion);
                    command.Parameters.AddWithValue("@estado", Estado);
                    command.Parameters.AddWithValue("@fecha", Fecha);
                    command.Parameters.AddWithValue("@fechaEntrega", FechaEntrega);
                    command.Parameters.AddWithValue("@fechaRespuesta", FechaRespuesta);
                    command.Parameters.AddWithValue("@precioMax", PrecioMax);
                    command.Parameters.AddWithValue("@negociadoAutomatico", NegociadoAutomatico ? 1 : 0);

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
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
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
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return solicitud;
        }

        /// <summary>
        /// Accede a base de datos y cuenta todas las solicitudes.
        /// </summary>
        /// <returns>Devuelve un número con la cantidad de solicitudes.</returns>
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
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
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
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
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

        /// <summary>
        /// Extrae todas las solicitudes de la base de datos que han finalizado y que todavía no han sido remitidas por correo.
        /// Una solicitud ha finalizado si FechaRespuesta es anterior a la fecha actual.
        /// </summary>
        /// <returns>Devuelve una lista con todas las solicitudes. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerExpiradas()
        {
            ArrayList solicitudes = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from solicitudes where remitida = 0 and fechaRespuesta < { fn NOW() }";

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    solicitudes.Add(crearSolicitud(dataReader));
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

            return solicitudes;
        }
    }
}
