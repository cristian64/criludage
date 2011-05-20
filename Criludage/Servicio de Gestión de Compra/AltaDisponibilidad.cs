using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Configuration;
using System.Collections;

namespace Servicio_de_Gestión_de_Compra
{
    public class AltaDisponibilidad
    {
        private static IPAddress ip;
        private static int puerto;
        private static Boolean soyMaestro;
        private static DateTime soyMaestroDesde;
        private static DateTime ultimaNotificacionMaestro;
        private static ArrayList hilos;
        private static Dictionary<String, DateTime> candidatos;

        /// <summary>
        /// Procesa los mensajes que se emiten por la red.
        /// </summary>
        private static void procesarMensajes()
        {
            UdpClient listener = new UdpClient(puerto);
            IPEndPoint emisor = new IPEndPoint(IPAddress.Any, puerto);
            try
            {
                while (true)
                {
                    String mensaje = Encoding.ASCII.GetString(listener.Receive(ref emisor));
                    String[] palabras = mensaje.Split(' ');

                    DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] Recibo mensaje <" + mensaje + ">");

                    // Procesamos el mensaje según el tipo que sea.
                    if (palabras[0].Equals("maestro"))
                    {
                        if (!soyMaestro)
                        {
                            // Si no soy maestro, actualizo la última fecha en la que vi al maestro vivo.
                            ultimaNotificacionMaestro = DateTime.Now;
                        }
                        else
                        {
                            // Si yo era el maestro y alguien dice que es el maestro, significa que uno ha chafado al otro.
                            // El que se haya establecido más tarde es el que quedará vivo (porque ha chafado la publicación del otro en JUDDI).
                            // Si, por casualidad, ambos nodos se hubieran establecido como maestro exactamente al mismo tiempo, ambos dejan de ser maestros
                            // y se reinicia el mecanismo de elección (por eso es <= y no <).
                            if (DateTime.Compare(DateTime.Parse(soyMaestroDesde.ToString()), DateTime.Parse(palabras[1] + " " + palabras[2])) <= 0 && !emisor.Address.ToString().Equals(ip.ToString()))
                            {
                                soyMaestro = false;
                                ultimaNotificacionMaestro = DateTime.Now;
                                DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] Dejo de ser el maestro porque hay conflicto con otro maestro y este otro nodo tiene prioridad.");
                            }
                        }
                    }
                    else if (palabras[0].Equals("candidato"))
                    {
                        candidatos.Add(emisor.Address.ToString(), DateTime.Now);
                        DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] El nodo " + emisor.Address.ToString() + " quiere ser maestro.");
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                listener.Close();
            }
        }

