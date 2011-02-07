/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * FormPrimeraVez.java
 *
 * Created on 23-ene-2011, 17:27:43
 */
package aplicaciondesguace;

import java.awt.CardLayout;
import java.io.IOException;
import java.net.URL;
import java.security.NoSuchAlgorithmException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.activemq.command.ActiveMQTopic;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class FormPrimeraVez extends javax.swing.JFrame {

    // el formulario primera vez se crea con un argumento de configuracion
    public FormPrimeraVez(Configuracion config) {

        initComponents();

        // guardo la configuracion
        configuracion = config;

        // inicializo variables
        empleadoOK=false;
        desguaceOK=false;
        paso = 1;
        botonAnterior.setEnabled(false);

        // anyado todos los paneles
        panelPrincipal.add(new PanelPrimeraVezBienvenida(), "1");
        panelPrincipal.add(new PanelPrimeraVezServicios(configuracion.getActiveMQ(),configuracion.getWebService()), "2");
        panelPrincipal.add(new PanelPrimeraVezRegistro(), "3");
        panelPrincipal.add(new PanelPrimeraVezEmpleado(), "4");
        panelPrincipal.add(new PanelPrimeraVezEnviar(), "5");

        // lo muestro
        setVisible(true);

    }

    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        panelPrincipal = new javax.swing.JPanel();
        botonSiguiente = new javax.swing.JButton();
        etiquetaConfiguracion = new javax.swing.JLabel();
        botonCancelar = new javax.swing.JButton();
        botonAnterior = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setResizable(false);

        panelPrincipal.setMaximumSize(new java.awt.Dimension(500, 300));
        panelPrincipal.setLayout(new java.awt.CardLayout());

        botonSiguiente.setText("Siguiente");
        botonSiguiente.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                botonSiguienteActionPerformed(evt);
            }
        });

        etiquetaConfiguracion.setFont(new java.awt.Font("Tahoma", 1, 14)); // NOI18N
        etiquetaConfiguracion.setText("Asistente de configuración");

        botonCancelar.setText("Cancelar");
        botonCancelar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                botonCancelarActionPerformed(evt);
            }
        });

        botonAnterior.setText("Anterior");
        botonAnterior.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                botonAnteriorActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(panelPrincipal, javax.swing.GroupLayout.DEFAULT_SIZE, 545, Short.MAX_VALUE)
                    .addComponent(etiquetaConfiguracion, javax.swing.GroupLayout.DEFAULT_SIZE, 545, Short.MAX_VALUE)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(botonAnterior)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 316, Short.MAX_VALUE)
                        .addComponent(botonCancelar)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(botonSiguiente)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(etiquetaConfiguracion, javax.swing.GroupLayout.PREFERRED_SIZE, 28, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(panelPrincipal, javax.swing.GroupLayout.PREFERRED_SIZE, 232, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(botonSiguiente)
                    .addComponent(botonCancelar)
                    .addComponent(botonAnterior))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void botonSiguienteActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_botonSiguienteActionPerformed

        // inicializo variables
        boolean error = false;
        //si estoy en el paso 2
        if (paso == 2) {

            // obtengo el panel 2
            PanelPrimeraVezServicios p = (PanelPrimeraVezServicios) panelPrincipal.getComponent(1);

            // comprobar ActiveMQ
            try {
                // comienzo la conexion
                ConnectionFactory connectionFactory = new ActiveMQConnectionFactory(p.getActiveMQ());
                Connection connection = connectionFactory.createConnection();
                connection.start();
                // conexion establecida
                System.out.println("ActiveMQ OK");
                // la guardo en configuraciond
                configuracion.setActiveMQ(p.getActiveMQ());
                // cierro la conexion
                connection.close();

            } catch (JMSException e) {
                // si hay algun problema emito el error
                JOptionPane.showMessageDialog(rootPane, "El servidor ActiveMQ no se ha encontrado", "Error ActiveMQ", JOptionPane.ERROR_MESSAGE);
                error = true;
            }

            // comprobamos el Servicio Web
            try {
                //obtengo la url introducida
                URL url = new URL(p.getWS());
                url.getContent();
                // creo la variable de la Intefaz remota
                org.tempuri.InterfazRemota ir = null;
                // la obtengo a partir de la url
                ir = new org.tempuri.InterfazRemota(url);
                // accedo a la interfaz
                soap = ir.getInterfazRemotaSoap();
                // la inicializo
                soap.inicializar();
                // conexion establecida
                System.out.println("Servicio Web OK");
                // guardo la url en configuracion
                configuracion.setWebService(p.getWS());

            } catch (IOException e) {
                // si hay algun problema emito el error
                JOptionPane.showMessageDialog(rootPane, "El Servicio Web no se ha encontrado", "Error Servicio Web", JOptionPane.ERROR_MESSAGE);
                error = true;
            }

        }
        // si estoy en el paso 3
        if (paso == 3) {
            // obtengo el panel
            PanelPrimeraVezRegistro p = (PanelPrimeraVezRegistro) panelPrincipal.getComponent(2);
            // si el nombre introducido tiene el tamanyo minimo
            if (p.getNombre().length() >= 3) {
                // si se ha introducido una contrasenya
                if (p.getPassword1().length() > 0) {
                    // si son iguales las contrasenyas
                    if (p.getPassword2().equals(p.getPassword1())) {
                        // creo una expresion regular que reconoce correos electronicos
                        Pattern pa = Pattern.compile("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
                        Matcher m = pa.matcher(p.getCorreo());
                        // si coincide
                        if (m.find()) {
                            // creo el desguace
                            desguace = new Desguace();
                            // asigno los datos
                            desguace.setUsuario(p.getNombre());
                            try{
                                SHA1 sha = new SHA1();
                                desguace.setContrasena(sha.getHash(p.getPassword1()));
                            }
                            catch(NoSuchAlgorithmException ex){

                            }
                            desguace.setCorreoElectronico(p.getCorreo());
                        }
                        else {
                            // emito error
                            JOptionPane.showMessageDialog(rootPane, "Debes introducir un e-mail correcto", "e-mail incorrecto", JOptionPane.ERROR_MESSAGE);
                            error = true;
                        }
                    }
                    else {
                        // emito error
                        JOptionPane.showMessageDialog(rootPane, "Las contraseñas deben coincidir", "Contraseña invalida", JOptionPane.ERROR_MESSAGE);
                        error = true;
                    }
                }
                else {
                    // emito error
                    JOptionPane.showMessageDialog(rootPane, "Debes introducir una contraseña", "Contraseña invalida", JOptionPane.ERROR_MESSAGE);
                    error = true;
                }
            }
            else {
                // emito error
                JOptionPane.showMessageDialog(rootPane, "El nombre debe contener al menos 3 caracteres", "Nombre invalido", JOptionPane.ERROR_MESSAGE);
                error = true;
            }
            

        }

        // si estoy en el paso 4
        if (paso == 4) {
            // obtengo el panel actual
            PanelPrimeraVezEmpleado p = (PanelPrimeraVezEmpleado) panelPrincipal.getComponent(3);
            // si el nombre tiene el tamanyo minimo
            if (p.getNombre().length() >= 3) {
                // si ha introducido una contrasenya
                if (p.getPassword1().length() > 0) {
                    // si coinciden las contrasenyas
                    if (p.getPassword2().equals(p.getPassword1())) {
                        // creo un empleado
                        empleado = new Empleado();
                        // asingo los datos
                        empleado.setUsuario(p.getNombre());
                        empleado.setContrasena(p.getPassword1());
                        try{
                            SHA1 sha = new SHA1();
                            empleado.setContrasena(sha.getHash(p.getPassword1()));
                        }
                        catch(NoSuchAlgorithmException ex){

                        }
                        empleado.setAdministrador(p.getAdministrador());
                        

                    }
                    else {
                        // emito error
                        JOptionPane.showMessageDialog(rootPane, "Las contraseñas deben coincidir", "Contraseña invalida", JOptionPane.ERROR_MESSAGE);
                        error = true;
                    }
                }
                else {
                    // emito error
                    JOptionPane.showMessageDialog(rootPane, "Debes introducir una contraseña", "Contraseña invalida", JOptionPane.ERROR_MESSAGE);
                    error = true;
                }
            }
            else {
                // emito error
                JOptionPane.showMessageDialog(rootPane, "El nombre debe contener al menos 3 caracteres", "Nombre invalido", JOptionPane.ERROR_MESSAGE);
                error = true;
            }


        }

        // si estoy en el paso 5
        if (paso == 5) {

            // hay que comprobar todo para terminar la configuracion

            // si el desguace no ha sido registrado aun
            if(!desguaceOK){
                //lo registro
                desguace.setId(soap.registroDesguace(desguace));
                // en funcion del valor de la id de respuesta
                int id = desguace.getId();
                // si es mayor que 0
                if (id >= 0) {
                    // todo correcto
                    desguaceOK=true;
                } else {
                    // si la id es -1
                    if (id == -1) {
                        // muestro el error de que el usuario ya existe
                        JOptionPane.showMessageDialog(rootPane, "El usuario ya existe", "Usuario", JOptionPane.ERROR_MESSAGE);
                        // muestro el panel de registro
                        ((CardLayout) panelPrincipal.getLayout()).show(panelPrincipal, "3");
                        // restauro el estado al paso 3
                        paso = 3;
                        botonAnterior.setEnabled(true);
                        botonSiguiente.setEnabled(true);
                        botonSiguiente.setText("Siguiente");
                        error=true;
                    } else {
                        // si es otro valor el error es desconocido
                        JOptionPane.showMessageDialog(rootPane, "Error desconocido", "Error desconcocido", JOptionPane.ERROR_MESSAGE);
                        ((CardLayout) panelPrincipal.getLayout()).show(panelPrincipal, "3");
                        paso = 3;
                        botonAnterior.setEnabled(true);
                        botonSiguiente.setEnabled(true);
                        botonSiguiente.setText("Siguiente");
                        error=true;
                    }
                }
            }
            // si no hay errores ni se ha registrado al empleado
            if(!error &&!empleadoOK){
                // guardo el empleado
                if(empleado.guardar()){
                    empleadoOK=true;
                }
                else{
                    // si hay errores es porque el usuario ya existe
                    JOptionPane.showMessageDialog(rootPane, "El usuario ya existe ", "Error", JOptionPane.ERROR_MESSAGE);
                    ((CardLayout) panelPrincipal.getLayout()).show(panelPrincipal, "4");
                    paso = 4;
                    botonAnterior.setEnabled(true);
                    botonSiguiente.setEnabled(true);
                    botonSiguiente.setText("Siguiente");
                    error=true;
                }
            }
            // finalmente no hay errores
            if(!error){
                // guardo los datos en la configuracion
                configuracion.setIdDesguace(desguace.getId());
                configuracion.setUsuarioDesguace(desguace.getUsuario());
                configuracion.setPasswordDesguace(desguace.getContrasena());
                // la guardo
                configuracion.guardarConfiguracion("conf.xml");

                // abro la aplicacion
                FormBase fb = new FormBase(desguace,empleado);
                fb.setVisible(true);
                this.setVisible(false);

                // y creo el consumidor ActiveMQ
                try{

                    // comienzo la conexion
                    ConnectionFactory connectionFactory = new ActiveMQConnectionFactory(configuracion.getActiveMQ());
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
                                System.out.println(textMessage.getText());

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
        }
        // si no estoy en ninguno de esos pasos
        if (!error) {
            // si el paso es menor que 5 (el ultimo)
            if (paso < 5) {
                // paso adelante
                paso++;
                // cambio el formulario
                ((CardLayout) panelPrincipal.getLayout()).next(panelPrincipal);
            }
            // si el paso no es 1
            if (paso > 1) {
                // el boton anterior esta activo
                botonAnterior.setEnabled(true);
            }
            // si es el ultimo paso, el boton muestra Enviar
            if (paso == 5) {
                botonSiguiente.setText("Enviar");
            }
        }

    }//GEN-LAST:event_botonSiguienteActionPerformed



    private void botonCancelarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_botonCancelarActionPerformed

        System.exit(0);

    }//GEN-LAST:event_botonCancelarActionPerformed

    private void botonAnteriorActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_botonAnteriorActionPerformed
        if (paso > 1) {
            paso--;
            ((CardLayout) panelPrincipal.getLayout()).previous(panelPrincipal);
        }
        if (paso == 4) {
            botonSiguiente.setText("Siguiente");
        }
        if (paso == 1) {
            botonAnterior.setEnabled(false);
        }
    }//GEN-LAST:event_botonAnteriorActionPerformed
    private JPanel principal;
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton botonAnterior;
    private javax.swing.JButton botonCancelar;
    private javax.swing.JButton botonSiguiente;
    private javax.swing.JLabel etiquetaConfiguracion;
    private javax.swing.JPanel panelPrincipal;
    // End of variables declaration//GEN-END:variables
    private int paso = 1;
    org.tempuri.InterfazRemotaSoap soap;
    Desguace desguace;
    Empleado empleado;
    boolean empleadoOK,desguaceOK;
    Configuracion configuracion;
}
