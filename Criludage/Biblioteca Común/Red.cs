using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Biblioteca_Común
{
    public class Red
    {
        /// <summary>
        /// Envía un mensaje UDP al destino indicado.
        /// </summary>
        /// <param name="direccion">Dirección a la que se envía el mensaje.</param>
        /// <param name="puerto">Puerto al que se envía el mensaje.</param>
        /// <param name="mensaje">Mensaje a enviar por la red.</param>
        /// <returns>Verdadero si el mensaje se envió correctamente. Falso si se produjo algún error.</returns>
        public static bool Enviar(String direccion, int puerto, String mensaje)
        {
            try
            {
                IPEndPoint destino = new IPEndPoint(IPAddress.Parse(direccion), puerto);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.EnableBroadcast = true;
                socket.SendTo(Encoding.ASCII.GetBytes(mensaje), destino);
                socket.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Envía un mensaje UDP por broadcast en un puerto determinado.
        /// </summary>
        /// <param name="puerto">Puerto al que se envía el mensaje.</param>
        /// <param name="mensaje">Mensaje a enviar por la red.</param>
        /// <returns>Verdadero si el mensaje se envió correctamente. Falso si se produjo algún error.</returns>
        public static bool EnviarBroadcast(int puerto, String mensaje)
        {
            try
            {
                IPEndPoint destino = new IPEndPoint(IPAddress.Broadcast, puerto);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.EnableBroadcast = true;
                socket.SendTo(Encoding.ASCII.GetBytes(mensaje), destino);
                socket.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Permanece a la escucha hasta que llega un mensaje UDP en el puerto indicado.
        /// Es un método bloqueante que sólo acaba al recibir el mensaje o al producirse un error.
        /// </summary>
        /// <param name="puerto">Número del puerto entre 0 y 65536.</param>
        /// <returns>Devuelve el mensaje recibido o una referencia nula si se produjo un error.</returns>
        public static String RecibirBloqueante(int puerto)
        {
            UdpClient listener = new UdpClient(puerto);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, puerto);

            try
            {
                byte[] bytes = listener.Receive(ref groupEP);
                return Encoding.ASCII.GetString(bytes);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
