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
        /// Devuelve los correos recibidos después de uno concreto.
        /// </summary>
        /// <param name="ultimoUid">UID del correo que sirve de tope.</param>
        /// <returns>Lista con emisor, uid y asunto de los correos</returns>
        public ArrayList ObtenerMensajesDesde(String ultimoUid)
        {
            ArrayList mensajes = new ArrayList();

            int n = cliente.GetMessageCount();

            if (ultimoUid.Equals(""))
            {
                // Se devuelve solo el ultimo
                OpenPop.Mime.Header.MessageHeader m = cliente.GetMessageHeaders(n);

                ArrayList mensaje = new ArrayList(); // Array local
                mensaje.Add(m.From);
                mensaje.Add(cliente.GetMessageUid(n));
                mensaje.Add(m.Subject);

                mensajes.Add(mensaje); // Array global
            }
            else
            {
                bool buscar = true;

                // El bucle se recorre desde n hasta 1 y mientras no se llegue al UID
                while (buscar && n > 0)
                {
                    String uid = cliente.GetMessageUid(n);
                    if (!uid.Equals(ultimoUid))
                    {
                        OpenPop.Mime.Header.MessageHeader m = cliente.GetMessageHeaders(n);

                        ArrayList mensaje = new ArrayList(); // Array local
                        mensaje.Add(m.From);
                        mensaje.Add(uid);
                        mensaje.Add(m.Subject);

                        mensajes.Add(mensaje); // Array global
                    }
                    else
                    {
                        buscar = false;
                    }

                    n--;
                }
            }

            // Se crea el array a devolver
            return mensajes;
        }
    }
}
