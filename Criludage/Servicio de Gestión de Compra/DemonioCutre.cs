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
                    ArrayList solicitudes = Solicitud.ObtenerFinalizadasNoRemitidas();
                    foreach (Solicitud i in solicitudes)
                    {
                        remitirSolicitud(i);
                        i.Remitida = true;
                        if (i.Guardar())
                            DebugCutre.WriteLine("Guardando remitida: " + i.Id + " " + i.Descripcion);
                        else
                            DebugCutre.WriteLine("Guardando remitida: " + i.Id + " " + i.Descripcion + " (fallo al guardar remitida)");
                    }
                    DebugCutre.WriteLine("________________________________________________________________________________________________________");
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
            string cuerpo =   "<h1>Respuesta/s a la solicitud " + solicitud.Id + "</h1>" +
                              "<ul>" +
                              "<li><strong>Descripcion:</strong> "+ solicitud.Descripcion +"</li>" +
                              "<li><strong>Fecha de realización:</strong> "+ solicitud.Fecha +"</li>" +
                              "<li><strong>Precio máximo:</strong> "+ solicitud.PrecioMax +"</li>" +
                              "<li><strong>Estado:</strong> "+ solicitud.Estado +"</li>" +
                              "<li><strong>Fecha de entrega:</strong> " + solicitud.FechaEntrega + "</li>" +
                              "<li><strong>Fecha de respuesta:</strong> " + solicitud.FechaRespuesta + "</li>" +
                              "<li><strong>¿Negociado automatico?:</strong> "+ (solicitud.NegociadoAutomatico?"Activado":"Desactivado") +"</li>" +
                              "</ul>" +
                              "<p>Se han recibido un total de " + propuestas.Count + " propuestas.</p>";

            int cont = 0;
            foreach (Propuesta i in propuestas)
            {
                cont++;

                Desguace d = i.ObtenerDesguace();

                cuerpo += "<div style=\"border: 1px black solid; background-color: #CCCCCC; padding: 1em; margin: 1em; \">" +
                          "<h2>Propuesta " + cont + "</h2>" +
                          "<ul>" +
                          "<li><strong>ID:</strong> " + i.Id + "</li>" +
                          "<li><strong>Descripcion:</strong> " + i.Descripcion + "</li>" +
                          "<li><strong>Fecha de entrega:</strong> " + i.FechaEntrega + "</li>" +
                          "<li><strong>Precio:</strong> " + i.Precio + "</li>" +
                          "<li><strong>Estado:</strong> " + i.Estado + "</li>" +
                          "</ul>" +
                          "<h3>Información del desguace:</h3>" +
                          "<ul>" +
                          "<li><strong>Nombre</strong> " + d.Nombre + "</li>" +
                          "<li><strong>NIF:</strong> " + d.Nif + "</li>" +
                          "<li><strong>Correo electrónico:</strong> " + d.CorreoElectronico + "</li>" +
                          "<li><strong>Dirección:</strong> " + d.Direccion + "</li>" +
                          "<li><strong>Telefono:</strong> " + d.Telefono + "</li>" +
                          "<li><strong>Información adicional:</strong> " + d.InformacionAdicional + "</li>" +
                          "</ul>" +
                          "</div>";
            }

            Cliente cliente = Cliente.Obtener(solicitud.IdCliente);
            try
            {
                correo.enviar("criludage@gmail.com", "Criludage", cliente.CorreoElectronico, "Solicitud nº " + solicitud.Id + " finalizada", cuerpo);
                DebugCutre.WriteLine("(gmail) Enviado correo a " + cliente.CorreoElectronico + " la solicitud " + solicitud.Id);
            }
            catch (Exception e)
            {
                DebugCutre.WriteLine("(gmail) Enviado correo mal: " + e.Message);
            }
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