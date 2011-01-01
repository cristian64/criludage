using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;

namespace Servicio_Web_de_Gestión_de_Compra
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
        private static Productor productor = null;
        private static Productor GetProductor()
        {
            if (productor == null)
            {
                try
                {
                    productor = new Productor("tcp://localhost:61616", "pollaca");
                }
                catch (Exception e)
                {
                    DebugCutre.WriteLine(e.Message);
                }
            }
            return productor;
        }

        /// <summary>
        /// Una nueva solicitud que se va a distribuir a los desguaces.
        /// </summary>
        /// <param name="solicitud">Solicitud de la pieza.</param>
        /// <returns>Devuelve el resultado de la operación.</returns>
        [WebMethod]
        public bool solicitarPieza(ENSolicitud solicitud)
        {
            // TODO
            // Comprueba que el usuario es correcto y tiene acceso a esta operación.
            // Comprueba que la solicitud es válida.
            // Añade la solicitud a la base de datos del servicio.
            // Encola la solicitud en el topic.
            // Devuelve verdadero (aunque dijimos que no sería simplemente un booleano, sino algo más elaborado).

            DebugCutre.WriteLine("Enviando pieza al topic...");
            GetProductor().Enviar(solicitud);
            DebugCutre.WriteLine("Enviada la pieza al topic.");

            return true;
        }

        /// <summary>
        /// Se propone una nueva pieza para una solicitud determinada.
        /// </summary>
        /// <param name="propuesta">Propuesta que se va a añadir.</param>
        /// <returns>Devuelve el resultado de la operación.</returns>
        [WebMethod]
        public bool proponerPieza(ENPropuesta propuesta)
        {
            // TODO
            // Comprueba que el usuario es correcto y tiene acceso a esta operación.
            // Comprueba que la solicitud existe y la propuesta es válida.
            // Añade la propuesta a la lista de propuestas de la solicitud.
            // Devuelve verdadero (aunque dijimos que no sería simplemente un booleano, sino algo más elaborado).
            return false;
        }

        /// <summary>
        /// Obtiene un cliente (taller o particular) a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Devuelve un objeto ENCliente con todos su atributos. Si no existe, devuelve null.</returns>
        [WebMethod]
        public ENCliente ObtenerCliente(int id)
        {
            return new ENCliente(); //TODO hay que acceder a la BD global y obtener el cliente
        }

        /// <summary>
        /// Obtiene un desguace a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del desguace.</param>
        /// <returns>Devuelve un objeto ENDesguace con todos sus atributos. Si no existe, devuelve null.</returns>
        [WebMethod]
        public ENDesguace ObtenerDesguace(int id)
        {
            return new ENDesguace(); //TODO hay que acceder a la BD global y obtener el desguace
        }
    }
}
