using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicación_de_Escritorio
{
    public partial class FormAnadirEmpleado : UserControl
    {
        public FormAnadirEmpleado()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Indica si el empleado que se va a crear es un administrador o no.
        /// </summary>
        public void Modo(bool administrador)
        {
            radioGroupAdministrador.SelectedIndex = administrador ? 1 : 0;
        }

        private void limpiarFormulario()
        {
            textEditNombre.Text = "";
            textEditUsuario.Text = "";
            textEditNif.Text = "";
            textEditCorreoElectronico.Text = "";
            radioGroupAdministrador.SelectedIndex = 0;
            textEditContrasena.Text = "";
            textEditContrasena2.Text = "";
            dxErrorProvider.SetError(textEditNombre, "");
            dxErrorProvider.SetError(textEditUsuario, "");
            dxErrorProvider.SetError(textEditNif, "");
            dxErrorProvider.SetError(textEditCorreoElectronico, "");
            dxErrorProvider.SetError(radioGroupAdministrador, "");
            dxErrorProvider.SetError(textEditContrasena, "");
            dxErrorProvider.SetError(textEditContrasena2, "");
        }

        private void simpleButtonAnadirEmpleado_Click(object sender, EventArgs e)
        {
            bool correcto = true;

            if (Empleado.Obtener(textEditUsuario.Text) != null)
            {
                dxErrorProvider.SetError(textEditUsuario, "El nombre de usuario ya está siendo utilizado");
                textEditUsuario.Focus();
                correcto = false;
            }
            else
            {
                dxErrorProvider.SetError(textEditUsuario, "");
            }

            if (!textEditContrasena.Text.Equals(textEditContrasena2.Text))
            {
                dxErrorProvider.SetError(textEditContrasena, "Las contraseñas no coinciden");
                dxErrorProvider.SetError(textEditContrasena2, "Las contraseñas no coinciden");
                if (correcto)
                    textEditContrasena.Focus();
                correcto = false;
            }
            else
            {
                dxErrorProvider.SetError(textEditContrasena, "");
                dxErrorProvider.SetError(textEditContrasena2, "");
            }

            if (correcto)
            {
                Empleado empleado = new Empleado();
                empleado.Nombre = textEditNombre.Text;
                empleado.Usuario = textEditUsuario.Text;
                empleado.Nif = textEditNif.Text;
                empleado.CorreoElectronico = textEditCorreoElectronico.Text;
                empleado.Administrador = radioGroupAdministrador.SelectedIndex == 1 ? true : false;
                empleado.Contrasena = Program.Sha1(textEditContrasena.Text);
                FormBase.GetInstancia().MostrarMensaje(empleado.Contrasena, "");

                if (empleado.Guardar())
                {
                    limpiarFormulario();
                    FormBase.GetInstancia().FormVerEmpleados.ProcesarEmpleado(empleado);
                    FormBase.GetInstancia().FormVerEmpleados.SeleccionarEmpleado(empleado);
                    FormBase.GetInstancia().MostrarVerEmpleados();
                }
                else
                {
                    FormBase.GetInstancia().MostrarMensaje("ERROR AL GUARDAR: esto es chungo no deberia ocurrir!", ""); //TODO
                }
            }
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            FormBase.GetInstancia().MostrarAnterior();
        }

        private void simpleButtonLimpiarFormulario_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }
    }
}
