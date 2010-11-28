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

        Func<Object, Object> metodo;

        /// <summary>
        /// Crea un consumidor que recibe mensajes desde una cola o un topic indistintamente.
        /// Cuando se recibe un mensaje se convierte a objeto y se ejecuta el método que recibe ese objeto.
        /// </summary>
        /// <param name="uri">Ruta al servicio de mensajería. Por ejemplo: tcp://localhost:61616</param>
        /// <param name="destino">Nombre de la cola o del topic.</param>
        /// <param name="metodo">Método que se ejecutará al recibir un mensaje. El método debe recibir un parámetro del tipo "object" y devolver "object".</param>
        public Consumidor(string uri, string destino, Func<Object, Object> metodo)
        {
            connectionFactory = new ConnectionFactory(uri);
            connection = connectionFactory.CreateConnection();
            connection.Start();
            session = connection.CreateSession();
            destination = session.GetTopic(destino);
            consumer = session.CreateConsumer(destination);
            consumer.Listener += new MessageListener(OnMessage);
            this.metodo = metodo;
        }

        /// <summary>
        /// Método auxiliar que procesa los mensajes que se reciben.
        /// Este método invoca el método indicado en el contructor de la clase.
        /// </summary>
        /// <param name="message">Mensaje que se ha recibido y que se va a procesar en el método.</param>
        private void OnMessage(IMessage message)
        {
            ITextMessage objectMessage = message as ITextMessage;
            metodo(objectMessage.ToObject());
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
