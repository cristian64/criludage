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
        private bool sincronizada;

        /// <summary>
        /// Comparador que se utiliza para seleccionar la mejor propuesta de una solicitud.
        /// </summary>
        private class ComparadorNegociadoAutomatico : IComparer
        {
            private Solicitud solicitud;

            /// <summary>
            /// Constructor sobrecargado que recibe la solicitud a la que pertenecen las propuestas que se van a comparar.
            /// </summary>
            /// <param name="solicitud">Solicitud a la que pertenecen las propuestas que se van a comparar.</param>
            public ComparadorNegociadoAutomatico(Solicitud solicitud)
            {
                this.solicitud = solicitud;
            }

            /// <summary>
            /// Método de comparación.
            /// </summary>
            /// <param name="x">Propuesta 1</param>
            /// <param name="y">Propuesta 2</param>
            /// <returns>Devuelve -1 si x es menor, 0 si son iguales y 1 si y es menor.</returns>
            int IComparer.Compare(Object x, Object y)
            {
                Propuesta p1 = x as Propuesta;
                Propuesta p2 = y as Propuesta;

                if (estadoAceptable(p1.Estado))
                {
                    if (estadoAceptable(p2.Estado))
                    {
                        // Comparar precio y fecha
                        return compararPorPrecioYFecha(p1, p2);
                    }
                    else
                    {
                        // Devuelve p1
                        return -1;
                    }
                }
                else if (estadoAceptable(p2.Estado))
                {
                    // Devuelve p2
                    return 1;
                }
                else
                {
                    // Comparar precio y fecha
                    return compararPorPrecioYFecha(p1, p2);
                }

            }

            /// <summary>
            /// Compara dos propuestas en base a la fecha y el precio
            /// </summary>
            /// <param name="p1">Propuesta 1</param>
            /// <param name="p2">Propuesta 2</param>
            /// <returns>Devuelve -1 si p1 es menor, 0 si son iguales y 1 si p2 es menor.</returns>
            private int compararPorPrecioYFecha(Propuesta p1, Propuesta p2)
            {
                if (fechaAceptable(p1.FechaEntrega))
                {
                    if (fechaAceptable(p2.FechaEntrega))
                    {
                        // Mejor precio
                        return (int)(p1.Precio - p2.Precio);
                    }
                    else
                    {
                        // Devuelve p1
                        return -1;
                    }
                }
                else
                {
                    if (fechaAceptable(p2.FechaEntrega))
                    {
                        // Devuelve p2
                        return 1;
                    }
                    else
                    {
                        // Mejor precio
                        return (int)(p1.Precio - p2.Precio);
                    }
                }
            }

            /// <summary>
            /// Comprueba si una fecha entra dentro del plazo de la solicitud.
            /// </summary>
            /// <param name="fecha">Fecha a comprobar</param>
            /// <returns>Verdadero si la fecha entra dentro del plazo.</returns>
            private bool fechaAceptable(DateTime fecha)
            {
                return (fecha < solicitud.FechaEntrega);
            }

            /// <summary>
            /// Comprueba si un estado es igual o mejor que el pedido en la solicitud.
            /// </summary>
            /// <param name="estado">Estado a comparar</param>
            /// <returns>Verdadero si el estado es aceptable</returns>
            private bool estadoAceptable(ENEstadosPieza estado)
            {
                switch (solicitud.Estado)
                {
                    case ENEstadosPieza.NO_FUNCIONA:
                        return true;
                    case ENEstadosPieza.USADA:
                        return (estado != ENEstadosPieza.NO_FUNCIONA);
                    case ENEstadosPieza.NUEVA:
                        return (estado == ENEstadosPieza.NUEVA);
                    default:
                        return true;
                }
            }
        }

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
            sincronizada = false;
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
            sincronizada = false;
        }

        /// <summary>
        /// Sobreescritura del método ToString para convertir la solicitud en una cadena de caracteres.
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos de la solicitud separados por espacios.</returns>
        public override string ToString()
        {
            return Id + " " + IdCliente + " " + Descripcion + " " + NegociadoAutomatico + " " + PrecioMax + " " + Estado + " " + Fecha + " " + FechaEntrega + " " + FechaRespuesta + " " + remitida + " " + sincronizada;
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
        /// Indica si está sincronizada la solicitud.
        /// </summary>
        public bool Sincronizada
        {
            get { return sincronizada; }
            set { sincronizada = value; }
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
            solicitud.Sincronizada = int.Parse(dataReader["sincronizada"].ToString()) == 1 ? true : false;
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
                                          "insert into solicitudes (idCliente, descripcion, estado, fecha, fechaEntrega, fechaRespuesta, precioMax, negociadoAutomatico, remitida, sincronizada) " +
                                          "values (@idCliente, @descripcion, @estado, @fecha, @fechaEntrega, @fechaRespuesta, @precioMax, @negociadoAutomatico, @remitida, @sincronizada); " +
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
                    command.Parameters.AddWithValue("@remitida", Remitida ? 1 : 0);
                    command.Parameters.AddWithValue("@sincronizada", Sincronizada ? 1 : 0);

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
                    command.CommandText = "update solicitudes set idCliente = @idCliente, descripcion = @descripcion, estado = @estado, fecha = @fecha, fechaEntrega = @fechaEntrega, fechaRespuesta = @fechaRespuesta, precioMax = @precioMax, negociadoAutomatico = @negociadoAutomatico, remitida = @remitida, sincronizada = @sincronizada where id = @id";

                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@remitida", remitida ? 1 : 0);
                    command.Parameters.AddWithValue("@sincronizada", sincronizada ? 1 : 0);
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
                Registro.WriteLine("otro", "", e.Message);
                Registro.WriteLine("otro", "", e.StackTrace);
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
                Registro.WriteLine("otro", "", e.Message);
                Registro.WriteLine("otro", "", e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return solicitudes;
        }

        /// <summary>
        /// Accede a base de datos y obtiene todas las propuestas que tiene la solicitud.
        /// </summary>
        /// <param name="considerarNegociado">
        /// Si este valor está activo, se tendrá en cuenta el negociado automático de la solicitud.
        /// Si la solicitud tiene el negociado automático, sólo devolverá la propuesta que mejor se ajuste a la solicitud.
        /// </param>
        /// <returns>Devuelve una lista con todas las propuestas (o sólo una si considerarNegociado y negociadoAutomatico son True). Si no hay elementos, devuelve una lista sin elementos.</returns>
        public ArrayList ObtenerPropuestas(bool considerarNegociado)
        {
            ArrayList propuestas = Propuesta.ObtenerTodas(Id);

            // Se comprueba si está activado el negociado automático (y si además el invocador del método quiere que se tenga el cuenta el negociado).
            if (considerarNegociado && NegociadoAutomatico)
            {
                propuestas.Sort(new ComparadorNegociadoAutomatico(this));
                propuestas = propuestas.GetRange(0, 1);
            }

            return propuestas;
        }

        /// <summary>
        /// Extrae todas las solicitudes de la base de datos que han finalizado y que todavía no han sido remitidas por correo.
        /// Una solicitud ha finalizado si FechaRespuesta es anterior a la fecha actual.
        /// </summary>
        /// <returns>Devuelve una lista con todas las solicitudes. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerFinalizadasNoRemitidas()
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
                Registro.WriteLine("otro", "", e.Message);
                Registro.WriteLine("otro", "", e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return solicitudes;
        }

        /// <summary>
        /// Extrae todas las solicitudes de la base de datos que han finalizado y que todavía no han sido sincronizadas con el cliente.
        /// Una solicitud ha finalizado si FechaRespuesta es anterior a la fecha actual.
        /// </summary>
        /// <param name="idCliente">Identificador del usuario de la solicitud.</param>
        /// <returns>Devuelve una lista con todas las solicitudes. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerFinalizadasNoSincronizadas(int idCliente)
        {
            ArrayList solicitudes = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from solicitudes where idCliente = @idCliente and sincronizada = 0 and fechaRespuesta < { fn NOW() }";
                command.Parameters.AddWithValue("@idCliente", idCliente);

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    solicitudes.Add(crearSolicitud(dataReader));
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

            return solicitudes;
        }

        /// <summary>
        /// Obtiene las solicitudes de un cliente concreto.
        /// </summary>
        /// <param name="idCliente">Identificador del cliente.</param>
        /// <returns>Devuelve una lista con las solicitudes. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerPorCliente(int idCliente)
        {
            ArrayList solicitudes = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from solicitudes where idCliente = @idCliente";
                command.Parameters.AddWithValue("@idCliente", idCliente);

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    solicitudes.Add(crearSolicitud(dataReader));
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

            return solicitudes;
        }

        /// <summary>
        /// Marca la solicitud como remitida y lo almacena en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si todo ha ido correctamente.</returns>
        public bool MarcarRemitida()
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "update solicitudes set remitida = @remitida where id = @id";

                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@remitida",1);

                if (command.ExecuteNonQuery() == 1)
                    Remitida = true;
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

            return Remitida;
        }

        /// <summary>
        /// Marca la solicitud como sincronizada y lo almacena en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si todo ha ido correctamente.</returns>
        public bool MarcarSincronizada()
        {
           SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "update solicitudes set sincronizada = @sincronizada where id = @id";

                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@sincronizada", 1);

                if (command.ExecuteNonQuery() == 1)
                    Sincronizada = true;
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

            return Sincronizada;
        }


    }
}
