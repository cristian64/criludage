using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;
using System.Configuration;
using System.Threading;

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
                    productor = new Productor(ConfigurationManager.ConnectionStrings["activemq"].ConnectionString, ConfigurationManager.ConnectionStrings["topic"].ConnectionString);

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
        /// <returns>Devuelve el identificador de la solicitud. Si devuelve 0, significa que ocurrió un error.</returns>
        [WebMethod]
        public int SolicitarPieza(ENSolicitud solicitud)
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
        /// <returns>Devuelve el identificador de la propuesta. Si devuelve 0, significa que ocurrió un error.</returns>
        [WebMethod]
        public int ProponerPieza(ENPropuesta propuesta)
        {
            // TODO
            // Comprueba que el usuario es correcto y tiene acceso a esta operación.
            // Comprueba que la solicitud existe y la propuesta es válida.
            // Añade la propuesta a la lista de propuestas de la solicitud.
            // Devuelve verdadero (aunque dijimos que no sería simplemente un booleano, sino algo más elaborado).

			int id = 0;
			
            try
            {
                propuesta.Id = 0; // Condicion para que Guardar sea crear y no actualizar ¿mejorar?
                Propuesta p = new Propuesta(propuesta);
                if (p.Guardar())
                {
                    id = propuesta.Id = p.Id;
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
        /// Obtiene un cliente (taller o particular) a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Devuelve un objeto ENCliente con todos su atributos. Si no existe, devuelve null.</returns>
        [WebMethod]
        public ENCliente ObtenerCliente(int id)
        {
            Cliente cliente = Cliente.Obtener(id);

            if (cliente != null)
                return cliente.ENCliente;
            else
                return null;
        }

        /// <summary>
        /// Obtiene un desguace a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del desguace.</param>
        /// <returns>Devuelve un objeto ENDesguace con todos sus atributos. Si no existe, devuelve null.</returns>
        [WebMethod]
        public ENDesguace ObtenerDesguace(int id)
        {
            Desguace desguace = Desguace.Obtener(id);

            if (desguace != null)
                return desguace.ENDesguace;
            else
                return null;
        }
    }
}
