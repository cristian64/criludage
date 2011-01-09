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
    }
}
