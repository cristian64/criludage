using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;
using System.Collections;

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
                    ArrayList solicitudes = Solicitud.ObtenerExpiradas();
                    foreach (Solicitud i in solicitudes)
                    {
                        remitirSolicitud(i);
                        i.Remitida = true;
                        i.Guardar();
                    }

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
        private static void remitirSolicitud(Solicitud solicitud)
        {
            // Datos para el servidor de correo
            // TODO Meterlos en el app.config
            Correo correo = new Correo("smtp.gmail.com",
                                        587,
                                        true, // Usar SSL
                                        "criludage@gmail.com",
                                        "123456criludage"
                                        );

            ArrayList propuestas = solicitud.ObtenerPropuestas();

            // Datos del contenido del correo
            //TODO: hacer esto html simplecillo y fuera. tambien extrayendo la info de los desguaces de cada propuesta
            string cuerpo = "";
            cuerpo += solicitud.ToString() + "\n";
            cuerpo += "\n";
            cuerpo += "Se han recibido un total de " + propuestas.Count + " propuestas:\n";
            foreach (Propuesta i in propuestas)
            {
                cuerpo += propuestas.ToString();
            }

            Cliente cliente = Cliente.Obtener(solicitud.Id);
            if (cliente != null)
                correo.enviar("criludage@gmail.com", "Criludage Corp.", cliente.CorreoElectronico, "Solicitud nº " + solicitud.Id + " finalizada", cuerpo);            
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