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
        bool activa;

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
                connection.ExceptionListener += new ExceptionListener(conexionInterrumpida);
                activa = true;
            }
            catch (Exception)
            {
                correcto = false;
            }
            return correcto;
        }

        /// <summary>
        /// Método auxiliar que se invoca cuando se piede la conexión con Active MQ.
        /// Es un callback asociad a una excepción durante la comunicación.
        /// </summary>
        /// <param name="e">Exceptión que se recibe como paráemtro del callback.</param>
        private void conexionInterrumpida(Exception e)
        {
            activa = false;
        }

        /// <summary>
        /// Comprueba si la conexión con Active MQ está activa o ha caído.
        /// </summary>
        /// <returns>Verdadero si la conexión está activa.</returns>
        public bool ConexionActiva()
        {
            return activa;
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
            catch (Exception)
            {
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
                activa = false;
                session.Close();
                connection.Close();
                session = null;
                connection = null;
                connectionFactory = null;
                consumer = null;
            }
            catch (Exception)
            {
                correcto = false;
            }
            return correcto;
        }
    }
}
