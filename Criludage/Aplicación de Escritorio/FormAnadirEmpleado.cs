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
        /// <summary>
        /// Constructor sobrecargado para indicar si es un formulario para añadir empleados o administradores.
        /// </summary>
        /// <param name="administrador">Indica si el formulario se carga para añadir empleados o administradores.</param>
        public FormAnadirEmpleado(bool administrador)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Modo(administrador);
        }

        /// <summary>
        /// Indica si el formulario se carga para añadir empleados o administradores.
        /// Si es un administrador, se cambia el título a "Añadir administrador" y se selecciona "administrador".
        /// </summary>
        public void Modo(bool administrador)
        {
            if (administrador)
            {
                labelControlTitulo.Text = simpleButtonAnadirEmpleado.Text = "Añadir administrador";
                radioGroupAdministrador.SelectedIndex = 1;
            }
            else
            {
                labelControlTitulo.Text = simpleButtonAnadirEmpleado.Text = "Añadir empleado";
                radioGroupAdministrador.SelectedIndex = 0;
            }
        }

        private void limpiarFormulario()
        {
            textEditNombre.Text = "";
            textEditUsuario.Text = "";
            textEditNif.Text = "";
            textEditCorreoElectronico.Text = "";
            radioGroupAdministrador.SelectedIndex = labelControlTitulo.Text.Equals("Añadir empleado") ? 0 : 1;
            textEditContrasena.Text = "";
            textEditContrasena2.Text = "";
            pictureEditFoto.Image = null;
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

            dxErrorProvider.SetError(textEditUsuario, "");
            dxErrorProvider.SetError(textEditContrasena, "");
            dxErrorProvider.SetError(textEditContrasena2, "");

            if (textEditUsuario.Text.Length <= 3)
            {
                dxErrorProvider.SetError(textEditUsuario, "El nombre de usuario debe tener una longitud de 4 o más caracteres");
                textEditUsuario.Focus();
                correcto = false;
            }

            if (Empleado.Obtener(textEditUsuario.Text) != null)
            {
                dxErrorProvider.SetError(textEditUsuario, "El nombre de usuario ya está siendo utilizado");
                textEditUsuario.Focus();
                correcto = false;
            }

            if (textEditContrasena.Text.Length == 0)
            {
                dxErrorProvider.SetError(textEditContrasena, "Debe introducir una contraseña");
                if (correcto)
                    textEditContrasena.Focus();
                correcto = false;
            }

            if (!textEditContrasena.Text.Equals(textEditContrasena2.Text))
            {
                dxErrorProvider.SetError(textEditContrasena, "Las contraseñas no coinciden");
                dxErrorProvider.SetError(textEditContrasena2, "Las contraseñas no coinciden");
                if (correcto)
                    textEditContrasena.Focus();
                correcto = false;
            }

            if (correcto)
            {
                Empleado empleado = new Empleado();
                empleado.Nombre = textEditNombre.Text;
                empleado.Usuario = textEditUsuario.Text;
                empleado.Nif = textEditNif.Text;
                empleado.CorreoElectronico = textEditCorreoElectronico.Text;
                empleado.Administrador = radioGroupAdministrador.SelectedIndex == 1 ? true : false;
                empleado.Contrasena = Sha1.ComputeHash(textEditContrasena.Text);
                empleado.Foto = pictureEditFoto.Image;

                if (empleado.Guardar())
                {
                    FormBase.Instancia.MostrarNinguno();
                    FormBase.Instancia.FormVerEmpleados.ProcesarEmpleado(empleado);
                    FormBase.Instancia.FormVerEmpleados.SeleccionarEmpleado(empleado);
                    FormBase.Instancia.MostrarVerEmpleados();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al guardar el empleado de la base de datos.", "Guardando empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            FormBase.Instancia.MostrarNinguno();
            FormBase.Instancia.MostrarAnterior();
        }

        private void simpleButtonLimpiarFormulario_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void pictureEditElegirFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialogFoto.ShowDialog() == DialogResult.OK)
            {
                pictureEditFoto.Image = new Bitmap(openFileDialogFoto.FileName);
            }
        }

        private void pictureEditQuitarFoto_Click(object sender, EventArgs e)
        {
            pictureEditFoto.Image = null;
        }
    }
}
