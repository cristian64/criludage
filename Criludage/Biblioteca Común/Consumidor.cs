using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace Biblioteca_Común
{
    public class Consumidor
    {
        ConnectionFactory connectionFactory;
        IConnection connection;
        ISession session;
        IDestination destination;
        IMessageConsumer consumer;

        /// <summary>
        /// Crea un consumidor que recibe mensajes desde una cola o un topic indistintamente.
        /// </summary>
        /// <param name="uri">Ruta al servicio de mensajería. Por ejemplo: tcp://localhost:61616</param>
        /// <param name="destino">Nombre de la cola o del topic.</param>
        /// <rereturns>Devuelve verdadero si la conexión se realizó correctamente.</rereturns>
        public bool Conectar(string uri, string destino)
        {
            bool correcto = true;
            try
            {
                connectionFactory = new ConnectionFactory(uri);
                connection = connectionFactory.CreateConnection();
                connection.Start();
                session = connection.CreateSession();
                destination = session.GetTopic(destino);
                consumer = session.CreateConsumer(destination);
            }
            catch (Exception e)
            {
                correcto = false;
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
            }
            return correcto;
        }

        /// <summary>
        /// Recibe un mensaje.
        /// Comprueba si hay mensajes pendientes, pero no se bloquea. Si no hay ningún mensaje en ese momento, devuelve null.
        /// </summary>
        /// <returns>Devuelve el mensaje en XML. Devuelve null si no ha llegado un mensaje en el tiempo indicado.</returns>
        public String Recibir()
        {
            try
            {
                ITextMessage message = (ITextMessage) consumer.Receive(new TimeSpan(0));
                if (message != null)
                {
                    return message.Text;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
            }
            return null;
        }

        /// <summary>
        /// Finaliza la sesión y la conexión con el servicio de mensajería.
        /// </summary>
        /// <returns>Devuelve verdadero si se realizó la desconexión correctamente.</returns>
        public bool Desconectar()
        {
            bool correcto = true;
            try
            {
                session.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                correcto = false;
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
            }
            return correcto;
        }
    }
}
