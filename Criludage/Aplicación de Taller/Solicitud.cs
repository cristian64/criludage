using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace Aplicación_de_Taller
{
    public class Solicitud : SGC.ENSolicitud
    {
        private String informacionAdicional;
        private int idEmpleado;

        public Solicitud()
        {
            Id = 0;
            IdCliente = 0;
            Descripcion = "";
            NegociadoAutomatico = false;
            PrecioMax = 0.0f;
            Estado = SGC.ENEstadosPieza.USADA;
            Fecha = DateTime.Now;
            FechaEntrega = DateTime.Now.AddDays(4);

            informacionAdicional = "";
            idEmpleado = 0;
        }

        public String Texto()
        {
            return Id + " " + IdCliente + " " + Descripcion + " " + NegociadoAutomatico + " " + PrecioMax + " " + Estado + " " + Fecha + " " + FechaEntrega + " " + informacionAdicional + " " + idEmpleado;
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
            solicitud.PrecioMax = float.Parse(dataReader["precioMax"].ToString());
            solicitud.NegociadoAutomatico = int.Parse(dataReader["negociadoAutomatico"].ToString()) == 1 ? true : false;
            solicitud.informacionAdicional = dataReader["informacionAdicional"].ToString();
            try
            {
                solicitud.idEmpleado = int.Parse(dataReader["idEmpleado"].ToString());
            }
            catch (Exception e)
            {
                solicitud.idEmpleado = 0;
            }
            return solicitud;
        }

        /// <summary>
        /// Guarda la solicitud en la base de datos.
        /// Si ya existía, actualiza sus valores.
        /// </summary>
        /// <returns></returns>
        public bool Guardar()
        {
            bool resultado = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["criludage"].ConnectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                if (Solicitud.Obtener(Id) == null)
                {
                    command.CommandText = "insert into solicitudes (id, idCliente, descripcion, estado, fecha, fechaEntrega, precioMax, negociadoAutomatico, informacionAdicional, idEmpleado) " +
                                            "values (@id, @idCliente, @descripcion, @estado, @fecha, @fechaEntrega, @precioMax, @negociadoAutomatico, @informacionAdicional, @idEmpleado);";
                }
                else
                {
                    command.CommandText = "update solicitudes set idCliente = @idCliente, descripcion = @descripcion, estado = @estado, fecha = @fecha, fechaEntrega = @fechaEntrega, precioMax = @precioMax, negociadoAutomatico = @negociadoAutomatico, informacionAdicional = @informacionAdicional, idEmpleado = @idEmpleado where id = @id";
                }
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@idCliente", IdCliente);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@estado", Estado);
                command.Parameters.AddWithValue("@fecha", Fecha);
                command.Parameters.AddWithValue("@fechaEntrega", FechaEntrega);
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
                Console.WriteLine("Solicitud.Guardar()");
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return resultado;
        }

        /// <summary>
        /// Accede a base de datos y extrae el empleado que realizó la solicitud.
        /// </summary>
        /// <returns>Devuelve un objeto Empleado con todos los atributos. Si no hay empleado, devuelve null.</returns>
        public Empleado GetEmpleado()
        {
            return Empleado.Obtener(idEmpleado);
        }

        /// <summary>
        /// Extrae una solicitud desde la base de datos a partir del indentificador.
        /// </summary>
        /// <param name="id">Identificador de la solicitud</param>
        /// <returns></returns>
        public static Solicitud Obtener(int id)
        {
            Solicitud solicitud = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["criludage"].ConnectionString);

            try
            {
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
                Console.WriteLine("Solicitud.Obtener(id)");
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return solicitud;
        }

        /// <summary>
        /// Extrae todas las solicitudes de la base de datos.
        /// </summary>
        /// <returns>Devuelve una lista con todas las solicitudes. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerTodas()
        {
            ArrayList solicitudes = new ArrayList();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["criludage"].ConnectionString);

            try
            {
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
                Console.WriteLine("Solicitudes.ObtenerTodas()");
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return solicitudes;
        }
    }
}
