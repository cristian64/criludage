/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package aplicaciondesguace;

import java.io.IOException;
import java.sql.SQLException;
import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.xml.parsers.ParserConfigurationException;
import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.activemq.command.ActiveMQTopic;
import org.xml.sax.SAXException;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException,ParserConfigurationException,SAXException, ClassNotFoundException, SQLException {

        Empleado e = new Empleado();

        // creo un objeto configuracion por defecto
        Configuracion config = new Configuracion();

        // leo el archivo de configuracion
        if(config.leerConfiguracion("conf.xml")){

        }
        else{
            // si devuelve false, creo una configuracion por defecto y la cargo
            config.guardarConfiguracion("conf.xml");
            config.leerConfiguracion("conf.xml");
        }

        // si ya existen empleados
        if(e.numEmpleados(config.getBdHost())>0){

            
             // abro el formulario de login
             FormLogin fl = new FormLogin();
             fl.setVisible(true);

             // creo el consumidor ActiveMQ
             try{

                // comienzo la conexion
                ConnectionFactory connectionFactory = new ActiveMQConnectionFactory(config.getActiveMQ());
                Connection connection = connectionFactory.createConnection();
                connection.start();

                // creo la sesion
                Session session = connection.createSession(false,Session.AUTO_ACKNOWLEDGE);

                // creo el topic
                ActiveMQTopic topic = new ActiveMQTopic("solicitudes");
                // creo el consumidor
                MessageConsumer consumer = session.createConsumer(topic);
                // comienzo a recivir mensajes
                Message message = consumer.receive();
                // mientras reciva mensajes
                while(message != null){
                        // si es un mesaje de texto
                        if (message instanceof TextMessage) {
                            // accedo al mensaje
                            TextMessage textMessage = (TextMessage) message;
                            // me quedo con su contenido
                            String xml = textMessage.getText();
                            

                            // creo la solicitud a partir del xml
                            Solicitud sol = new Solicitud(xml);
                            // la guardo en la BD
                            //sol.guardar(config.getBdHost());
                        }
                         else{
                            System.out.println("ERROR");
                         }
                        // recivo el siguiente mensaje
                        message = consumer.receive();
                }
                // cierro la conexion
                connection.close();

            }
            catch(JMSException ex){
                System.out.println(ex);
            }
        }
         else{
            // si no hay empleados abro el formulario de configuracion de primera vez
            FormPrimeraVez pv = new FormPrimeraVez(config);
            pv.setVisible(true);
        }

        

    }
    
}
