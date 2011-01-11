using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;
using System.Configuration;
using System.Threading;
using System.Collections;

namespace Servicio_de_Gestión_de_Compra
{
    /// <summary>
    /// Descripción breve de InterfazRemota
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class InterfazRemota : System.Web.Services.WebService
    {
        /// <summary>
        /// Contador que se inicializa al número de segundos que tiene el año. Se incrementa en cada nueva solicitud.
        /// Provisional hasta que se cree la base de datos que autoincremente los identificadores automáticamente.
        /// </summary>
        private static int contador = DateTime.Now.DayOfYear * 86400 + DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;

        /// <summary>
        /// Instancia del productor que publica las solicitudes en el topic desde el que escuchan los desguaces.
        /// </summary>
        private static Productor productor = null;
        private static bool inicializado = false;

        /// <summary>
        /// Inicializa la conexión con ActiveMQ y arranca el demonio que procesa las solicitudes que hayan expirado.
        /// </summary>
        [WebMethod]
        public void Inicializar()
        {
            if (!inicializado)
            {
                try
                {
                    // Se establece la conexión con el servicio de mensajería.
                    productor = new Productor();
                    productor.Conectar(ConfigurationManager.ConnectionStrings["activemq"].ConnectionString, ConfigurationManager.ConnectionStrings["topic"].ConnectionString);

                    // Se arranca el demonio que procesa las propuestas y solicitudes.
                    DemonioCutre.Iniciar();

                    inicializado = true;
                }
                catch (Exception e)
                {
                    DebugCutre.WriteLine(e.Message);
                    DebugCutre.WriteLine(e.StackTrace);
                    inicializado = false;
                }
            }
        }


        /// <summary>
        /// Una nueva solicitud que se va a distribuir a los desguaces.
        /// </summary>
        /// <param name="solicitud">Solicitud de la pieza.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Contraseña para la autenticación.</param>
        /// <returns>Devuelve el identificador de la solicitud. Si devuelve 0, significa que ocurrió un error.</returns>
        [WebMethod]
        public int SolicitarPieza(ENSolicitud solicitud, String usuario, String contrasena)
        {
            // TODO
            // Comprueba que el usuario es correcto y tiene acceso a esta operación.
            // Comprueba que la solicitud es válida.
            // Añade la solicitud a la base de datos del servicio.
            // Encola la solicitud en el topic.
            // Devuelve verdadero (aunque dijimos que no sería simplemente un booleano, sino algo más elaborado).

			int id = 0;
			
            try
            {
                // Comprobar usuario como Cliente
                Cliente c = Cliente.Obtener(usuario);
                if (c.Contrasena.Equals(contrasena))
                {
                    solicitud.Id = 0; // Condicion para que Guardar sea crear y no actualizar ¿Mejorar?
                    Solicitud s = new Solicitud(solicitud);
                    if (s.Guardar())
                    {
                        id = solicitud.Id = s.Id;

                        DebugCutre.WriteLine("Enviando pieza al topic...");
                        productor.Enviar(solicitud);
                        DebugCutre.WriteLine("Enviada la pieza al topic.");
                    }
                }
            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }

            return id;
        }


        /// <summary>
        /// Se propone una nueva pieza para una solicitud determinada.
        /// </summary>
        /// <param name="propuesta">Propuesta que se va a añadir.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Contraseña para la autenticación.</param>
        /// <returns>Devuelve el identificador de la propuesta. Si devuelve 0, significa que ocurrió un error.</returns>
        [WebMethod]
        public int ProponerPieza(ENPropuesta propuesta, String usuario, String contrasena)
        {
            // TODO
            // Comprueba que el usuario es correcto y tiene acceso a esta operación.
            // Comprueba que la solicitud existe y la propuesta es válida.
            // Añade la propuesta a la lista de propuestas de la solicitud.
            // Devuelve verdadero (aunque dijimos que no sería simplemente un booleano, sino algo más elaborado).

			int id = 0;
			
            try
            {
                // Comprobar usuario como Desguace
                Desguace d = Desguace.Obtener(usuario);
                if (d.Contrasena.Equals(contrasena))
                {
                    propuesta.Id = 0; // Condicion para que Guardar sea crear y no actualizar ¿mejorar?
                    Propuesta p = new Propuesta(propuesta);
                    if (p.Guardar())
                    {
                        id = propuesta.Id = p.Id;
                    }
                }
            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }

            return id;
        }


        /// <summary>
        /// Busca un cliente en la base de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador del cliente que se busca.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Usuario para la autenticación.</param>
        /// <returns>Devuelve el objeto ENCliente que se busca. Si no se encuentra, devuelve null.</returns>
        [WebMethod]
        public ENCliente ObtenerCliente(int id, string usuario, string contrasena)
        {
            // Este servicio se puede consumir por los clientes y los desguaces.
            Cliente autCliente = Cliente.Obtener(usuario);
            Desguace autDesguace = Desguace.Obtener(usuario);

            if (autCliente.Contrasena.Equals(contrasena) || autDesguace.Contrasena.Equals(contrasena))
            {
                Cliente c = Cliente.Obtener(id);

                if (c != null)
                    return c.ENCliente;
            }

            return null;

        }

        /// <summary>
        /// Busca un cliente en la base de datos a partir de su nombre.
        /// </summary>
        /// <param name="cliente">Nombre del cliente que se busca.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Usuario para la autenticación.</param>
        /// <returns>Devuelve el objeto ENCliente que se busca. Si no se encuentra, devuelve null.</returns>
        [WebMethod]
        public ENCliente ObtenerClientePorUsuario(string cliente, string usuario, string contrasena)
        {
            // Este servicio se puede consumir por los clientes y los desguaces.
            Cliente autCliente = Cliente.Obtener(usuario);
            Desguace autDesguace = Desguace.Obtener(usuario);

            if (autCliente.Contrasena.Equals(contrasena) || autDesguace.Contrasena.Equals(contrasena))
            {
                Cliente c = Cliente.Obtener(cliente);

                if (c != null)
                    return c.ENCliente;
            }

            return null;
        }

        /// <summary>
        /// Busca un desguace en la base de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador del desguace.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Usuario para la autenticación.</param>
        /// <returns>Devuelve el objeto ENDesguace que se busca. Si no se encuentra, devuelve null.</returns>
        [WebMethod]
        public ENDesguace ObtenerDesguace(int id, string usuario, string contrasena)
        {
            // Este servicio se puede consumir por los clientes y los desguaces.
            Cliente autCliente = Cliente.Obtener(usuario);
            Desguace autDesguace = Desguace.Obtener(usuario);

            if (autCliente.Contrasena.Equals(contrasena) || autDesguace.Contrasena.Equals(contrasena))
            {
                Desguace d = Desguace.Obtener(id);

                if (d != null)
                    return d.ENDesguace;
            }

            return null;
        }

        /// <summary>
        /// Busca un desguace en la base de datos a partir de su nombre.
        /// </summary>
        /// <param name="desguace">Nombre del desguace que se busca.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Usuario para la autenticación.</param>
        /// <returns>Devuelve el objeto ENDesguace que se busca. Si no se encuentra, devuelve null.</returns>
        [WebMethod]
        public ENDesguace ObtenerDesguacePorUsuario(string desguace, string usuario, string contrasena)
        {
            // Este servicio se puede consumir por los clientes y los desguaces.
            Cliente autCliente = Cliente.Obtener(usuario);
            Desguace autDesguace = Desguace.Obtener(usuario);

            if (autCliente.Contrasena.Equals(contrasena) || autDesguace.Contrasena.Equals(contrasena))
            {
                Desguace d = Desguace.Obtener(desguace);

                if (d != null)
                    return d.ENDesguace;
            }

            return null;
        }

        /// <summary>
        /// Registra al cliente en la base de datos del servicio.
        /// </summary>
        /// <param name="cliente">Cliente a registrar.</param>
        /// <returns>Devuelve el id asignado al nuevo cliente. Si es -1 significa que el nombre ya está cogido. Devolver 0 indica otro error.</returns>
        [WebMethod]
        public int RegistroCliente(ENCliente cliente)
        {
            // TODO Añadir 'serial' y que compruebe que esta ok

            int id = 0;
			
            try
            {
                // Se comprueba si existe
                if (Cliente.Obtener(cliente.Usuario) != null)
                {
                    return -1; // Nombre ya cogido
                }

                cliente.Id = 0; // Condicion para que Guardar sea crear y no actualizar
                Cliente c = new Cliente(cliente);

                if (c.Guardar())
                {
                    id = cliente.Id = c.Id;
                }

            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }

            return id;
        }

        /// <summary>
        /// Registra al desguace en la base de datos del servicio.
        /// </summary>
        /// <param name="cliente">Desguace a registrar.</param>
        /// <returns>Devuelve el id asignado al nuevo cliente. Si es -1 significa que el nombre ya está cogido. Devolver 0 indica otro error.</returns>
        [WebMethod]
        public int RegistroDesguace(ENDesguace desguace)
        {
            // TODO Añadir 'serial' y que compruebe que esta ok

            int id = 0;

            try
            {
                // Se comprueba si existe
                if (Desguace.Obtener(desguace.Usuario) != null)
                {
                    return -1; // Nombre ya cogido
                }

                desguace.Id = 0; // Condicion para que Guardar sea crear y no actualizar
                Desguace d = new Desguace(desguace);
                
                if(d.Guardar())
                {
                    id = desguace.Id = d.Id;
                }
            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }

            return id;
        }

        /// <summary>
        /// Consulta la base de datos y obtiene las propuestas de una solicitud.
        /// </summary>
        /// <param name="solicitud">Solicitud de la que se devuelven las propuestas</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Usuario para la autenticación.</param>
        /// <returns>Lista con las propuestas de la solicitud.</returns>
        [WebMethod]
        public ArrayList ObtenerPropuestas(ENSolicitud solicitud, string usuario, string contrasena)
        {
            ArrayList propuestas = new ArrayList();

            try
            {
                // Comprobar usuario como cliente
                Cliente c = Cliente.Obtener(usuario);
                if (c.Contrasena.Equals(contrasena))
                {
                    Solicitud s = Solicitud.Obtener(solicitud.Id); // Se hace asi para que coja 'remitida', que no esta en ENSolicitud

                    if (s.Remitida)
                    {
                        propuestas = s.ObtenerPropuestas();
                    }
                }

            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }


            return propuestas;
        }

    }
}
