/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * PanelPrimeraVezBienvenida.java
 *
 * Created on 23-ene-2011, 17:29:05
 */

package aplicaciondesguace;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class PanelPrimeraVezBienvenida extends javax.swing.JPanel {

    /** Creates new form PanelPrimeraVezBienvenida */
    public PanelPrimeraVezBienvenida() {
        initComponents();
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        PanelPrincipal2 = new javax.swing.JPanel();
        jLabel12 = new javax.swing.JLabel();
        etiq1 = new javax.swing.JLabel();
        etiq3 = new javax.swing.JLabel();
        etiq4 = new javax.swing.JLabel();
        etiq5 = new javax.swing.JLabel();
        etiq2 = new javax.swing.JLabel();

        jLabel12.setFont(new java.awt.Font("Tahoma", 0, 14));
        jLabel12.setForeground(new java.awt.Color(0, 102, 204));
        jLabel12.setText("Bienvenido a Criludage");

        etiq1.setText("Es la primera vez que ejecuta la aplicación de Desguace de Crliudage. El siguiente asistente");

        etiq3.setText("Recuerde que puede ponerse en contacto con el departamento de soporte de Criludage en");

        etiq4.setText("criludage@gmail.com y recibir asistencia de la aplicación.");

        etiq5.setText("Pulsa siguiente para continuar");

        etiq2.setText("le ayudará a configurar la aplicación.");

        javax.swing.GroupLayout PanelPrincipal2Layout = new javax.swing.GroupLayout(PanelPrincipal2);
        PanelPrincipal2.setLayout(PanelPrincipal2Layout);
        PanelPrincipal2Layout.setHorizontalGroup(
            PanelPrincipal2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelPrincipal2Layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(PanelPrincipal2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(etiq5, javax.swing.GroupLayout.DEFAULT_SIZE, 463, Short.MAX_VALUE)
                    .addComponent(jLabel12)
                    .addGroup(PanelPrincipal2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                        .addComponent(etiq4, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(etiq3, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(etiq2, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(etiq1, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 463, Short.MAX_VALUE)))
                .addContainerGap())
        );
        PanelPrincipal2Layout.setVerticalGroup(
            PanelPrincipal2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(PanelPrincipal2Layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel12)
                .addGap(18, 18, 18)
                .addComponent(etiq1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(etiq2)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(etiq3)
                .addGap(5, 5, 5)
                .addComponent(etiq4)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 108, Short.MAX_VALUE)
                .addComponent(etiq5)
                .addContainerGap())
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(PanelPrincipal2, javax.swing.GroupLayout.DEFAULT_SIZE, 457, Short.MAX_VALUE)
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addComponent(PanelPrincipal2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addContainerGap())
        );
    }// </editor-fold>//GEN-END:initComponents


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JPanel PanelPrincipal2;
    private javax.swing.JLabel etiq1;
    private javax.swing.JLabel etiq2;
    private javax.swing.JLabel etiq3;
    private javax.swing.JLabel etiq4;
    private javax.swing.JLabel etiq5;
    private javax.swing.JLabel jLabel12;
    // End of variables declaration//GEN-END:variables

}
