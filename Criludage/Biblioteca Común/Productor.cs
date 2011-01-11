﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace Biblioteca_Común
{
    public class Productor
    {
        ConnectionFactory connectionFactory;
        IConnection connection;
        ISession session;
        IDestination destination;
        IMessageProducer producer;

        /// <summary>
        /// Crea un productor que puede enviar mensajes a una cola o un topic indistintamente.
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
                producer = session.CreateProducer(destination);
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
        /// Envía un objeto que debe ser serializable en XML.
        /// Véase XmlSerializer.
        /// </summary>
        /// <param name="objeto">Objeto que se va a enviar. Debe ser serializable en XML.</param>
        public void Enviar(object objeto)
        {
            producer.Send(objeto);
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
