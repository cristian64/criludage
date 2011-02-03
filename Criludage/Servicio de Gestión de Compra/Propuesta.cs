using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Biblioteca_de_Entidades_de_Negocio;

namespace Servicio_de_Gestión_de_Compra
{
    public class Propuesta : ENPropuesta
    {
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
            Estado = ENEstadosPieza.USADA;
            Foto = null;
            Confirmada = false;
        }

        /// <summary>
        /// Constructor sobrecargado para realizar un upcasting desde ENPropuesta a Propuesta.
        /// </summary>
        /// <param name="propuesta">Objeto ENPropuesta desde el que se va a crear la nueva propuesta.</param>
        public Propuesta(ENPropuesta propuesta)
        {
            Id = propuesta.Id;
            IdSolicitud = propuesta.IdSolicitud;
            IdDesguace = propuesta.IdDesguace;
            Descripcion = propuesta.Descripcion;
            FechaEntrega = propuesta.FechaEntrega;
            Precio = propuesta.Precio;
            Estado = propuesta.Estado;
            Foto = propuesta.Foto;
            Confirmada = false;
        }

        /// <summary>
        /// Sobreescritura del método ToString para convertir la propuesta en una cadena de caracteres.
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos de la propuesta separados por espacios.</returns>
        public override string ToString()
        {
            return Id + " " + IdSolicitud + " " + IdDesguace + " " + Descripcion + " " + Precio + " " + Estado + " " + FechaEntrega + " " + Confirmada;
        }

        /// <summary>
        /// Devuelve la propuesta compatible con SGC.ENPropuesta. Es decir, realiza un downcasting de la propuesta.
        /// </summary>
        public ENPropuesta ENPropuesta
        {
            get
            {
                ENPropuesta propuesta = new ENPropuesta();
                propuesta.Id = Id;
                propuesta.IdDesguace = IdDesguace;
                propuesta.IdSolicitud = IdSolicitud;
                propuesta.Descripcion = Descripcion;
                propuesta.Estado = Estado;
                propuesta.FechaEntrega = FechaEntrega;
                propuesta.Precio = Precio;
                propuesta.Foto = Foto;
                propuesta.Confirmada = Confirmada;
                return propuesta;
            }
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
            propuesta.Estado = (ENEstadosPieza)Enum.Parse(typeof(ENEstadosPieza), dataReader["estado"].ToString());
            propuesta.FechaEntrega = (DateTime)dataReader["fechaEntrega"];
            propuesta.Precio = float.Parse(dataReader["precio"].ToString());
            try
            {
                propuesta.Foto = (byte[])dataReader["foto"];
            }
            catch (Exception)
            {
                propuesta.Foto = null;
            }
            propuesta.Confirmada = int.Parse(dataReader["confirmada"].ToString()) == 1 ? true : false;
            return propuesta;
        }

        /// <summary>
        /// Guarda la propuesta en la base de datos y actualiza su id.
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
                      command.CommandText = "BEGIN TRAN " +
                                            "insert into propuestas (idDesguace, idSolicitud, descripcion, estado, fechaEntrega, precio, foto, confirmada) " +
                                            "values (@idDesguace, @idSolicitud, @descripcion, @estado, @fechaEntrega, @precio, @foto, @confirmada); " +
                                            "select max(id) as nuevaId from propuestas " +
                                            "COMMIT TRAN";

                      command.Parameters.AddWithValue("@idSolicitud", IdSolicitud);
                      command.Parameters.AddWithValue("@idDesguace", IdDesguace);
                      command.Parameters.AddWithValue("@descripcion", Descripcion);
                      command.Parameters.AddWithValue("@estado", Estado);
                      command.Parameters.AddWithValue("@fechaEntrega", FechaEntrega);
                      command.Parameters.AddWithValue("@precio", Precio);
                      if (Foto != null)
                      {
                          command.Parameters.AddWithValue("@foto", Foto);
                      }
                      else
                      {
                          command.Parameters.AddWithValue("@foto", DBNull.Value).SqlDbType = SqlDbType.Image;
                      }
                      command.Parameters.AddWithValue("@confirmada", Confirmada ? 1 : 0);

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
                    command.CommandText = "update propuestas set idDesguace = @idDesguace, idSolicitud = @idSolicitud, descripcion = @descripcion, estado = @estado, fechaEntrega = @fechaEntrega, precio = @precio, foto = @foto, confirmada = @confirmada where id = @id";

                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@idSolicitud", IdSolicitud);
                    command.Parameters.AddWithValue("@idDesguace", IdDesguace);
                    command.Parameters.AddWithValue("@descripcion", Descripcion);
                    command.Parameters.AddWithValue("@estado", Estado);
                    command.Parameters.AddWithValue("@fechaEntrega", FechaEntrega);
                    command.Parameters.AddWithValue("@precio", Precio);
                    if (Foto != null)
                    {
                        command.Parameters.AddWithValue("@foto", Foto);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@foto", DBNull.Value).SqlDbType = SqlDbType.Image;
                    }
                    command.Parameters.AddWithValue("@confirmada", Confirmada ? 1 : 0);

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
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
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
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
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
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return propuestas;
        }

        /// <summary>
        /// Extrae todas las propuestas confirmadas de la base de datos de un cliente concreto (lo que sería el historia de compra).
        /// </summary>
        /// <param name="idCliente">Identificador del cliente que se quiere comprobar.</param>
        /// <returns>Devuelve una lista con todas las propuestas. Si no hay ninguna, devuelve una lista sin elementos.</returns>
        public static ArrayList ObtenerConfirmadas(int idCliente)
        {
            ArrayList propuestas = new ArrayList();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select propuestas.* from propuestas, solicitudes where solicitudes.id = propuestas.idSolicitud and confirmada = 1 and solicitudes.idCliente = @idCliente";
                command.Parameters.AddWithValue("@idCliente", idCliente);

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    propuestas.Add(crearPropuesta(dataReader));
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

            return propuestas;
        }

        /// <summary>
        /// Marca la propuesta como confirmada y lo almacena en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si todo ha ido bien.</returns>
        public bool MarcarConfirmada()
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "update propuestas set confirmada = @confirmada where id = @id";
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@confirmada",1);

                if (command.ExecuteNonQuery() == 1)
                    Confirmada = true;
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

            return Confirmada;
        }
    }
}
