using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Aplicación_de_Escritorio
{
    public partial class FormLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormLogin()
        {
            InitializeComponent();
            dropDownButtonTipoAplicacion_Click(null, null);
        }

        private void iniciarSesion()
        {
            dxErrorProvider.SetError(textEditUsuario, "");
            dxErrorProvider.SetError(textEditContrasena, "");

            Empleado empleado = Empleado.Obtener(textEditUsuario.Text);
            if (empleado == null)
            {
                dxErrorProvider.SetError(textEditUsuario, "Nombre de usuario incorrecto");
                textEditUsuario.Focus();
                textEditUsuario.SelectAll();
                return;
            }

            if (!empleado.Contrasena.Equals(Program.Sha1(textEditContrasena.Text)))
            {
                dxErrorProvider.SetError(textEditContrasena, "Contraseña incorrecta");
                textEditContrasena.Focus();
                textEditContrasena.SelectAll();
                return;
            }

            Program.EmpleadoIdentificado = empleado;
            Close();
        }

        private void barButtonItemSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void textEditUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return || e.KeyChar == (char) Keys.Enter)
                iniciarSesion();
        }

        private void textEditContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
                iniciarSesion();
        }

        private void barButtonItemDesguace_ItemClick(object sender, ItemClickEventArgs e)
        {
            dropDownButtonTipoAplicacion.Text = "Desguace";
            dropDownButtonTipoAplicacion.Image = barButtonItemDesguace.Glyph;
            Program.TipoAplicacion = Program.TiposAplicacion.DESGUACE;
        }

        private void barButtonItemTaller_ItemClick(object sender, ItemClickEventArgs e)
        {
            dropDownButtonTipoAplicacion.Text = "Taller";
            dropDownButtonTipoAplicacion.Image = barButtonItemTaller.Glyph;
            Program.TipoAplicacion = Program.TiposAplicacion.TALLER;
        }

        private void dropDownButtonTipoAplicacion_Click(object sender, EventArgs e)
        {
            if (dropDownButtonTipoAplicacion.Text.Equals("Taller"))
            {
                barButtonItemDesguace_ItemClick(null, null);
            }
            else
            {
                barButtonItemTaller_ItemClick(null, null);
            }
        }

        private void simpleButtonIniciarSesion_Click(object sender, EventArgs e)
        {
            iniciarSesion();
        }
    }
}