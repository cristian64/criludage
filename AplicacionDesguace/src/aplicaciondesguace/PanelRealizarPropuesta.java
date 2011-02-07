/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * PanelPropuesta.java
 *
 * Created on 27-ene-2011, 22:13:25
 */
package aplicaciondesguace;

import java.io.IOException;
import java.net.URL;
import java.security.NoSuchAlgorithmException;
import java.util.GregorianCalendar;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.swing.JOptionPane;
import org.tempuri.ENEstadosPieza;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class PanelRealizarPropuesta extends javax.swing.JPanel {

    /** Creates new form PanelPropuesta */
    public PanelRealizarPropuesta(FormBase b, Propuesta p) {
        initComponents();

        base = b;
        propuesta = p;

        listaEstado.removeAllItems();
        listaEstado.addItem("USADA");
        listaEstado.addItem("NO_FUNCIONA");
        listaEstado.addItem("NUEVA");

        //System.out.println("|"+propuesta.getIdSolicitud());
        campoId.setText(p.getIdSolicitud()+"");
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        etiqTitulo = new javax.swing.JLabel();
        etiqId = new javax.swing.JLabel();
        campoId = new javax.swing.JTextField();
        etiqDescripcion = new javax.swing.JLabel();
        etiqEstado = new javax.swing.JLabel();
        etiqPrecio = new javax.swing.JLabel();
        listaEstado = new javax.swing.JComboBox();
        campoPrecio = new javax.swing.JSpinner();
        etiqFechaEntrega = new javax.swing.JLabel();
        campoFechaEntrega = new javax.swing.JTextField();
        etiqInformacionAdicional = new javax.swing.JLabel();
        jScrollPane2 = new javax.swing.JScrollPane();
        campoInformacionAdicional = new javax.swing.JTextArea();
        jScrollPane3 = new javax.swing.JScrollPane();
        campoDescripcion = new javax.swing.JTextArea();
        botonEnviarPropuesta = new javax.swing.JButton();
        botonLimpiar = new javax.swing.JButton();
        etiqFechaEjemplo = new javax.swing.JLabel();

        etiqTitulo.setFont(new java.awt.Font("Tahoma", 1, 18));
        etiqTitulo.setText("Realizar propuesta");

        etiqId.setText("ID de la Solicitud");

        campoId.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoIdActionPerformed(evt);
            }
        });

        etiqDescripcion.setText("Descripción de la pieza");

        etiqEstado.setText("Estado");

        etiqPrecio.setText("Precio");

        listaEstado.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Item 1", "Item 2", "Item 3", "Item 4" }));

        campoPrecio.setModel(new javax.swing.SpinnerNumberModel(Double.valueOf(1.0d), null, null, Double.valueOf(1.0d)));

        etiqFechaEntrega.setText("Fecha de entrega");

        etiqInformacionAdicional.setText("Información adicional");

        campoInformacionAdicional.setColumns(20);
        campoInformacionAdicional.setRows(5);
        jScrollPane2.setViewportView(campoInformacionAdicional);

        campoDescripcion.setColumns(20);
        campoDescripcion.setRows(5);
        jScrollPane3.setViewportView(campoDescripcion);

        botonEnviarPropuesta.setFont(new java.awt.Font("Tahoma", 1, 11));
        botonEnviarPropuesta.setText("Enviar Propuesta");
        botonEnviarPropuesta.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                botonEnviarPropuestaActionPerformed(evt);
            }
        });

        botonLimpiar.setText("Limpiar Formulario");

        etiqFechaEjemplo.setForeground(new java.awt.Color(153, 153, 153));
        etiqFechaEjemplo.setText("Ejemplo: 31-10-2010 14:00:00");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(etiqTitulo, javax.swing.GroupLayout.DEFAULT_SIZE, 765, Short.MAX_VALUE)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(etiqId, javax.swing.GroupLayout.DEFAULT_SIZE, 108, Short.MAX_VALUE)
                            .addComponent(etiqDescripcion, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(etiqEstado, javax.swing.GroupLayout.DEFAULT_SIZE, 108, Short.MAX_VALUE)
                            .addComponent(etiqPrecio, javax.swing.GroupLayout.DEFAULT_SIZE, 108, Short.MAX_VALUE)
                            .addComponent(etiqFechaEntrega, javax.swing.GroupLayout.DEFAULT_SIZE, 108, Short.MAX_VALUE)
                            .addComponent(etiqInformacionAdicional, javax.swing.GroupLayout.DEFAULT_SIZE, 108, Short.MAX_VALUE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 647, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(listaEstado, javax.swing.GroupLayout.PREFERRED_SIZE, 186, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jScrollPane3, javax.swing.GroupLayout.DEFAULT_SIZE, 647, Short.MAX_VALUE)
                            .addComponent(campoId, javax.swing.GroupLayout.PREFERRED_SIZE, 187, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addComponent(botonEnviarPropuesta, javax.swing.GroupLayout.PREFERRED_SIZE, 193, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 279, Short.MAX_VALUE)
                                .addComponent(botonLimpiar, javax.swing.GroupLayout.PREFERRED_SIZE, 175, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                                    .addComponent(campoFechaEntrega, javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(campoPrecio, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 186, Short.MAX_VALUE))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(etiqFechaEjemplo, javax.swing.GroupLayout.DEFAULT_SIZE, 457, Short.MAX_VALUE)))))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(etiqTitulo, javax.swing.GroupLayout.PREFERRED_SIZE, 36, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqId)
                    .addComponent(campoId, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(etiqDescripcion)
                    .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 49, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(11, 11, 11)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqEstado)
                    .addComponent(listaEstado, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqPrecio)
                    .addComponent(campoPrecio, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(7, 7, 7)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(campoFechaEntrega, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(etiqFechaEntrega)
                    .addComponent(etiqFechaEjemplo))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(etiqInformacionAdicional)
                    .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 51, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(botonLimpiar)
                    .addComponent(botonEnviarPropuesta))
                .addContainerGap(127, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void campoIdActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoIdActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoIdActionPerformed

    private GregorianCalendar getGregorianCalendar(String s, String sep) {

        String fecha = s.split(sep)[0];
        String hora = s.split(sep)[1];

        int ano = new Integer(fecha.split("-")[0]);
        int mes = new Integer(fecha.split("-")[1]);
        int dia = new Integer(fecha.split("-")[2]);

        int hor = new Integer(hora.split(":")[0]);
        int min = new Integer(hora.split(":")[1]);
        int seg = new Integer(hora.split(":")[2]);

        System.out.println(dia + "." + mes + "." + ano + " " + hor + ":" + min + ":" + seg);

        GregorianCalendar g = new GregorianCalendar(ano, mes, dia);
        g.set(GregorianCalendar.DAY_OF_MONTH, dia);
        g.set(GregorianCalendar.MONTH, mes);
        g.set(GregorianCalendar.YEAR, ano);
        
        g.set(GregorianCalendar.HOUR_OF_DAY, hor);
        g.set(GregorianCalendar.MINUTE, min);
        g.set(GregorianCalendar.SECOND, seg);



        //System.out.println(ImprimirFecha(g));

        return g;
    }

    private void botonEnviarPropuestaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_botonEnviarPropuestaActionPerformed

        if (new Float(campoPrecio.getValue().toString()) > 0) {
            Pattern pa = Pattern.compile("[0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9] [0-9][0-9]:[0-9][0-9]:[0-9][0-9]");
            Matcher m = pa.matcher(campoFechaEntrega.getText());
            // si coincide
            if (m.find()) {

                propuesta.setDescripcion(campoDescripcion.getText());
                if (listaEstado.getSelectedIndex() == 0) {
                    propuesta.setEstado(ENEstadosPieza.USADA);
                }
                if (listaEstado.getSelectedIndex() == 1) {
                    propuesta.setEstado(ENEstadosPieza.NO_FUNCIONA);
                }
                if (listaEstado.getSelectedIndex() == 2) {
                    propuesta.setEstado(ENEstadosPieza.NUEVA);
                }
                propuesta.setPrecio(new Float(campoPrecio.getValue().toString()));
                propuesta.setInformacionAdicional(campoInformacionAdicional.getText());
                propuesta.setMiFechaEntrega(getGregorianCalendar(campoFechaEntrega.getText(), " "));

                try {

                    Configuracion configuracion = new Configuracion();

                    configuracion.leerConfiguracion("conf.xml");

                    URL url = new URL(configuracion.getWebService());

                    url.getContent();

                    org.tempuri.InterfazRemota ir = null;

                    ir = new org.tempuri.InterfazRemota(url);

                    soap = ir.getInterfazRemotaSoap();

                    soap.inicializar();

                    //p.guardar();
                    propuesta.setIdDesguace(base.getDesguace().getId());
                    propuesta.setIdEmpleado(base.getEmpleado().getId());

                    SHA1 encriptador = new SHA1();

                    propuesta.setId(soap.proponerPieza(propuesta.getENPropuesta(), configuracion.getUsuarioDesguace(), configuracion.getPasswordDesguace()));

                    System.out.println(propuesta.getMiFechaEntrega());

                    if (propuesta.getId() > 0) {
                        propuesta.guardar();
                    } else {
                        JOptionPane.showMessageDialog(this, "Error en la propuesta, comprueba la fecha de entrega", "Error propuesta", JOptionPane.ERROR_MESSAGE);

                    }


                } catch (IOException e) {
                    JOptionPane.showMessageDialog(this, "El Servicio Web no se ha encontrado", "Error Servicio Web", JOptionPane.ERROR_MESSAGE);

                }

            } else {
                JOptionPane.showMessageDialog(this, "Debes introducir una fecha valida", "error en la fecha", JOptionPane.ERROR_MESSAGE);
            }

        } else {
            JOptionPane.showMessageDialog(this, "Debes introducir un precio para la pieza", "error en el precio", JOptionPane.ERROR_MESSAGE);
        }


        /*
        try {

        Configuracion configuracion = new Configuracion();

        configuracion.leerConfiguracion("conf.xml");

        URL url = new URL(configuracion.getWebService());

        url.getContent();

        org.tempuri.InterfazRemota ir = null;

        ir = new org.tempuri.InterfazRemota(url);

        soap = ir.getInterfazRemotaSoap();

        soap.inicializar();

        //p.guardar();
        propuesta.setIdDesguace(base.getDesguace().getId());
        System.out.println("->" + propuesta.getIdDesguace());
        propuesta.setIdEmpleado(base.getEmpleado().getId());
        propuesta.setDescripcion(campoDescripcion.getText());
        propuesta.setInformacionAdicional(campoInformacionAdicional.getText());
        propuesta.GCToXMLGC(new GregorianCalendar());
        if (listaEstado.getSelectedIndex() == 0) {
        propuesta.setEstado(ENEstadosPieza.USADA);
        }
        if (listaEstado.getSelectedIndex() == 1) {
        propuesta.setEstado(ENEstadosPieza.NO_FUNCIONA);
        }
        if (listaEstado.getSelectedIndex() == 2) {
        propuesta.setEstado(ENEstadosPieza.NUEVA);
        }
        propuesta.setPrecio(new Float(campoPrecio.getValue().toString()));


        //int ok = soap.proponerPieza(propuesta.getENPropuesta(), "", "");
        SHA1 encriptador = new SHA1();
        try{
        int ok = soap.proponerPieza(propuesta.getENPropuesta(), configuracion.getUsuarioDesguace(), configuracion.getPasswordDesguace());
        System.out.println(encriptador.getHash(configuracion.getPasswordDesguace()));
        System.out.println(configuracion.getPasswordDesguace());
        }
        catch(NoSuchAlgorithmException ex){

        }


        } catch (IOException e) {
        JOptionPane.showMessageDialog(this, "El Servicio Web no se ha encontrado", "Error Servicio Web", JOptionPane.ERROR_MESSAGE);

        }*/

    }//GEN-LAST:event_botonEnviarPropuestaActionPerformed
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton botonEnviarPropuesta;
    private javax.swing.JButton botonLimpiar;
    private javax.swing.JTextArea campoDescripcion;
    private javax.swing.JTextField campoFechaEntrega;
    private javax.swing.JTextField campoId;
    private javax.swing.JTextArea campoInformacionAdicional;
    private javax.swing.JSpinner campoPrecio;
    private javax.swing.JLabel etiqDescripcion;
    private javax.swing.JLabel etiqEstado;
    private javax.swing.JLabel etiqFechaEjemplo;
    private javax.swing.JLabel etiqFechaEntrega;
    private javax.swing.JLabel etiqId;
    private javax.swing.JLabel etiqInformacionAdicional;
    private javax.swing.JLabel etiqPrecio;
    private javax.swing.JLabel etiqTitulo;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JComboBox listaEstado;
    // End of variables declaration//GEN-END:variables
    org.tempuri.InterfazRemotaSoap soap;
    private FormBase base;
    private Propuesta propuesta;
}
