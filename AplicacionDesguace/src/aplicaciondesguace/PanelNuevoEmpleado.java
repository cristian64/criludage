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

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class PanelNuevoEmpleado extends javax.swing.JPanel {

    /** Creates new form PanelPropuesta */
    public PanelNuevoEmpleado() {
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

        opcionesAdmin = new javax.swing.ButtonGroup();
        etiqTitulo = new javax.swing.JLabel();
        etiqID = new javax.swing.JLabel();
        campoPassword2 = new javax.swing.JTextField();
        etiqUsuario = new javax.swing.JLabel();
        etiqPassword1 = new javax.swing.JLabel();
        etiqPassword2 = new javax.swing.JLabel();
        etiqNombre = new javax.swing.JLabel();
        etiqNIF = new javax.swing.JLabel();
        botonGuardar = new javax.swing.JButton();
        botonCancelar = new javax.swing.JButton();
        botonLimpiar = new javax.swing.JButton();
        campoUsuario = new javax.swing.JTextField();
        campoPassword1 = new javax.swing.JTextField();
        campoID = new javax.swing.JTextField();
        campoNombre = new javax.swing.JTextField();
        campoNIF = new javax.swing.JTextField();
        etiqLabel = new javax.swing.JLabel();
        campoCorreo = new javax.swing.JTextField();
        etiqAdmin = new javax.swing.JLabel();
        opcionSi = new javax.swing.JRadioButton();
        opcionNo = new javax.swing.JRadioButton();
        botonBorrar = new javax.swing.JButton();

        etiqTitulo.setFont(new java.awt.Font("Tahoma", 1, 18));
        etiqTitulo.setText("Editar Empleado");

        etiqID.setText("ID");

        campoPassword2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoPassword2ActionPerformed(evt);
            }
        });

        etiqUsuario.setText("Nombre de usuario");

        etiqPassword1.setText("Contraseña");

        etiqPassword2.setText("Contraseña(otra vez)");

        etiqNombre.setText("Nombre completo");

        etiqNIF.setText("NIF");

        botonGuardar.setFont(new java.awt.Font("Tahoma", 1, 11));
        botonGuardar.setText("Guardar usuario");

        botonCancelar.setText("Cancelar");

        botonLimpiar.setText("Limpiar Formulario");

        campoUsuario.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoUsuarioActionPerformed(evt);
            }
        });

        campoPassword1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoPassword1ActionPerformed(evt);
            }
        });

        campoID.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoIDActionPerformed(evt);
            }
        });

        campoNombre.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoNombreActionPerformed(evt);
            }
        });

        campoNIF.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoNIFActionPerformed(evt);
            }
        });

        etiqLabel.setText("Correo electrónico");

        campoCorreo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                campoCorreoActionPerformed(evt);
            }
        });

        etiqAdmin.setText("Adminstrador");

        opcionesAdmin.add(opcionSi);
        opcionSi.setSelected(true);
        opcionSi.setText("Si");
        opcionSi.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                opcionSiActionPerformed(evt);
            }
        });

        opcionesAdmin.add(opcionNo);
        opcionNo.setText("No");

        botonBorrar.setText("Borrar usuario");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(etiqTitulo, javax.swing.GroupLayout.DEFAULT_SIZE, 761, Short.MAX_VALUE)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                    .addComponent(etiqPassword1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addComponent(etiqUsuario, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addComponent(etiqID, javax.swing.GroupLayout.DEFAULT_SIZE, 130, Short.MAX_VALUE))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(campoID, javax.swing.GroupLayout.DEFAULT_SIZE, 621, Short.MAX_VALUE)
                                    .addComponent(campoUsuario, javax.swing.GroupLayout.DEFAULT_SIZE, 621, Short.MAX_VALUE)
                                    .addComponent(campoPassword1, javax.swing.GroupLayout.DEFAULT_SIZE, 621, Short.MAX_VALUE)
                                    .addComponent(campoPassword2, javax.swing.GroupLayout.DEFAULT_SIZE, 621, Short.MAX_VALUE)
                                    .addComponent(campoNombre, javax.swing.GroupLayout.DEFAULT_SIZE, 621, Short.MAX_VALUE)
                                    .addComponent(campoNIF, javax.swing.GroupLayout.DEFAULT_SIZE, 621, Short.MAX_VALUE)
                                    .addComponent(campoCorreo, javax.swing.GroupLayout.DEFAULT_SIZE, 621, Short.MAX_VALUE)
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(botonGuardar, javax.swing.GroupLayout.PREFERRED_SIZE, 156, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(botonBorrar, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 77, Short.MAX_VALUE)
                                        .addComponent(botonLimpiar, javax.swing.GroupLayout.PREFERRED_SIZE, 138, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(botonCancelar, javax.swing.GroupLayout.PREFERRED_SIZE, 84, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addGap(4, 4, 4))
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(opcionSi)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                        .addComponent(opcionNo)))))
                        .addContainerGap())
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(etiqPassword2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGap(667, 667, 667))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(etiqNombre, javax.swing.GroupLayout.DEFAULT_SIZE, 104, Short.MAX_VALUE)
                        .addGap(667, 667, 667))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(etiqNIF, javax.swing.GroupLayout.DEFAULT_SIZE, 104, Short.MAX_VALUE)
                        .addGap(667, 667, 667))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(etiqLabel, javax.swing.GroupLayout.DEFAULT_SIZE, 104, Short.MAX_VALUE)
                        .addGap(667, 667, 667))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(etiqAdmin, javax.swing.GroupLayout.DEFAULT_SIZE, 104, Short.MAX_VALUE)
                        .addGap(667, 667, 667))))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(etiqTitulo, javax.swing.GroupLayout.PREFERRED_SIZE, 36, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(etiqID)
                    .addComponent(campoID, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqUsuario)
                    .addComponent(campoUsuario, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqPassword1, javax.swing.GroupLayout.PREFERRED_SIZE, 14, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(campoPassword1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqPassword2)
                    .addComponent(campoPassword2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqNombre)
                    .addComponent(campoNombre, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqNIF)
                    .addComponent(campoNIF, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqLabel)
                    .addComponent(campoCorreo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(etiqAdmin)
                    .addComponent(opcionSi)
                    .addComponent(opcionNo))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(botonGuardar)
                    .addComponent(botonLimpiar)
                    .addComponent(botonCancelar)
                    .addComponent(botonBorrar))
                .addContainerGap(156, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void campoPassword2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoPassword2ActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoPassword2ActionPerformed

    private void campoUsuarioActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoUsuarioActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoUsuarioActionPerformed

    private void campoPassword1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoPassword1ActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoPassword1ActionPerformed

    private void campoIDActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoIDActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoIDActionPerformed

    private void campoNombreActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoNombreActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoNombreActionPerformed

    private void campoNIFActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoNIFActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoNIFActionPerformed

    private void campoCorreoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_campoCorreoActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_campoCorreoActionPerformed

    private void opcionSiActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_opcionSiActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_opcionSiActionPerformed


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton botonBorrar;
    private javax.swing.JButton botonCancelar;
    private javax.swing.JButton botonGuardar;
    private javax.swing.JButton botonLimpiar;
    private javax.swing.JTextField campoCorreo;
    private javax.swing.JTextField campoID;
    private javax.swing.JTextField campoNIF;
    private javax.swing.JTextField campoNombre;
    private javax.swing.JTextField campoPassword1;
    private javax.swing.JTextField campoPassword2;
    private javax.swing.JTextField campoUsuario;
    private javax.swing.JLabel etiqAdmin;
    private javax.swing.JLabel etiqID;
    private javax.swing.JLabel etiqLabel;
    private javax.swing.JLabel etiqNIF;
    private javax.swing.JLabel etiqNombre;
    private javax.swing.JLabel etiqPassword1;
    private javax.swing.JLabel etiqPassword2;
    private javax.swing.JLabel etiqTitulo;
    private javax.swing.JLabel etiqUsuario;
    private javax.swing.JRadioButton opcionNo;
    private javax.swing.JRadioButton opcionSi;
    private javax.swing.ButtonGroup opcionesAdmin;
    // End of variables declaration//GEN-END:variables

}
