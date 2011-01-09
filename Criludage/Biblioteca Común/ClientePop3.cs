using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Biblioteca_Común
{
    public class ClientePop3
    {
        private OpenPop.Pop3.Pop3Client cliente;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="servidor">Servidor POP al que conectarse.</param>
        /// <param name="puerto">Puerto por el que escucha el servidor.</param>
        /// <param name="activarSsl">Indica si se activa SSL.</param>
        /// <param name="usuario">Usuario para identificación.</param>
        /// <param name="contraseña">Contraseña para la identificación.</param>
        public ClientePop3(String servidor, int puerto, bool activarSsl, String usuario, String contraseña)
        {
            cliente = new OpenPop.Pop3.Pop3Client();

            // Conexión
			cliente.Connect(servidor, puerto, activarSsl);

			// Autenticacion
			cliente.Authenticate(usuario, contraseña);
        }

        /// <summary>
        /// Devuelve el asunto y fecha de los correos recibidos a partir de una fecha.
        /// </summary>
        /// <param name="fecha">Fecha a partir de la cual se leen los correos.</param>
        /// <returns>Lista donde cada posicion contiene un asunto y una fecha pertenecientes a un correo.</returns>
        public ArrayList ObtenerMensajesDesde(DateTime fecha)
        {
            ArrayList mensajes = new ArrayList();

            int n = cliente.GetMessageCount();
            bool buscar = true;

            // El bucle se recorre desde n hasta 1 y mientras no se pase de fecha.
            while (buscar && n > 0)
            {
                OpenPop.Mime.Header.MessageHeader m = cliente.GetMessageHeaders(n);

                DateTime fechaMensaje = DateTime.Parse(m.Date);
                if (fechaMensaje > fecha)
                {
                    ArrayList mensaje = new ArrayList(); // Array local
                    mensaje.Add(fechaMensaje);
                    mensaje.Add(m.Subject);

                    mensajes.Add(mensaje); // Array global
                }
                else
                {
                    buscar = false;
                }

                n--;
            }

            // Se crea el array a devolver
            return mensajes;
        }
    }
}
