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
        public Consumidor(string uri, string destino)
        {
            connectionFactory = new ConnectionFactory(uri);
            connection = connectionFactory.CreateConnection();
            connection.Start();
            session = connection.CreateSession();
            destination = session.GetTopic(destino);
            consumer = session.CreateConsumer(destination);
        }

        /// <summary>
        /// Recibe un mensaje.
        /// Espera el mensaje durante un tiempo determinado. Es un método bloqueante.
        /// </summary>
        /// <param name="segundos">Intervalo de segundos que quedará bloqueado el método a la espera de un mensaje.</param>
        /// <returns>Devuelve el mensaje o null si no ha llegado un mensaje en el tiempo indicado.</returns>
        public object Recibir(int segundos)
        {
            try
            {
                ITextMessage message = (ITextMessage) consumer.Receive(new TimeSpan(0, 0, segundos));
                if (message != null)
                {
                    return message.ToObject();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Recibir(segundos)");
                System.Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// Finaliza la sesión y la conexión con el servicio de mensajería.
        /// </summary>
        ~Consumidor()
        {
            session.Close();
            connection.Close();
        }
    }
}
