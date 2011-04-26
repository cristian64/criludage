using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Web.Services.Protocols;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;
using System.Configuration;
using System.Threading;
using System.Collections;
using Biblioteca_Común.Encriptacion;

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

                    // Se arranca el demonio que ejecuta el algoritmo de alta disponibilidad.
                    AltaDisponibilidad.Iniciar();

                    // Se arranca el demonio que procesa las propuestas y solicitudes.
                    DemonioCutre.Iniciar();

                    inicializado = true;
                }
                catch (Exception e)
                {
                    Registro.WriteLine("otro", "", e.Message);
                    Registro.WriteLine("otro", "", e.StackTrace);
                    inicializado = false;
                }
            }
        }

        /// <summary>
        /// Una nueva solicitud que se va a distribuir a los desguaces.
        /// </summary>
        /// <param name="solicitud">Solicitud de la pieza.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Contrasena para la autenticación.</param>
        /// <returns>Devuelve el identificador de la solicitud. Si devuelve 0, significa que ocurrió un error.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public int SolicitarPieza(ENSolicitud solicitud, String usuario, String contrasena)
        {
			int id = 0;
			
            try
            {
                // Comprobar usuario como Cliente
                Cliente c = Cliente.Obtener(usuario);
                if (c != null && c.Contrasena.Equals(contrasena) && solicitud.IdCliente == c.Id)
                {
                    solicitud.Id = 0; // Condicion para que Guardar sea crear y no actualizar ¿Mejorar?
                    Solicitud s = new Solicitud(solicitud);
                    if (s.Guardar())
                    {
                        id = solicitud.Id = s.Id;

                        Registro.WriteLine("solicitud", usuario, "SolicitarPieza: Enviando solicitud " + id + " al topic...");
                        RSA enc = new RSA(77, 221); // TODO cambiar valores de clave
                        productor.Enviar(enc.Encriptar(Auxiliar.Serializar(solicitud)));
                        Registro.WriteLine("solicitud", usuario, "SolicitarPieza: Enviada la solicitud al topic.");
                    }
                    else
                    {
                        Registro.WriteLine("solicitud", usuario, "SolicitarPieza: Error al guardar la solicitud en BD (" + solicitud.Descripcion + ")");
                    }
                }
                else
                {
                    Registro.WriteLine("solicitud", usuario, "SolicitarPieza: Fallo autentificación (" + usuario + ")");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("solicitud", usuario, e.Message);
                Registro.WriteLine("solicitud", usuario, e.StackTrace);
            }

            return id;
        }


        /// <summary>
        /// Se propone una nueva pieza para una solicitud determinada.
        /// </summary>
        /// <param name="propuesta">Propuesta que se va a añadir.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Contrasena para la autenticación.</param>
        /// <returns>Devuelve el identificador de la propuesta. Si devuelve -1, significa que el plazo de la solicitud
        /// ha acabado. Si devuelve 0, significa que ocurrió un error.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public int ProponerPieza(ENPropuesta propuesta, String usuario, String contrasena)
        {
			int id = 0;
			
            try
            {
                // Comprobar usuario como Desguace
                Desguace d = Desguace.Obtener(usuario);
                if (d != null && d.Contrasena.Equals(contrasena) && propuesta.IdDesguace == d.Id)
                {
                    Solicitud s = Solicitud.Obtener(propuesta.IdSolicitud);
                    if (s.FechaRespuesta > DateTime.Now)
                    {
                        propuesta.Id = 0; // Condicion para que Guardar sea crear y no actualizar ¿mejorar?
                        Propuesta p = new Propuesta(propuesta);
                        if (p.Guardar())
                        {
                            id = propuesta.Id = p.Id;
                            Registro.WriteLine("propuesta", usuario, "ProponerPieza: Guardada la propuesta " + id);
                        }
                        else
                        {
                            Registro.WriteLine("propuesta", usuario, "ProponerPieza: Error al guardar la propuesta en BD (" + propuesta.Descripcion + ")");
                        }
                    }
                    else
                    {
                        id = -1;
                        Registro.WriteLine("propuesta", usuario, "ProponerPieza: Error intentando proponer propuesta en solicitud " + s.Id + " fuera de plazo (" + propuesta.Descripcion + ")");
                    }
                }
                else
                {
                    Registro.WriteLine("propuesta", usuario, "ProponerPieza: Fallo autentificación (" + usuario + ")");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("propuesta", usuario, e.Message);
                Registro.WriteLine("propuesta", usuario, e.StackTrace);
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
        [ExtensionMaestroAtributo]
        public ENCliente ObtenerCliente(int id, string usuario, string contrasena)
        {
            // Este servicio se puede consumir por los clientes y los desguaces.
            if (Cliente.Autentificar(usuario, contrasena) || Desguace.Autentificar(usuario, contrasena))
            {
                Cliente c = Cliente.Obtener(id);
                if (c != null)
                {
                    if (!c.Usuario.Equals(usuario))
                        c.Contrasena = "";

                    Registro.WriteLine("otro", usuario, "ObtenerCliente: Cliente \"" + c.Usuario + "\" encontrado");
                    return c.ENCliente;
                }
                else
                {
                    Registro.WriteLine("otro", usuario, "ObtenerCliente: Cliente " + id + " no encontrado");
                }
            }
            else
            {
                Registro.WriteLine("otro", usuario, "ObtenerCliente: Fallo autentificación (" + usuario + ")");
            }
            return null;
        }

        /// <summary>
        /// Busca un cliente en la base de datos a partir de su nombre.
        /// </summary>
        /// <param name="cliente">Nombre de usuario del cliente que se busca.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Usuario para la autenticación.</param>
        /// <returns>Devuelve el objeto ENCliente que se busca. Si no se encuentra, devuelve null.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public ENCliente ObtenerClientePorUsuario(string cliente, string usuario, string contrasena)
        {
            // Este servicio se puede consumir por los clientes y los desguaces.
            if (Cliente.Autentificar(usuario, contrasena) || Desguace.Autentificar(usuario, contrasena))
            {
                Cliente c = Cliente.Obtener(cliente);
                if (c != null)
                {
                    if (!c.Usuario.Equals(usuario))
                        c.Contrasena = "";

                    Registro.WriteLine("otro", usuario, "ObtenerClientePorUsuario: Cliente \"" + cliente + "\" encontrado");
                    return c.ENCliente;
                }
                else
                {
                    Registro.WriteLine("otro", usuario, "ObtenerClientePorUsuario: Cliente \"" + cliente + "\" no encontrado");
                }
            }
            else
            {
                Registro.WriteLine("otro", usuario, "ObtenerClientePorUsuario: Fallo autentificación (" + usuario + ")");
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
        [ExtensionMaestroAtributo]
        public ENDesguace ObtenerDesguace(int id, string usuario, string contrasena)
        {
            // Este servicio se puede consumir por los clientes y los desguaces.
            if (Cliente.Autentificar(usuario, contrasena) || Desguace.Autentificar(usuario, contrasena))
            {
                Desguace d = Desguace.Obtener(id);
                if (d != null)
                {
                    if (!d.Usuario.Equals(usuario))
                        d.Contrasena = "";

                    Registro.WriteLine("otro", usuario, "ObtenerDesguace: Desguace " + d.Usuario + " encontrado");
                    return d.ENDesguace;
                }
                else
                {
                    Registro.WriteLine("otro", usuario, "ObtenerDesguace: Desguace " + id + " no encontrado");
                }
            }
            else
            {
                Registro.WriteLine("otro", usuario, "ObtenerDesguace: Fallo autentificación (" + usuario + ")");
            }
            return null;
        }

        /// <summary>
        /// Busca un desguace en la base de datos a partir de su nombre.
        /// </summary>
        /// <param name="desguace">Nombre de usuario del desguace que se busca.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Usuario para la autenticación.</param>
        /// <returns>Devuelve el objeto ENDesguace que se busca. Si no se encuentra, devuelve null.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public ENDesguace ObtenerDesguacePorUsuario(string desguace, string usuario, string contrasena)
        {
            // Este servicio se puede consumir por los clientes y los desguaces.
            if (Cliente.Autentificar(usuario, contrasena) || Desguace.Autentificar(usuario, contrasena))
            {
                Desguace d = Desguace.Obtener(desguace);
                if (d != null)
                {
                    if (!d.Usuario.Equals(usuario))
                        d.Contrasena = "";

                    Registro.WriteLine("otro", usuario, "ObtenerDesguacePorUsuario: Desguace " + desguace + " encontrado");
                    return d.ENDesguace;
                }
                else
                {
                    Registro.WriteLine("otro", usuario, "ObtenerDesguacePorUsuario: Desguace \"" + desguace + "\" no encontrado");
                }
            }
            else
            {
                Registro.WriteLine("otro", usuario, "ObtenerDesguacePorUsuario: Fallo autentificación (" + usuario + ")");
            }
            return null;
        }

        /// <summary>
        /// Actualiza un cliente en la base de datos que ya estaba previamente registrado.
        /// </summary>
        /// <param name="cliente">Cliente que se va a actualizar. Debe existiren la base de datos.</param>
        /// <param name="usuario">Nombre de usuario del cliente. Debe coincide con el usuario del objeto ENCliente también recibido.</param>
        /// <param name="contrasena">Contrasena actual del cliente.</param>
        /// <returns>Devuelve verdado si ha conseguido actualizar el cliente.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public bool ActualizarCliente(ENCliente cliente, string usuario, string contrasena)
        {
            bool correcto = false;

            try
            {
                Cliente c = Cliente.Obtener(cliente.Id);
                if (c != null)
                {
                    if (c.Usuario.Equals(usuario) && c.Contrasena.Equals(contrasena))
                    {
                        Cliente nuevosDatos = new Cliente(cliente);
                        nuevosDatos.Id = c.Id;
                        correcto = nuevosDatos.Guardar();
                        if (correcto)
                        {
                            Registro.WriteLine("modificación", usuario, "ActualizarCliente: Desguace " + cliente.Id + " actualizado");
                        }
                        else
                        {
                            Registro.WriteLine("modificación", usuario, "ActualizarCliente: Error al actualizar el cliente " + cliente.Id + " en la BD");
                        }
                    }
                    else
                    {
                        Registro.WriteLine("modificación", usuario, "ActualizarCliente: Fallo autentificación \"" + c.Usuario + "\" \"" + usuario + "\"");
                    }
                }
                else
                {
                    Registro.WriteLine("modificación", usuario, "ActualizarCliente: No se puede obtener es desguace " + cliente.Id);
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("modificación", usuario, e.Message);
                Registro.WriteLine("modificación", usuario, e.StackTrace);
            }

            return correcto;
        }

        /// <summary>
        /// Actualiza un desguace en la base de datos que ya estaba previamente registrado.
        /// </summary>
        /// <param name="desguace">Desguace que se va a actualizar. Debe existiren la base de datos.</param>
        /// <param name="usuario">Nombre de usuario del desguace. Debe coincide con el usuario del objeto ENDesguace también recibido.</param>
        /// <param name="contrasena">Contrasena actual del desguace.</param>
        /// <returns>Devuelve verdado si ha conseguido actualizar el desguace.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public bool ActualizarDesguace(ENDesguace desguace, string usuario, string contrasena)
        {
            bool correcto = false;

            try
            {
                Desguace d = Desguace.Obtener(desguace.Id);
                if (d != null)
                {
                    if (d.Usuario.Equals(usuario) && d.Contrasena.Equals(contrasena))
                    {
                        Desguace nuevosDatos = new Desguace(desguace);
                        nuevosDatos.Id = d.Id;
                        correcto = nuevosDatos.Guardar();
                        if (correcto)
                        {
                            Registro.WriteLine("modificación", usuario, "ActualizarDesguace: Desguace " + desguace.Id + " actualizado");
                        }
                        else
                        {
                            Registro.WriteLine("modificación", usuario, "ActualizarDesguace: Error al actualizar el desguace " + desguace.Id + " en la BD");
                        }
                    }
                    else
                    {
                        Registro.WriteLine("modificación", usuario, "ActualizarDesguace: Fallo autentificación \"" + d.Usuario + "\" \"" + usuario + "\"");
                    }
                }
                else
                {
                    Registro.WriteLine("modificación", usuario, "ActualizarDesguace: No se puede obtener es desguace " + desguace.Id);
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("modificación", usuario, e.Message);
                Registro.WriteLine("modificación", usuario, e.StackTrace);
            }

            return correcto;
        }

        /// <summary>
        /// Registra al cliente en la base de datos del servicio.
        /// </summary>
        /// <param name="cliente">Cliente a registrar.</param>
        /// <returns>Devuelve el id asignado al nuevo cliente. Si es -1 significa que el nombre ya está cogido. Devolver 0 indica otro error.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public int RegistroCliente(ENCliente cliente)
        {
            // TODO Añadir 'serial' y que compruebe que esta ok

            int id = 0;
			
            try
            {
                // Se comprueba si existe. Si existe, se devuelve -1.
                if (Cliente.Obtener(cliente.Usuario) != null || Desguace.Obtener(cliente.Usuario) != null)
                {
                    Registro.WriteLine("registro", "", "RegistroCliente: Error porque \"" + cliente.Usuario + "\" ya está en uso");
                    return -1;
                }

                cliente.Id = 0; // Condicion para que Guardar sea crear y no actualizar
                Cliente c = new Cliente(cliente);
                if (c.Guardar())
                {
                    id = cliente.Id = c.Id;
                    Registro.WriteLine("registro", "", "RegistroCliente: Cliente \"" + cliente.Usuario + "\" registrado");
                }
                else
                {
                    Registro.WriteLine("registro", "", "RegistroCliente: Error al crear el cliente \"" + cliente.Usuario + "\" en la BD");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("registro", "", e.Message);
                Registro.WriteLine("registro", "", e.StackTrace);
            }

            return id;
        }

        /// <summary>
        /// Registra al desguace en la base de datos del servicio.
        /// </summary>
        /// <param name="cliente">Desguace a registrar.</param>
        /// <returns>Devuelve el id asignado al nuevo cliente. Si es -1 significa que el nombre ya está cogido. Devolver 0 indica otro error.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public int RegistroDesguace(ENDesguace desguace)
        {
            // TODO Añadir 'serial' y que compruebe que esta ok

            int id = 0;

            try
            {
                // Se comprueba si existe.  Si existe, se devuelve -1.
                if (Desguace.Obtener(desguace.Usuario) != null || Cliente.Obtener(desguace.Usuario) != null)
                {
                    Registro.WriteLine("registro", "", "RegistroDesguace: Error porque \"" + desguace.Usuario + "\" ya está en uso");
                    return -1;
                }

                desguace.Id = 0; // Condicion para que Guardar sea crear y no actualizar
                Desguace d = new Desguace(desguace);
                if (d.Guardar())
                {
                    id = desguace.Id = d.Id;
                    Registro.WriteLine("registro", "", "RegistroDesguace: Desguace \"" + desguace.Usuario + "\" registrado correctamente");
                }
                else
                {
                    Registro.WriteLine("registro", "", "RegistroDesguace: Error al crear el desguace \"" + desguace.Usuario + "\" en la BD");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("registro", "", e.Message);
                Registro.WriteLine("registro", "", e.StackTrace);
            }

            return id;
        }

        /// <summary>
        /// Consulta la base de datos y obtiene las propuestas de una solicitud.
        /// </summary>
        /// <param name="solicitud">Solicitud de la que se devuelven las propuestas</param>
        /// <param name="usuario">Nombre de usuario para la autenticación.</param>
        /// <param name="contrasena">Contrasena del usuario para la autenticación.</param>
        /// <returns>Lista con las propuestas de la solicitud.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public ArrayList ObtenerPropuestas(ENSolicitud solicitud, string usuario, string contrasena)
        {
            ArrayList propuestas = new ArrayList();

            try
            {
                // Comprobar usuario como cliente.
                Cliente c = Cliente.Obtener(usuario);
                if (c != null && c.Contrasena.Equals(contrasena))
                {
                    // Comprobamos que la solicitud corresponde al cliente.
                    Solicitud s = Solicitud.Obtener(solicitud.Id);
                    if (s.IdCliente == c.Id)
                    {
                        // Hay que extraer las propuetas de la solicitud y hacer el downcasting desde Propuesta a ENPropuesta.
                        ArrayList propuestasAux = s.ObtenerPropuestas(true);
                        foreach (Propuesta i in propuestasAux)
                            propuestas.Add(i.ENPropuesta);
                        Registro.WriteLine("propuesta", usuario, "ObtenerPropuestas: Obtenidas " + propuestas.Count + " propuestas de la solicitud " + solicitud.Id);
                    }
                    else
                    {
                        Registro.WriteLine("propuesta", usuario, "ObtenerPropuestas: Fallo autorización porque la solicitud " + solicitud.Id + " no pertenece al usuario \"" + solicitud.Id + "\"");
                    }
                }
                else
                {
                    Registro.WriteLine("propuesta", usuario, "ObtenerPropuestas: Fallo autentificación (" + usuario + ")");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("propuesta", usuario, e.Message);
                Registro.WriteLine("propuesta", usuario, e.StackTrace);
            }

            return propuestas;
        }

        /// <summary>
        /// Devuelve las solicitudes que han finalizado y que todavía no se han sincronizado con el taller de origen.
        /// </summary>
        /// <param name="usuario">Nombre de usuario del taller.</param>
        /// <param name="contrasena">Contrasena del taller.</param>
        /// <returns>Devuelve una lista de ENSolicitud. Si no hay, devuelve una lista vacía.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public ArrayList ObtenerFinalizadasNoSincronizadas(string usuario, string contrasena)
        {
            ArrayList solicitudes = new ArrayList();

            try
            {
                // Comprobar usuario como cliente
                Cliente c = Cliente.Obtener(usuario);
                if (c.Contrasena.Equals(contrasena))
                {
                    ArrayList solicitudesFinalizadas = Solicitud.ObtenerFinalizadasNoSincronizadas(c.Id);
                    foreach (Solicitud i in solicitudesFinalizadas)
                    {
                        if (i.MarcarSincronizada())
                            solicitudes.Add(i.ENSolicitud);
                    }
                    if (solicitudes.Count > 0)
                        Registro.WriteLine("solicitud", usuario, "ObtenerFinalizadasNoSincronizadas: Había " + solicitudesFinalizadas.Count + " solicitudes finalizadas y no sincronizdas");
                }
                else
                {
                    Registro.WriteLine("solicitud", usuario, "ObtenerFinalizadasNoSincronizadas: Fallo autentificación (" + usuario + ")");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("solicitud", usuario, e.Message);
                Registro.WriteLine("solicitud", usuario, e.StackTrace);
            }

            return solicitudes;
        }

        /// <summary>
        /// Devuelve las solicitudes del usuario.
        /// </summary>
        /// <param name="usuario">Nombre de usuario del cliente.</param>
        /// <param name="contrasena">Contrasena del cliente.</param>
        /// <returns>Devuelve una lista de ENSolicitud. Si no hay, devuelve una lista vacía.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public ArrayList ObtenerSolicitudesPorUsuario(string usuario, string contrasena)
        {
            ArrayList solicitudes = new ArrayList();

            try
            {
                // Autenticación
                Cliente c = Cliente.Obtener(usuario);
                if (c != null)
                {
                    if (c.Contrasena.Equals(contrasena))
                    {
                        ArrayList solicitudesUsuario = c.ObtenerSolicitudes();
                        foreach (Solicitud s in solicitudesUsuario)
                        {
                            solicitudes.Add(s.ENSolicitud);
                        }
                        Registro.WriteLine("solicitud", usuario, "ObtenerSolicitudesPorUsuario: obtenidas " + solicitudes.Count + " solicitudes");
                    }
                    else
                    {
                        Registro.WriteLine("solicitud", usuario, "ObtenerSolicitudesPorUsuario: Fallo autentificación (" + usuario + ")");
                    }
                }
                else
                {
                    Registro.WriteLine("solicitud", usuario, "ObtenerSolicitudesPorUsuario: no se encuentra el cliente (" + usuario + ")");
                }
                
            }
            catch (Exception e)
            {
                Registro.WriteLine("solicitud", usuario, e.Message);
                Registro.WriteLine("solicitud", usuario, e.StackTrace);
            }

            return solicitudes;
        }

        /// <summary>
        /// Obtiene una solicitud a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador de solicitud.</param>
        /// <param name="usuario">Nombre de usuario del cliente.</param>
        /// <param name="contrasena">Contrasena del cliente.</param>
        /// <returns>Devuelve el objeto ENSolicitud pedido. Si no existe, devuelve null.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public ENSolicitud ObtenerSolicitudPorId(int id, string usuario, string contrasena)
        {
            Solicitud solicitud = null;

            try
            {
                // Autenticacion
                Cliente c = Cliente.Obtener(usuario);
                if (c != null)
                {
                    if (c.Contrasena.Equals(contrasena))
                    {
                        solicitud = Solicitud.Obtener(id);

                        if (solicitud != null)
                        {
                            //Autorización
                            if (solicitud.IdCliente == c.Id)
                            {
                                Registro.WriteLine("solicitud", usuario, "ObtenerSolicitudPorId: obtenida la solicitud ( Id :  " + id + ")");
                                return solicitud.ENSolicitud;
                            }
                            else
                            {
                                Registro.WriteLine("solicitud", usuario, "ObtenerSolicitudPorId: la solicitud ( Id :  " + id + ") no es de este cliente ( " + usuario + ")");
                            }
                        }
                        else
                        {
                            Registro.WriteLine("solicitud", usuario, "ObtenerSolicitudPorId: no encontrada la solicitud ( Id :  " + id + ")");
                        }
                    }
                    else
                    {
                        Registro.WriteLine("solicitud", usuario, "ObtenerSolicitudPorId: Fallo autentificación (" + usuario + ")");
                    }
                }
                else
                {
                    Registro.WriteLine("solicitud", usuario, "ObtenerSolicitudPorId: no se encuentra el cliente (" + usuario + ")");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("solicitud", usuario, e.Message);
                Registro.WriteLine("solicitud", usuario, e.StackTrace);
            }

            return solicitud;
        }

        /// <summary>
        /// Obtiene una propuesta a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador de la propuesta</param>
        /// <param name="usuario">Nombre de usuario del cliente.</param>
        /// <param name="contrasena">Contrasena del cliente.</param>
        /// <returns>Devuelve el objeto ENPropuesta pedido. Si no existe, devuelve null.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public ENPropuesta ObtenerPropuestaPorId(int id, string usuario, string contrasena)
        {
            Propuesta propuesta = null;

            try
            {
                // Autenticacion
                Cliente c = Cliente.Obtener(usuario);
                if (c != null)
                {
                    if (c.Contrasena.Equals(contrasena))
                    {
                        propuesta = Propuesta.Obtener(id);

                        if (propuesta != null)
                        {
                            Registro.WriteLine("propuesta", usuario, "ObtenerPropuestaPorId: obtenida la propuesta ( Id :  " + id + ")");

                            return propuesta.ENPropuesta;
                        }
                        else
                        {
                            Registro.WriteLine("propuesta", usuario, "ObtenerPropuestaPorId: no se encuentra propuesta ( Id :  " + id + ")");
                        }

                    }
                    else
                    {
                        Registro.WriteLine("propuesta", usuario, "ObtenerPropuestaPorId: Fallo autentificación (" + usuario + ")");
                    }
                }
                else
                {
                    Registro.WriteLine("propuesta", usuario, "ObtenerPropuestaPorId: no se encuentra el cliente (" + usuario + ")");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("propuesta", usuario, e.Message);
                Registro.WriteLine("propuesta", usuario, e.StackTrace);
            }

            return propuesta;
        }

        /// <summary>
        /// Consulta la base de datos y obtiene las propuestas confirmadas de un cliente.
        /// </summary>
        /// <param name="usuario">Nombre de usuario del cliente.</param>
        /// <param name="contrasena">Contrasena del usuario para la autenticación.</param>
        /// <returns>Lista con las propuestas de la solicitud.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public ArrayList ObtenerPropuestasConfirmadas(string usuario, string contrasena)
        {
            ArrayList propuestas = new ArrayList();

            try
            {
                // Comprobar usuario como cliente.
                Cliente c = Cliente.Obtener(usuario);
                if (c != null && c.Contrasena.Equals(contrasena))
                {
                    // Hay que extraer las propuetas confirmadas y hacer el downcasting desde Propuesta a ENPropuesta.
                    ArrayList propuestasAux = Propuesta.ObtenerConfirmadas(c.Id);
                    foreach (Propuesta i in propuestasAux)
                        propuestas.Add(i.ENPropuesta);
                    Registro.WriteLine("propuesta", usuario, "ObtenerPropuestasConfirmadas: Obtenidas " + propuestas.Count + " propuestas del usuario (" + usuario + ")");
                }
                else
                {
                    Registro.WriteLine("propuesta", usuario, "ObtenerPropuestasConfirmadas: Fallo autentificación (" + usuario + ")");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("propuesta", usuario, e.Message);
                Registro.WriteLine("propuesta", usuario, e.StackTrace);
            }

            return propuestas;
        }

        /// <summary>
        /// Confirma la compra de una propuesta.
        /// </summary>
        /// <param name="propuesta">Propuesta que se va a confirmar.</param>
        /// <param name="usuario">Usuario para la autenticación.</param>
        /// <param name="contrasena">Contrasena para la autenticación.</param>
        /// <returns>Devuelve verdadero si ha podido confirmar la propuesta.</returns>
        [WebMethod]
        [ExtensionMaestroAtributo]
        public bool ConfirmarPropuesta(ENPropuesta propuesta, String usuario, String contrasena)
        {
            bool resultado = false;

            try
            {
                // Se comprueba que el usuario es válido.
                Cliente c = Cliente.Obtener(usuario);
                if (c != null && c.Contrasena.Equals(contrasena))
                {
                    // Se comprueba que la solicitud de la propuesta existe.
                    Solicitud s = Solicitud.Obtener(propuesta.IdSolicitud);
                    if (s != null)
                    {
                        // Se comprueba que la solicitud de la propuesta corresponde al usuario.
                        if (s.IdCliente == c.Id)
                        {
                            Propuesta p = Propuesta.Obtener(propuesta.Id);
                            if (p != null)
                            {
                                if (!p.Confirmada)
                                {
                                    if (p.MarcarConfirmada())
                                    {
                                        // Enviar correo
                                        Correo correo = new Correo( "smtp.gmail.com",
                                                                    587,
                                                                    true, // Usar SSL
                                                                    "criludage@gmail.com",
                                                                    "123456criludage"
                                                                    );

                                        Desguace desguace = Desguace.Obtener(p.IdDesguace);
                                        Cliente cliente = Cliente.Obtener( Solicitud.Obtener( p.IdSolicitud ).IdCliente);

                                        string cuerpo =   "<h1>Confirmación de compra de la propuesta " + propuesta.Id + "</h1>" +
                                                          "<ul>" +
                                                              "<li><strong>Descripcion:</strong> " + propuesta.Descripcion + "</li>" +
                                                              "<li><strong>Precio:</strong> " + propuesta.Precio + "</li>" +
                                                              "<li><strong>Estado:</strong> " + propuesta.Estado.ToString() + "</li>" +
                                                              "<li><strong>Fecha de entrega:</strong> " + propuesta.FechaEntrega + "</li>" +
                                                          "</ul>" +
                                                          "<div style=\"border: 1px black solid; background-color: #CCCCCC; padding: 1em; margin: 1em; \">" +
                                                              "<h2>Información del cliente</h2>" +
                                                              "<ul>" +
                                                                  "<li><strong>Nombre:</strong> " + cliente.Nombre + "</li>" +
                                                                  "<li><strong>Dirección:</strong> " + cliente.Direccion + "</li>" +
                                                                  "<li><strong>Teléfono:</strong> " + cliente.Telefono + "</li>" +
                                                                  "<li><strong>Informaciçon adicional:</strong> " + cliente.InformacionAdicional + "</li>" +
                                                              "</ul>" +
                                                          "</div>";
                                                

                                        correo.enviar("criludage@gmail.com", "Criludage", desguace.CorreoElectronico, "Confirmación de la propuesta nº " + propuesta.Id, cuerpo);

                                        resultado = true;
                                        Registro.WriteLine("propuesta", usuario, "ConfirmarPropuesta: Confirmada la propuesta " + propuesta.Id);
                                    }
                                    else
                                    {
                                        Registro.WriteLine("propuesta", usuario, "ConfirmarPropuesta: Error al guardar la propuesta " + propuesta.Id + " en la base de datos");
                                    }
                                }
                                else
                                {
                                    Registro.WriteLine("propuesta", usuario, "ConfirmarPropuesta: Error al confirmar la propuesta " + propuesta.Id + ", porque ya está confirmada");
                                }
                            }
                            else
                            {
                                Registro.WriteLine("propuesta", usuario, "ConfirmarPropuesta: Error al obtener la propuesta " + propuesta.Id);
                            }
                        }
                        else
                        {
                            Registro.WriteLine("propuesta", usuario, "ConfirmarPropuesta: Error porque la solicitud " + propuesta.IdSolicitud + " no pertenece al usuario (" + usuario + ")");
                        }
                    }
                    else
                    {
                        Registro.WriteLine("propuesta", usuario, "ConfirmarPropuesta: Error al obtener la solicitud " + propuesta.IdSolicitud);
                    }
                }
                else
                {
                    Registro.WriteLine("propuesta", usuario, "ConfirmarPropuesta: Fallo autentificación (" + usuario + ")");
                }
            }
            catch (Exception e)
            {
                Registro.WriteLine("propuesta", usuario, e.Message);
                Registro.WriteLine("propuesta", usuario, e.StackTrace);
            }

            return resultado;
        }
    }
}
