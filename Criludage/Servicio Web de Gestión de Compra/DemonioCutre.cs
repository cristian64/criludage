using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

using Biblioteca_Común;

namespace Servicio_Web_de_Gestión_de_Compra
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

        private static void responderSolicitud()
        {
            // Ejemplo de enviar un correo usando el servidor de gmail

            // Datos para el servidor de correo
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