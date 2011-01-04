using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Aplicación_de_Taller
{
    public partial class FormLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void entrar()
        {
            dxErrorProvider.SetError(textEditUsuario, "");
            dxErrorProvider.SetError(textEditContrasena, "");

            Empleado empleado = Empleado.Obtener(textEditUsuario.Text);
            if (empleado == null)
            {
                dxErrorProvider.SetError(textEditUsuario, "Nombre de usuario incorrecto");
                textEditUsuario.Focus();
                textEditContrasena.SelectAll();
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

        private void simpleButtonEntrar_Click(object sender, EventArgs e)
        {
            entrar();
        }

        private void barButtonItemSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void textEditUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return || e.KeyChar == (char) Keys.Enter)
                entrar();
        }

        private void textEditContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
                entrar();
        }

        private void FormLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("FormLogin...");
        }

        private void clientPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Console.WriteLine("clientPanel");
        }
    }
}