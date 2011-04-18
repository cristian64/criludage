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

import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.URL;
import java.text.DecimalFormat;
import java.util.Date;
import java.util.GregorianCalendar;
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

        // asigno el FormBase y la propuesta
        base = b;
        propuesta = p;

        // relleno la lista
        listaEstado.removeAllItems();
        listaEstado.addItem("USADA");
        listaEstado.addItem("NO_FUNCIONA");
        listaEstado.addItem("NUEVA");

        // relleno la id de la solicitud
        campoId.setText(p.getIdSolicitud()+"");
    }

    // imprime una fecha formateada
    public String ImprimirFecha(GregorianCalendar f) {

        DecimalFormat format = new DecimalFormat("00");

        return format.format(f.get(GregorianCalendar.DAY_OF_MONTH)) + "." +
                format.format(f.get(GregorianCalendar.MONTH)+1) + "." +
                format.format(f.get(GregorianCalendar.YEAR)) + " " +
                format.format(f.get(GregorianCalendar.HOUR_OF_DAY)) + ":" +
                format.format(f.get(GregorianCalendar.MINUTE)) + ":" +
                format.format(f.get(GregorianCalendar.SECOND));
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
        etiqInformacionAdicional = new javax.swing.JLabel();
        jScrollPane2 = new javax.swing.JScrollPane();
        campoInformacionAdicional = new javax.swing.JTextArea();
        jScrollPane3 = new javax.swing.JScrollPane();
        campoDescripcion = new javax.swing.JTextArea();
        botonEnviarPropuesta = new javax.swing.JButton();
        botonLimpiar = new javax.swing.JButton();
        spinnerFecha = new javax.swing.JSpinner();

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

        spinnerFecha.setModel(new javax.swing.SpinnerDateModel());

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(etiqTitulo, javax.swing.GroupLayout.DEFAULT_SIZE, 807, Short.MAX_VALUE)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(etiqId, javax.swing.GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE)
                            .addComponent(etiqDescripcion, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(etiqEstado, javax.swing.GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE)
                            .addComponent(etiqPrecio, javax.swing.GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE)
                            .addComponent(etiqFechaEntrega, javax.swing.GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE)
                            .addComponent(etiqInformacionAdicional, javax.swing.GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 647, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(listaEstado, javax.swing.GroupLayout.PREFERRED_SIZE, 186, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jScrollPane3, javax.swing.GroupLayout.DEFAULT_SIZE, 649, Short.MAX_VALUE)
                            .addComponent(campoId, javax.swing.GroupLayout.PREFERRED_SIZE, 187, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addComponent(botonEnviarPropuesta, javax.swing.GroupLayout.PREFERRED_SIZE, 193, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 281, Short.MAX_VALUE)
                                .addComponent(botonLimpiar, javax.swing.GroupLayout.PREFERRED_SIZE, 175, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                .addComponent(spinnerFecha)
                                .addComponent(campoPrecio, javax.swing.GroupLayout.DEFAULT_SIZE, 186, Short.MAX_VALUE)))))
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
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(7, 7, 7)
                        .addComponent(etiqFechaEntrega))
                    .addGroup(layout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(spinnerFecha, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(etiqInformacionAdicional)
                    .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 51, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(botonLimpiar)
                    .addComponent(botonEnviarPropuesta))
                .addContainerGap(134, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void campoIdActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoIdActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoIdActionPerformed

    // devuelve un gregorianCalendar a partir de un string y el caracter de separacion entre la fecha y la hora
    private GregorianCalendar getGregorianCalendar(String s, String sep) {

        // separo la fecha de la hora
        String fecha = s.split(sep)[0];
        String hora = s.split(sep)[1];

        // obtengo los datos
        int ano = new Integer(fecha.split("-")[0]);
        int mes = new Integer(fecha.split("-")[1]);
        int dia = new Integer(fecha.split("-")[2]);

        int hor = new Integer(hora.split(":")[0]);
        int min = new Integer(hora.split(":")[1]);
        int seg = new Integer(hora.split(":")[2]);

        // creo el GregorianCalendar
        GregorianCalendar g = new GregorianCalendar(ano, mes, dia);
        g.set(GregorianCalendar.DAY_OF_MONTH, dia);
        g.set(GregorianCalendar.MONTH, mes);
        g.set(GregorianCalendar.YEAR, ano);
        
        g.set(GregorianCalendar.HOUR_OF_DAY, hor);
        g.set(GregorianCalendar.MINUTE, min);
        g.set(GregorianCalendar.SECOND, seg);

        // y lo devuelvo
        return g;
    }

    private void addLog(String s){
        FileWriter fichero = null;
        PrintWriter pw = null;
        try
        {
            fichero = new FileWriter("Registro.log",true);
            pw = new PrintWriter(fichero);

            pw.println(ImprimirFecha(new GregorianCalendar()) + " " + s);

        } catch (Exception ex) {
            ex.printStackTrace();
        } finally {
           try {
           if (null != fichero)
              fichero.close();
           } catch (Exception e2) {
              e2.printStackTrace();
           }
        }
    }

    private void botonEnviarPropuestaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_botonEnviarPropuestaActionPerformed

        // obtengo la fecha de entrega
        GregorianCalendar f = new GregorianCalendar();
        f.setTime((Date)spinnerFecha.getValue());
        f.set(f.SECOND, 0);

        // si la de entrega es posterior a la actual
        if(f.after(new GregorianCalendar())){
            // si el precio es mayor que 0
            if (new Float(campoPrecio.getValue().toString()) > 0) {
                // asigno los valores introducidos
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
                propuesta.setMiFechaEntrega(f);


                try {
                    // creo el servicio web
                    Configuracion configuracion = new Configuracion();
                    configuracion.leerConfiguracion("conf.xml");
                    URL url = new URL(configuracion.getWebService());
                    url.getContent();
                    org.tempuri.InterfazRemota ir = null;
                    ir = new org.tempuri.InterfazRemota();
                    soap = ir.getInterfazRemotaSoap();
                    soap.inicializar();

                    // asigno los datos del desguace y del empleado
                    propuesta.setIdDesguace(base.getDesguace().getId());
                    propuesta.setIdEmpleado(base.getEmpleado().getId());

                    // propongo la pieza y asigno la id de retorno a la propuesta
                    propuesta.setId(soap.proponerPieza(propuesta.getENPropuesta(), configuracion.getUsuarioDesguace(), configuracion.getPasswordDesguace()));

                    // si la id es mayor que 0
                    if (propuesta.getId() > 0) {
                        // se ha realizado la propuesta y la guardamos
                        propuesta.guardar(configuracion.getBdHost());
                        // dejamos constancia en el log
                        addLog("Realizada propuesta: " + propuesta.getId() + "(" + propuesta.getDescripcion() + ")");
                    } 
                    // si es menor o igual a 0 ha habido un error
                    else {
                        // emito error
                        JOptionPane.showMessageDialog(this, "Error en la propuesta, comprueba la fecha de entrega", "Error propuesta", JOptionPane.ERROR_MESSAGE);
                    }
                } catch (IOException e) {
                    JOptionPane.showMessageDialog(this, "El Servicio Web no se ha encontrado", "Error Servicio Web", JOptionPane.ERROR_MESSAGE);

                }

            } else {
                JOptionPane.showMessageDialog(this, "Debes introducir un precio para la pieza", "error en el precio", JOptionPane.ERROR_MESSAGE);
            }
        }
        else{
            JOptionPane.showMessageDialog(this, "La fecha debe ser posterior a la actual", "error en la fecha de entrega", JOptionPane.ERROR_MESSAGE);
        }

       
    }//GEN-LAST:event_botonEnviarPropuestaActionPerformed
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton botonEnviarPropuesta;
    private javax.swing.JButton botonLimpiar;
    private javax.swing.JTextArea campoDescripcion;
    private javax.swing.JTextField campoId;
    private javax.swing.JTextArea campoInformacionAdicional;
    private javax.swing.JSpinner campoPrecio;
    private javax.swing.JLabel etiqDescripcion;
    private javax.swing.JLabel etiqEstado;
    private javax.swing.JLabel etiqFechaEntrega;
    private javax.swing.JLabel etiqId;
    private javax.swing.JLabel etiqInformacionAdicional;
    private javax.swing.JLabel etiqPrecio;
    private javax.swing.JLabel etiqTitulo;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JComboBox listaEstado;
    private javax.swing.JSpinner spinnerFecha;
    // End of variables declaration//GEN-END:variables
    org.tempuri.InterfazRemotaSoap soap;
    private FormBase base;
    private Propuesta propuesta;
}