        /// <summary>
        /// Difunde un mensaje indicado que es el nodo maestro y que está vivo.
        /// Se invoca en un hilo cada 3 segundos.
        /// </summary>
        private static void anunciarSoyMaestro()
        {
            while (true)
            {
                if (soyMaestro)
                {
                    DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] Anuncio que soy el maestro desde " + soyMaestroDesde);
                    String mensaje = "maestro " + soyMaestroDesde;
                    Biblioteca_Común.Red.EnviarBroadcast(puerto, mensaje);
                }
                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// Comprueba que el nodo maestro esté vivo. Si no lo está, compite con el resto de nodos para ser el nodo maestro.
        /// Esta comprobación se realiza cada segundo, pero no hace nada si el maestro sigue vivo.
        /// </summary>
        private static void comprobarHayMaestro()
        {
            while (true)
            {
                if (!soyMaestro)
                {
                    // Comprobamos que el maestro haya avisado en los últimos segundos.
                    // Si no hay maestro, tenemos que intentar ser nosotros.
                    if (ultimaNotificacionMaestro.AddSeconds(10) < DateTime.Now)
                    {
                        DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] Se ha agotado el tiempo de espera al maestro; se inicia el mecanismo de elección.");

                        // Enviamos un mensaje avisando a todos de que quiero ser el nuevo maestro.
                        DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] Indico que quiero ser el maestro.");
                        String mensaje = "candidato";
                        Biblioteca_Común.Red.EnviarBroadcast(puerto, mensaje);                        

                        // Se esperan unos segundos para que todos intenten ser maestros también.
                        Thread.Sleep(10000);

                        // Entre todos los candidatos que hayan avisado en los últimos 10 segundos, comprobamos cuál tiene mayor prioridad.
                        // El más prioritario viene indicado por la dirección IP.
                        String elegido = ip.ToString();
                        foreach (KeyValuePair<String, DateTime> par in candidatos)
                        {
                            if (par.Value > DateTime.Now.AddSeconds(-15) && par.Key.CompareTo(elegido) > 0)
                                elegido = par.Key;
                        }
                        candidatos.Clear();

                        DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] El elegido entre los candidatos ha sido " + elegido);

                        // Si somos el más prioritario, nos establecemos como nodo maestro.
                        if (elegido == ip.ToString())
                        {
                            // Antes de establecernos finalmente como maestro, comprobamos si el maestro ha arrancado durante todo este proceso.
                            // Si todavía no hay maestro, nos convertimos en el maestro definitivo.
                            if (ultimaNotificacionMaestro.AddSeconds(10) < DateTime.Now)
                            {
                                establecerMaestro();
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Establece esta máquina como nodo maestro y publica en JUDDI la ruta de esta máquina.
        /// </summary>
        private static void establecerMaestro()
        {
            String publicacion = ConfigurationManager.ConnectionStrings["publicacion"].ConnectionString.Replace("$ip", ip.ToString());

            Biblioteca_Común.Publish publicador = new Biblioteca_Común.Publish(ConfigurationManager.ConnectionStrings["juddi"].ConnectionString);
            if (publicador.PublicarServicio("Criludage", "Servicio Criludage", publicacion))
            {
                soyMaestro = true;
                soyMaestroDesde = DateTime.Now;
                DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] Registrado el servicio en UDDI (" + ConfigurationManager.ConnectionStrings["juddi"].ConnectionString + "): " + publicacion);
            }
            else
            {
                DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] Fallo al registrar el servicio en UDDI (" + ConfigurationManager.ConnectionStrings["juddi"].ConnectionString + "): " + publicacion);
            }
        }

        /// <summary>
        /// Indica si este nodo es el nodo maestro actualmente.
        /// </summary>
        /// <returns>Verdadero si es el nodo maestro.</returns>
        public static Boolean SoyMaestro()
        {
            return soyMaestro;
        }

        /// <summary>
        /// Inicia el algoritmo de alta disponibilidad.
        /// </summary>
        public static void Iniciar()
        {
            if (hilos == null)
            {
                // Se inicializan las variables.
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(addr => addr.AddressFamily.Equals(AddressFamily.InterNetwork));
                puerto = int.Parse(ConfigurationManager.ConnectionStrings["puerto"].ConnectionString);
                soyMaestro = false;
                ultimaNotificacionMaestro = DateTime.Now;
                candidatos = new Dictionary<String, DateTime>();
                hilos = new ArrayList();

                DebugCutre.WriteLine("[ALTA DISPONIBILIDAD] Inicio del algoritmo en puerto " + puerto + " (" + ip + ").");

                // Arrancamos los hilos.
                Thread hilo = new Thread(procesarMensajes);
                hilo.Start();
                hilos.Add(hilo);
                hilo = new Thread(anunciarSoyMaestro);
                hilo.Start();
                hilos.Add(hilo);
                hilo = new Thread(comprobarHayMaestro);
                hilo.Start();
                hilos.Add(hilo);
            }
        }

        /// <summary>
        /// Detiene el algoritmo de alta disponibilidad.
        /// </summary>
        public static void Detener()
        {
            if (hilos != null)
            {
                // Abortamos todos los hilos.
                foreach (Thread i in hilos)
                    i.Abort();

                // Reiniciamos las variables a un valor por defecto.
                soyMaestro = false;
                ultimaNotificacionMaestro = DateTime.Now;
                candidatos = null;
                hilos = null;
            }
        }
    }
}
