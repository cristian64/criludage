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

import java.awt.Color;
import java.awt.Component;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.GregorianCalendar;
import javax.swing.BorderFactory;
import javax.swing.JCheckBox;
import javax.swing.JFormattedTextField;
import javax.swing.JLabel;
import javax.swing.JTable;
import javax.swing.Timer;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableCellRenderer;
import javax.swing.table.TableColumn;
import javax.swing.table.TableColumnModel;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class PanelSolicitudes extends javax.swing.JPanel {

    /** Creates new form PanelPropuestas */
    public PanelSolicitudes(FormBase b) {
        initComponents();

        // guardo el formulario base
        base = b;

        // creo la forma de dibujo para cada tipo de tabla
        tablaSolicitudes.setDefaultRenderer(String.class, new myDataModel());
        tablaSolicitudes.setDefaultRenderer(Integer.class, new myDataModel());
        tablaSolicitudes.setDefaultRenderer(Double.class, new myDataModel());
        tablaSolicitudes.setDefaultRenderer(Float.class, new myDataModel());
        tablaSolicitudes.setDefaultRenderer(Boolean.class, new myDataModel());


        // obtengo el modelo de la tabla
        TableColumnModel modeloColumna = tablaSolicitudes.getColumnModel();
        TableColumn columnaTabla;
        int ancho = 0;
        // recorro todos los modelos
        for (int i = 0; i < modeloColumna.getColumnCount(); i++) {

            // asigno la proporcion en funcion de la columna
            columnaTabla = modeloColumna.getColumn(i);
            if(i==0){
                ancho = 10;
                columnaTabla.setMaxWidth(25);
                columnaTabla.setMinWidth(25);
            }
            if(i==1){
                ancho = 150;
            }
            if(i==2){
                ancho = 80;
                columnaTabla.setMaxWidth(150);
                columnaTabla.setMinWidth(150);
            }
            if(i==3){
                ancho = 80;
                columnaTabla.setMaxWidth(150);
                columnaTabla.setMinWidth(150);
            }
            if(i==4){
                ancho = 50;
            }
            if(i==5){
                ancho = 40;
            }
            if(i==6){
                ancho = 40;
            }
            if(i==7){
                columnaTabla.setMaxWidth(150);
                columnaTabla.setMinWidth(150);
            }
            columnaTabla.setPreferredWidth(ancho);
        }
        // actualizo
        updateUI();

        // anyado el evento doble click a las filas de la tabla
        tablaSolicitudes.addMouseListener(new MouseAdapter() {

            public void mouseReleased(MouseEvent e) {
                if (e.getClickCount() >= 2) {
                    // al hacer doble click, se abre el panel para ver la solicidtud
                    base.addPanel(new PanelVerSolicitud(base, solicitudes.get(tablaSolicitudes.getSelectedRow())));
                }
            }
        });

        // creo un timer que refresca las solicitudes cada 20 segundos
        Timer timer = new Timer(20000, new ActionListener() {

            public void actionPerformed(ActionEvent e) {
                Refrescar();
            }
        });

        // comienza el timer
        timer.start();

        // relleno la tabla
        Refrescar();
    }

    public void Refrescar() {


        Solicitud s = new Solicitud();

        // obtengo el modelo de la tabla
        DefaultTableModel temp = (DefaultTableModel) tablaSolicitudes.getModel();

        // obtengo la fila seleccionada
        int fila = tablaSolicitudes.getSelectedRow();

        // borro todas las filas
        for (int i = temp.getRowCount() - 1; i >= 0; i--) {
            temp.removeRow(i);
        }

        // obtengo las solicitudes
        solicitudes = s.obtenerTodas(base.getConfiguracion().getBdHost());

        // las meto en la tabla
        for (int i = 0; i < solicitudes.size(); i++) {
            procesarSolicitud(solicitudes.get(i));

        }
        // restauro la fila seleccionada
        if (fila != -1) {
            tablaSolicitudes.setRowSelectionInterval(fila, fila);
        }
    }

    // anyade la solicitud a la tabla
    private void procesarSolicitud(Solicitud s) {

        // obtengo el modelo de la tabla
        DefaultTableModel temp = (DefaultTableModel) tablaSolicitudes.getModel();
        // creo el objeto a insertar
        Object nuevo[] = {s.getId(), s.getDescripcion(), ImprimirFecha(s.getMiFecha()), ImprimirFecha(s.getMiFechaRespuesta()), s.isNegociadoAutomatico(), s.getEstado().toString(), s.getPrecioMax(), ImprimirFecha(s.getMiFechaEntrega())};
        // lo inserto
        temp.addRow(nuevo);

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

    // devuelve un gregorianCalendar a partir de un string
    private GregorianCalendar getGregorianCalendar(String s,String sep){

        //System.out.println(s);

        String fecha = s.split(sep)[0];
        String hora = s.split(sep)[1];

        int ano = new Integer(fecha.split("\\.")[2]);
        int mes = new Integer(fecha.split("\\.")[1]);
        int dia = new Integer(fecha.split("\\.")[0]);

        int hor = new Integer(hora.split(":")[0]);
        int min = new Integer(hora.split(":")[1]);
        int seg = new Integer(hora.split(":")[2]);

        //System.out.println(dia + "." + mes + "." + ano + " " + hor + ":" + min + ":" + seg);

        GregorianCalendar g = new GregorianCalendar(ano, mes, dia);
        g.set(GregorianCalendar.DAY_OF_MONTH, dia);
        g.set(GregorianCalendar.MONTH, mes-1);
        g.set(GregorianCalendar.YEAR,ano);
        g.set(GregorianCalendar.HOUR_OF_DAY, hor);
        g.set(GregorianCalendar.MINUTE, min);
        
        return g;
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
                .addComponent(etiqTitulo, javax.swing.GroupLayout.DEFAULT_SIZE, 755, Short.MAX_VALUE)
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


// clase necesaria para modificar el renderizado de las celdas de la tabla
class myDataModel extends JLabel implements TableCellRenderer {

    public Component getTableCellRendererComponent(JTable tabla, Object value, boolean isSelected, boolean hasFocus, int row, int column) {

        // creo un campo de texto formateado
        JFormattedTextField f = new JFormattedTextField();
        // si es seleccinado
        if (isSelected) {
            // pinto la fila de azul
            f.setBackground(new Color(0x97e5ff));
        } else {
            // si la fecha de respuesta es posterior a la fecha actual
            if (((GregorianCalendar)getGregorianCalendar((String)tabla.getValueAt(row, 3)," ")).after(new GregorianCalendar())) {
                // la pinto de verde
                f.setBackground(new Color(0x73fd83));
            }
            
        }
        // elimino el borde
        f.setBorder(BorderFactory.createEmptyBorder());
        // asigno alineacion izquierda
        f.setHorizontalAlignment(LEFT);

        // relleno los valores en funcion del tipo de dato
        if (value instanceof String) {
            f.setText(value + "");
        }
        if (value instanceof Integer) {
            f.setText(value + "");
        }
        if (value instanceof Double) {
            f.setText(value + "");
        }
        if (value instanceof Float) {
            f.setText(value + "");
        }
        // si es un Booleano
        if (value instanceof Boolean) {
            // creo un checkbox
            JCheckBox c = new JCheckBox();
            // le asigno el valor
            c.setSelected((Boolean) value);
            // alineacion centrada
            c.setHorizontalAlignment(CENTER);
            // si esta seleccionada
            if (isSelected) {
                //la pinto de azul
                c.setBackground(new Color(0x97e5ff));
            } 
            // si no
            else {
                // si la fecha de respuesta es posterior a la actual
                if (((GregorianCalendar)getGregorianCalendar((String)tabla.getValueAt(row, 3)," ")).after(new GregorianCalendar())) {
                    // la pinto de verde
                    c.setBackground(new Color(0x73fd83));
                }
                // si no de blanco
                else{
                    c.setBackground(Color.WHITE);
                }
            }
            return (Component) c;
        }

        return f;
    }


    private GregorianCalendar getGregorianCalendar(String s,String sep){

        //System.out.println(s);

        String fecha = s.split(sep)[0];
        String hora = s.split(sep)[1];

        int ano = new Integer(fecha.split("\\.")[2]);
        int mes = new Integer(fecha.split("\\.")[1]);
        int dia = new Integer(fecha.split("\\.")[0]);

        int hor = new Integer(hora.split(":")[0]);
        int min = new Integer(hora.split(":")[1]);
        int seg = new Integer(hora.split(":")[2]);

        //System.out.println(dia + "." + mes + "." + ano + " " + hor + ":" + min + ":" + seg);

        GregorianCalendar g = new GregorianCalendar();
        g.set(GregorianCalendar.DAY_OF_MONTH, dia);
        g.set(GregorianCalendar.MONTH, mes-1);
        g.set(GregorianCalendar.YEAR,ano);
        g.set(GregorianCalendar.HOUR_OF_DAY, hor);
        g.set(GregorianCalendar.MINUTE, min);
        g.set(GregorianCalendar.SECOND, seg);



        //System.out.println(ImprimirFecha(g));

        return g;
    }

    public String ImprimirFecha(GregorianCalendar f) {

        DecimalFormat format = new DecimalFormat("00");

        return format.format(f.get(GregorianCalendar.DAY_OF_MONTH)) + "." +
                format.format(f.get(GregorianCalendar.MONTH)+1) + "." +
                format.format(f.get(GregorianCalendar.YEAR)) + " " +
                format.format(f.get(GregorianCalendar.HOUR_OF_DAY)) + ":" +
                format.format(f.get(GregorianCalendar.MINUTE)) + ":" +
                format.format(f.get(GregorianCalendar.SECOND));
    }

}

