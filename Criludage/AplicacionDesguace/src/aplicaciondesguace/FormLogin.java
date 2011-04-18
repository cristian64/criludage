/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * FormLogin.java
 *
 * Created on 03-feb-2011, 16:17:04
 */
package aplicaciondesguace;

import com.sun.xml.internal.ws.client.ClientTransportException;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import java.security.NoSuchAlgorithmException;
import javax.management.JMException;
import javax.swing.JOptionPane;
import javax.xml.namespace.QName;
import javax.xml.ws.Service;
import org.tempuri.ENDesguace;
import org.tempuri.InterfazRemota;
import org.tempuri.InterfazRemotaSoap;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class FormLogin extends javax.swing.JFrame {

    /** Creates new form FormLogin */
    public FormLogin() {
        initComponents();
        // creo la configuracion guardada en el fichero
        configuracion = new Configuracion();
        configuracion.leerConfiguracion("conf.xml");
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        campoUsuario = new javax.swing.JTextField();
        botonEntrar = new javax.swing.JButton();
        campoPassword = new javax.swing.JPasswordField();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Inicio de sesión - Criludage");

        jLabel1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/aplicaciondesguace/panda256.png"))); // NOI18N

        jLabel2.setFont(new java.awt.Font("Tahoma", 0, 14));
        jLabel2.setText("Introduce tu nombre de usuario y contraseña:");

        botonEntrar.setText("Entrar");
        botonEntrar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                botonEntrarActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(botonEntrar, javax.swing.GroupLayout.PREFERRED_SIZE, 124, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(41, 41, 41)
                        .addComponent(jLabel1))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jLabel2, javax.swing.GroupLayout.DEFAULT_SIZE, 332, Short.MAX_VALUE))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(campoUsuario, javax.swing.GroupLayout.DEFAULT_SIZE, 332, Short.MAX_VALUE))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(campoPassword, javax.swing.GroupLayout.DEFAULT_SIZE, 332, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1)
                .addGap(18, 18, 18)
                .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 26, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(campoUsuario, javax.swing.GroupLayout.PREFERRED_SIZE, 32, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(campoPassword, javax.swing.GroupLayout.PREFERRED_SIZE, 32, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(botonEntrar, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void botonEntrarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_botonEntrarActionPerformed


        Empleado e = new Empleado();

        // obtengo el usuario de la BD con el nombre introducido
        e = e.getEmpleadoPorUsuario(configuracion.getBdHost(),campoUsuario.getText());

        try{

            // creo el servicio
            org.tempuri.InterfazRemotaSoap soap;

            // creo la variable de la Intefaz remota
            org.tempuri.InterfazRemota ir = null;

            URL wsdl = new URL(configuracion.getWebService());
            QName name = new QName("http://tempuri.org/","InterfazRemota");

            // la obtengo a partir de la url
            ir = new org.tempuri.InterfazRemota(wsdl, name);

            // obtengo la interfaz soap
            soap = ir.getInterfazRemotaSoap();

            System.out.println(ir.getWSDLDocumentLocation());

            // la inicializo
            soap.inicializar();

            // croe un ENDesguace a partir de la configuracion guardada
            
            ENDesguace aux =((InterfazRemotaSoap)soap).obtenerDesguace(configuracion.getIdDesguace(), configuracion.getUsuarioDesguace(), configuracion.getPasswordDesguace());
            
            // si el desguace no es null
            if (aux != null) {
                // guardo el desguace obtenido
                desguace = new Desguace(aux);
                // si el empleado no es null
                if (e != null) {
                    try{
                        // si la contrasenya es correcta
                        SHA1 sha = new SHA1();
                        // si la contraseña coincide
                        if (sha.getHash(new String(campoPassword.getPassword())).equals(e.getContrasena())) {
                            // abro la aplicacion
                            FormBase fb = new FormBase(desguace, e);
                            fb.setVisible(true);
                            this.setVisible(false);
                        } else {
                            // si no, emito error
                            JOptionPane.showMessageDialog(rootPane, "El usuario y/o la contraseña es erronea", "Error de login", JOptionPane.ERROR_MESSAGE);
                        }
                    }
                    catch(Exception ex){

                    }
                } else {
                    // emito error
                    JOptionPane.showMessageDialog(rootPane, "El usuario y/o la contraseña es erronea", "Error de login", JOptionPane.ERROR_MESSAGE);
                }
            } else {
                // emito error
                JOptionPane.showMessageDialog(rootPane, "No se ha encontrado el desguace", "Error en el servidor", JOptionPane.ERROR_MESSAGE);
            }
        }

        catch(Exception e3){
            JOptionPane.showMessageDialog(rootPane, "No se ha encontrado el servicio web, revise su configuracion", "Error en el servicio web", JOptionPane.ERROR_MESSAGE);

        }
          

        

    }//GEN-LAST:event_botonEntrarActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                new FormLogin().setVisible(true);
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton botonEntrar;
    private javax.swing.JPasswordField campoPassword;
    private javax.swing.JTextField campoUsuario;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    // End of variables declaration//GEN-END:variables
    private Configuracion configuracion;
    private Desguace desguace;
}
