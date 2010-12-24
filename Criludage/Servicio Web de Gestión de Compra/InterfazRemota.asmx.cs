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
        /// <summary>
        /// Una nueva solicitud que se va a distribuir a los desguaces.
        /// </summary>
        /// <param name="solicitud">Solicitud de la pieza.</param>
        /// <param name="usuario">Nombre del usuario.</param>
        /// <param name="contrasena">Contraseña del usuario.</param>
        /// <returns>Devuelve el resultado de la operación.</returns>
        [WebMethod]
        public bool solicitarPieza(Solicitud solicitud, string usuario, string contrasena)
        {
            // TODO
            // Comprueba que el usuario es correcto y tiene acceso a esta operación.
            // Comprueba que la solicitud es válida.
            // Añade la solicitud a la base de datos del servicio.
            // Encola la solicitud en el topic.
            // Devuelve verdadero (aunque dijimos que no sería simplemente un booleano, sino algo más elaborado).
            return false;
        }

        /// <summary>
        /// Se propone una nueva pieza para una solicitud determinada.
        /// </summary>
        /// <param name="propuesta">Propuesta que se va a añadir.</param>
        /// <param name="solicitud">Solicitud a la que se va a añadir la propuesta.</param>
        /// <param name="usuario">Nombre del usuario.</param>
        /// <param name="contrasena">Contraseña del usuario.</param>
        /// <returns>Devuelve el resultado de la operación.</returns>
        [WebMethod]
        public bool proponerPieza(Propuesta propuesta, Solicitud solicitud, string usuario, string contrasena)
        {
            // TODO
            // Comprueba que el usuario es correcto y tiene acceso a esta operación.
            // Comprueba que la solicitud existe y la propuesta es válida.
            // Añade la propuesta a la lista de propuestas de la solicitud.
            // Devuelve verdadero (aunque dijimos que no sería simplemente un booleano, sino algo más elaborado).
            return false;
        }
    }
}
