using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;

namespace Servicio_de_Gestión_de_Compra
{
    public class DemonioCutre
    {
        private static Thread demonio = null;
        private static void realizarAcciones()
        {
            try
            {
                while (true)
                {
                    DebugCutre.WriteLine("hilo en funcionamiento");
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Remite una solicitud al cliente cno las propuestas.
        /// </summary>
        /// <param name="solicitud">Solicitud a remitir</param>
        private static void remitirSolicitud(ENSolicitud solicitud)
        {

            // Datos para el servidor de correo
            // TODO Meterlos en el app.config
            Correo correo = new Correo("smtp.gmail.com",
                                        587,
                                        true, // Usar SSL
                                        "criludage@gmail.com",
                                        "123456criludage"
                                        );

            // Datos del contenido del correo
            if (correo.enviar("criludage@gmail.com", "Criludage Corp.", "receptor@yopmail.com", "Buenos dias", "Pues eso"))
                System.Console.WriteLine("Correo OK!");
        }

        /// <summary>
        /// Crea un hilo y arranca el bucle que se ejecuta indefinidamente.
        /// </summary>
        public static void Iniciar()
        {
            if (demonio == null)
            {
                demonio = new Thread(realizarAcciones);
                demonio.Start();
            }
        }

        public static void Detener()
        {
            if (demonio != null)
            {
                demonio.Abort();
                demonio = null;
            }
        }
    }
}