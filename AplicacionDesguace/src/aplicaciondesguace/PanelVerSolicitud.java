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

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.GregorianCalendar;
import javax.swing.Timer;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class PanelVerSolicitud extends javax.swing.JPanel {

    /** Creates new form PanelPropuesta */
    public PanelVerSolicitud(FormBase b,Solicitud s) {
        initComponents();

        base = b;
        solicitud = s;

        if(solicitud.getMiFechaRespuesta().getTime().before(new GregorianCalendar().getTime())){
            botonPropuesta.setEnabled(false);
        }

        campoId.setText("" + s.getId());
        campoIdCliente.setText("" + s.getIdCliente());
        campoDescripcion.setText("" + s.getDescripcion());
        campoEstado.setText("" + s.getEstado());
        campoFecha.setText(ImprimirFecha(s.getMiFecha()));
        campoFechaEntrega.setText(ImprimirFecha(s.getMiFechaEntrega()));
        campoFechaRespuesta.setText(ImprimirFecha(s.getMiFechaRespuesta()));
        campoInformacion.setText("" + s.getInformacionAdicional());
        campoPrecio.setText("" + s.getPrecioMax() + " €");
        checkNegociadoAutomatico.setSelected(s.isNegociadoAutomatico());

        // anyado el evento doble click a las filas de la tabla
        tablaPropuestas.addMouseListener(new MouseAdapter() {
        public void mouseReleased(MouseEvent e){
            if(e.getClickCount()>=2){
                // al hacer doble click, se abre el panel para ver la solicidtud
                //base.addPanel(new PanelVerSolicitud(base,solicitudes.get(tablaSolicitudes.getSelectedRow())));
            }
        }
        });

        propuestas = new ArrayList<Propuesta>();

        // creo un timer que refresca las solicitudes cada 20 segundos
        Timer timer = new Timer (20000, new ActionListener ()
        {
            public void actionPerformed(ActionEvent e)
            {
                Refrescar();
             }
        });

        // comienza el timer
        timer.start();

        // relleno la tabla
        Refrescar();
    }

    public void Refrescar(){

        Propuesta p = new Propuesta();

        // obtengo el modelo de la tabla
        DefaultTableModel temp = (DefaultTableModel) tablaPropuestas.getModel();

        // obtengo la fila seleccionada
        int fila = tablaPropuestas.getSelectedRow();

        // borro todas las filas
        for(int i=temp.getRowCount()-1;i>=0;i--){
            temp.removeRow(i);
        }

        // obtengo las solicitudes
        propuestas = p.obtenerPropuestasPorSolicitud(solicitud.getId());

        // las meto en la tabla
        for(int i=0;i<propuestas.size();i++){
            procesarPropuesta(propuestas.get(i));
        }
        // restauro la fila seleccionada
        if(fila != -1){
            tablaPropuestas.setRowSelectionInterval(fila, fila);
        }
    }

    private void procesarPropuesta(Propuesta p){

        // obtengo el modelo de la tabla
        DefaultTableModel temp = (DefaultTableModel) tablaPropuestas.getModel();
        // creo el objeto a insertar
        Object nuevo[]= {p.getId(),p.getDescripcion(),p.getEstado(),p.getPrecio(),ImprimirFecha(p.getMiFechaEntrega()),p.getInformacionAdicional()};
        // lo inserto
        temp.addRow(nuevo);
    }

    public String ImprimirFecha(GregorianCalendar f) {

        return f.get(GregorianCalendar.YEAR) + "."
                + f.get(GregorianCalendar.MONTH) + "."
                + f.get(GregorianCalendar.DAY_OF_MONTH) + " "
                + f.get(GregorianCalendar.HOUR_OF_DAY) + ":"
                + f.get(GregorianCalendar.MINUTE) + ":"
                + f.get(GregorianCalendar.SECOND);
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        etiqTitulo = new javax.swing.JLabel();
        etiqIdSolicitud = new javax.swing.JLabel();
        campoEstado = new javax.swing.JTextField();
        etiqDescripcion = new javax.swing.JLabel();
        etiqEstado = new javax.swing.JLabel();
        etiqPrecio = new javax.swing.JLabel();
        etiqFechaEntrega = new javax.swing.JLabel();
        campoFechaEntrega = new javax.swing.JTextField();
        etiqInformacion = new javax.swing.JLabel();
        jScrollPane2 = new javax.swing.JScrollPane();
        campoInformacion = new javax.swing.JTextArea();
        jScrollPane3 = new javax.swing.JScrollPane();
        campoDescripcion = new javax.swing.JTextArea();
        botonPropuesta = new javax.swing.JButton();
        campoId = new javax.swing.JTextField();
        campoPrecio = new javax.swing.JTextField();
        campoIdCliente = new javax.swing.JTextField();
        etiqIdCliente = new javax.swing.JLabel();
        checkNegociadoAutomatico = new javax.swing.JCheckBox();
        etiqNegociadoAutomatico = new javax.swing.JLabel();
        etiqFecha = new javax.swing.JLabel();
        campoFecha = new javax.swing.JTextField();
        etiqFechaRespuesta = new javax.swing.JLabel();
        campoFechaRespuesta = new javax.swing.JTextField();
        jScrollPane1 = new javax.swing.JScrollPane();
        tablaPropuestas = new javax.swing.JTable();
        etiqFechaRespuesta1 = new javax.swing.JLabel();

        etiqTitulo.setFont(new java.awt.Font("Tahoma", 1, 18));
        etiqTitulo.setText("Solicitud");

        etiqIdSolicitud.setText("ID de la Solicitud");

        campoEstado.setEnabled(false);
        campoEstado.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoEstadoActionPerformed(evt);
            }
        });

        etiqDescripcion.setText("Descripción de la pieza");

        etiqEstado.setText("Estado");

        etiqPrecio.setText("Precio");

        etiqFechaEntrega.setText("Fecha de entrega");

        campoFechaEntrega.setEnabled(false);
        campoFechaEntrega.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoFechaEntregaActionPerformed(evt);
            }
        });

        etiqInformacion.setText("Información adicional");

        campoInformacion.setColumns(20);
        campoInformacion.setRows(5);
        campoInformacion.setEnabled(false);
        jScrollPane2.setViewportView(campoInformacion);

        campoDescripcion.setColumns(20);
        campoDescripcion.setRows(5);
        campoDescripcion.setEnabled(false);
        jScrollPane3.setViewportView(campoDescripcion);

        botonPropuesta.setFont(new java.awt.Font("Tahoma", 1, 11));
        botonPropuesta.setText("Realizar Propuesta");
        botonPropuesta.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                botonPropuestaActionPerformed(evt);
            }
        });

        campoId.setEnabled(false);
        campoId.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoIdActionPerformed(evt);
            }
        });

        campoPrecio.setEnabled(false);
        campoPrecio.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoPrecioActionPerformed(evt);
            }
        });

        campoIdCliente.setEnabled(false);
        campoIdCliente.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoIdClienteActionPerformed(evt);
            }
        });

        etiqIdCliente.setText("ID del Cliente");

        checkNegociadoAutomatico.setText("Automatico");
        checkNegociadoAutomatico.setEnabled(false);

        etiqNegociadoAutomatico.setText("Negociado");

        etiqFecha.setText("Fecha");

        campoFecha.setEnabled(false);
        campoFecha.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoFechaActionPerformed(evt);
            }
        });

        etiqFechaRespuesta.setText("Fecha de respuesta");

        campoFechaRespuesta.setEnabled(false);
        campoFechaRespuesta.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoFechaRespuestaActionPerformed(evt);
            }
        });

        tablaPropuestas.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "ID", "Descripcion", "Estado", "Precio", "Fecha de entrega", "Informacion adicional"
            }
        ) {
            Class[] types = new Class [] {
                java.lang.Integer.class, java.lang.String.class, java.lang.String.class, java.lang.Float.class, java.lang.String.class, java.lang.String.class
            };
            boolean[] canEdit = new boolean [] {
                false, false, false, false, true, true
            };

            public Class getColumnClass(int columnIndex) {
                return types [columnIndex];
            }

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        jScrollPane1.setViewportView(tablaPropuestas);

        etiqFechaRespuesta1.setText("Propuestas Realizadas");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(etiqTitulo, javax.swing.GroupLayout.DEFAULT_SIZE, 881, Short.MAX_VALUE)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addComponent(etiqIdSolicitud, javax.swing.GroupLayout.DEFAULT_SIZE, 144, Short.MAX_VALUE)
                                .addGap(18, 18, 18)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jScrollPane3, javax.swing.GroupLayout.DEFAULT_SIZE, 719, Short.MAX_VALUE)
                                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                                        .addComponent(campoId, javax.swing.GroupLayout.Alignment.LEADING)
                                        .addComponent(campoIdCliente, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 134, Short.MAX_VALUE))
                                    .addComponent(checkNegociadoAutomatico)
                                    .addComponent(campoEstado, javax.swing.GroupLayout.DEFAULT_SIZE, 719, Short.MAX_VALUE)
                                    .addComponent(campoFechaEntrega, javax.swing.GroupLayout.DEFAULT_SIZE, 719, Short.MAX_VALUE)
                                    .addComponent(campoPrecio, javax.swing.GroupLayout.PREFERRED_SIZE, 132, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(jScrollPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 719, Short.MAX_VALUE)
                                    .addComponent(campoFecha, javax.swing.GroupLayout.DEFAULT_SIZE, 719, Short.MAX_VALUE)
                                    .addComponent(campoFechaRespuesta, javax.swing.GroupLayout.DEFAULT_SIZE, 719, Short.MAX_VALUE))))
                        .addContainerGap())
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(etiqDescripcion, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                            .addComponent(etiqIdCliente, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                            .addComponent(etiqNegociadoAutomatico, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                            .addComponent(etiqFechaRespuesta, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                            .addComponent(etiqFecha, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                            .addComponent(etiqFechaEntrega, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                            .addComponent(etiqInformacion, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                            .addComponent(etiqEstado, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                            .addComponent(etiqPrecio, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.PREFERRED_SIZE, 142, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(522, 522, 522))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(etiqFechaRespuesta1, javax.swing.GroupLayout.DEFAULT_SIZE, 369, Short.MAX_VALUE)
                        .addGap(309, 309, 309)
                        .addComponent(botonPropuesta, javax.swing.GroupLayout.PREFERRED_SIZE, 203, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addContainerGap())
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 881, Short.MAX_VALUE)
                        .addContainerGap())))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(etiqTitulo, javax.swing.GroupLayout.PREFERRED_SIZE, 36, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqIdSolicitud)
                    .addComponent(campoId, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqIdCliente)
                    .addComponent(campoIdCliente, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(etiqDescripcion)
                        .addGap(42, 42, 42)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(etiqNegociadoAutomatico)
                            .addComponent(checkNegociadoAutomatico))
                        .addGap(16, 16, 16)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(etiqEstado)
                            .addComponent(campoEstado, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(etiqPrecio)
                            .addComponent(campoPrecio, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(7, 7, 7)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(etiqFechaEntrega)
                            .addComponent(campoFechaEntrega, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 49, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 51, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(etiqInformacion)
                        .addGap(43, 43, 43)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(etiqFecha)
                            .addComponent(campoFecha, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(etiqFechaRespuesta)
                            .addComponent(campoFechaRespuesta, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(botonPropuesta))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(28, 28, 28)
                        .addComponent(etiqFechaRespuesta1)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 113, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void campoEstadoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoEstadoActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoEstadoActionPerformed

    private void campoIdActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoIdActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoIdActionPerformed

    private void campoPrecioActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoPrecioActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoPrecioActionPerformed

    private void campoFechaEntregaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoFechaEntregaActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoFechaEntregaActionPerformed

    private void campoIdClienteActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoIdClienteActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoIdClienteActionPerformed

    private void campoFechaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoFechaActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoFechaActionPerformed

    private void campoFechaRespuestaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoFechaRespuestaActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoFechaRespuestaActionPerformed

    private void botonPropuestaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_botonPropuestaActionPerformed

        Propuesta p = new Propuesta();
        p.setIdSolicitud(solicitud.getId());

        

        base.addPanel(new PanelRealizarPropuesta(base, p));

    }//GEN-LAST:event_botonPropuestaActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton botonPropuesta;
    private javax.swing.JTextArea campoDescripcion;
    private javax.swing.JTextField campoEstado;
    private javax.swing.JTextField campoFecha;
    private javax.swing.JTextField campoFechaEntrega;
    private javax.swing.JTextField campoFechaRespuesta;
    private javax.swing.JTextField campoId;
    private javax.swing.JTextField campoIdCliente;
    private javax.swing.JTextArea campoInformacion;
    private javax.swing.JTextField campoPrecio;
    private javax.swing.JCheckBox checkNegociadoAutomatico;
    private javax.swing.JLabel etiqDescripcion;
    private javax.swing.JLabel etiqEstado;
    private javax.swing.JLabel etiqFecha;
    private javax.swing.JLabel etiqFechaEntrega;
    private javax.swing.JLabel etiqFechaRespuesta;
    private javax.swing.JLabel etiqFechaRespuesta1;
    private javax.swing.JLabel etiqIdCliente;
    private javax.swing.JLabel etiqIdSolicitud;
    private javax.swing.JLabel etiqInformacion;
    private javax.swing.JLabel etiqNegociadoAutomatico;
    private javax.swing.JLabel etiqPrecio;
    private javax.swing.JLabel etiqTitulo;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JTable tablaPropuestas;
    // End of variables declaration//GEN-END:variables
    
    private FormBase base = null;
    private Solicitud solicitud;
    private ArrayList<Propuesta> propuestas;
}
