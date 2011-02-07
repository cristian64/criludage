/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * PanelPropuestas.java
 *
 * Created on 27-ene-2011, 22:34:09
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
public class PanelSolicitudes extends javax.swing.JPanel {

    /** Creates new form PanelPropuestas */
    public PanelSolicitudes(FormBase b){
        initComponents();

        // guardo el formulario base
        base = b;

        // anyado el evento doble click a las filas de la tabla
        tablaSolicitudes.addMouseListener(new MouseAdapter() {
        public void mouseReleased(MouseEvent e){
            if(e.getClickCount()>=2){
                // al hacer doble click, se abre el panel para ver la solicidtud
                base.addPanel(new PanelVerSolicitud(base,solicitudes.get(tablaSolicitudes.getSelectedRow())));
            }
        }
        });

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


        Solicitud s = new Solicitud();

        // obtengo el modelo de la tabla
        DefaultTableModel temp = (DefaultTableModel) tablaSolicitudes.getModel();

        // obtengo la fila seleccionada
        int fila = tablaSolicitudes.getSelectedRow();

        // borro todas las filas
        for(int i=temp.getRowCount()-1;i>=0;i--){
            temp.removeRow(i);
        }

        // obtengo las solicitudes
        solicitudes = s.obtenerTodas();

        // las meto en la tabla
        for(int i=0;i<solicitudes.size();i++){
            procesarSolicitud(solicitudes.get(i));
        }
        // restauro la fila seleccionada
        if(fila != -1){
            tablaSolicitudes.setRowSelectionInterval(fila, fila);
        }
    }

    private void procesarSolicitud(Solicitud s){

        // obtengo el modelo de la tabla
        DefaultTableModel temp = (DefaultTableModel) tablaSolicitudes.getModel();
        // creo el objeto a insertar
        Object nuevo[]= {s.getId(),s.getDescripcion(),ImprimirFecha(s.getMiFecha()),ImprimirFecha(s.getMiFechaEntrega()),s.isNegociadoAutomatico(),s.getEstado(),s.getPrecioMax(),ImprimirFecha(s.getMiFechaRespuesta())};
        // lo inserto
        temp.addRow(nuevo);
    }

    public String ImprimirFecha(GregorianCalendar f) {

        return f.get(GregorianCalendar.YEAR) + "." +
                f.get(GregorianCalendar.MONTH) + "." +
                f.get(GregorianCalendar.DAY_OF_MONTH) + " " +
                f.get(GregorianCalendar.HOUR_OF_DAY) + ":" +
                f.get(GregorianCalendar.MINUTE) + ":" +
                f.get(GregorianCalendar.SECOND);
    }
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        etiqTitulo = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        tablaSolicitudes = new javax.swing.JTable();

        etiqTitulo.setFont(new java.awt.Font("Tahoma", 1, 18));
        etiqTitulo.setText("Solicitudes");

        tablaSolicitudes.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "ID ", "Descripcion", "Fecha", "Fecha de respuesta", "Negociado automático", "Estado", "Precio máximo", "Fecha de entrega"
            }
        ) {
            Class[] types = new Class [] {
                java.lang.Integer.class, java.lang.String.class, java.lang.String.class, java.lang.String.class, java.lang.Boolean.class, java.lang.String.class, java.lang.Float.class, java.lang.String.class
            };
            boolean[] canEdit = new boolean [] {
                false, false, false, false, false, false, false, false
            };

            public Class getColumnClass(int columnIndex) {
                return types [columnIndex];
            }

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        tablaSolicitudes.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tablaSolicitudesMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(tablaSolicitudes);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(etiqTitulo, javax.swing.GroupLayout.DEFAULT_SIZE, 747, Short.MAX_VALUE)
                .addContainerGap())
            .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 767, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(etiqTitulo, javax.swing.GroupLayout.PREFERRED_SIZE, 36, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 352, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void tablaSolicitudesMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tablaSolicitudesMouseClicked

        
    }//GEN-LAST:event_tablaSolicitudesMouseClicked


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel etiqTitulo;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTable tablaSolicitudes;
    // End of variables declaration//GEN-END:variables

    private ArrayList<Solicitud> solicitudes;
    private FormBase base = null;

}
