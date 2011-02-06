using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Biblioteca_Común;

namespace Aplicación_de_Escritorio
{
    public partial class FormEditarEmpleado : UserControl
    {
        private Empleado empleado;

        public FormEditarEmpleado(Empleado empleado)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            CargarEmpleado(empleado);

            simpleButtonEliminarEmpleado.Visible = Program.EmpleadoIdentificado.Administrador;
        }

        /// <summary>
        /// Carga el empleado en el formulario.
        /// </summary>
        /// <param name="empleado"></param>
        public void CargarEmpleado(Empleado empleado)
        {
            this.empleado = empleado;
            textEditId.Text = empleado.Id.ToString();
            textEditUsuario.Text = empleado.Usuario;
            textEditNombre.Text = empleado.Nombre;
            textEditNif.Text = empleado.Nif;
            textEditContrasena.Text = textEditContrasena2.Text = "";
            textEditCorreoElectronico.Text = empleado.CorreoElectronico;
            radioGroupAdministrador.SelectedIndex = empleado.Administrador ? 1 : 0;
            pictureEditFoto.Image = empleado.Foto;
            dxErrorProvider.SetError(textEditUsuario, "");
            dxErrorProvider.SetError(textEditContrasena, "");
            dxErrorProvider.SetError(textEditContrasena2, "");

            // Impedimos que el usuario identificado modifique sus privilegios y su nombre.
            radioGroupAdministrador.Properties.ReadOnly = empleado.Id == Program.EmpleadoIdentificado.Id;
        }

        /// <summary>
        /// Si un empleado ha sido modificado y es el empleado que está ahora mostrándose, se actualiza el formulario.
        /// </summary>
        /// <param name="empleado">Empleado que se ha modificado.</param>
        /// <param name="eliminado">Indica si se ha eliminado o sólo modificado.</param>
        public void ActualizarEmpleado(Empleado empleado, bool eliminado)
        {
            if (this.empleado.Usuario.Equals(empleado.Usuario))
            {
                if (eliminado)
                {
                    textEditUsuario.Text += " (HA SIDO ELIMINADO)";
                    simpleButtonDescartarCambios.Enabled = false;
                    simpleButtonEliminarEmpleado.Enabled = false;
                    simpleButtonGuardarCambios.Enabled = false;
                }
                else
                {
                    CargarEmpleado(empleado);
                }
            }
        }

        private void simpleButtonGuardarCambios_Click(object sender, EventArgs e)
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

            Empleado anterior = Empleado.Obtener(textEditUsuario.Text);
            if (anterior != null && anterior.Id != empleado.Id)
            {
                dxErrorProvider.SetError(textEditUsuario, "El nombre de usuario ya está siendo utilizado");
                textEditUsuario.Focus();
                correcto = false;
            }

            // Si no se ha introducido nada en las contraseñas, significa que no se quieren cambiar.
            if (textEditContrasena.Text.Length != 0 || textEditContrasena2.Text.Length != 0)
            {
                if (!textEditContrasena.Text.Equals(textEditContrasena2.Text))
                {
                    dxErrorProvider.SetError(textEditContrasena, "Las contraseñas no coinciden");
                    dxErrorProvider.SetError(textEditContrasena2, "Las contraseñas no coinciden");
                    if (correcto)
                        textEditContrasena.Focus();
                    correcto = false;
                }
            }

            if (correcto)
            {
                empleado.Nombre = textEditNombre.Text;
                empleado.Usuario = textEditUsuario.Text;
                empleado.Nif = textEditNif.Text;
                empleado.CorreoElectronico = textEditCorreoElectronico.Text;
                empleado.Administrador = radioGroupAdministrador.SelectedIndex == 1 ? true : false;
                if (textEditContrasena.Text.Length > 0)
                    empleado.Contrasena = Sha1.ComputeHash(textEditContrasena.Text);
                empleado.Foto = pictureEditFoto.Image;

                if (empleado.Guardar())
                {
                    FormBase.Instancia.MostrarNinguno();
                    FormBase.Instancia.FormVerEmpleados.EliminarEmpleado(empleado);
                    FormBase.Instancia.FormVerEmpleados.ProcesarEmpleado(empleado);
                    FormBase.Instancia.FormVerEmpleados.SeleccionarEmpleado(empleado);
                    FormBase.Instancia.MostrarVerEmpleados();
                    FormBase.Instancia.ActualizarEmpleado(empleado, false);

                    Registro.WriteLine("Editado un empleado: " + empleado.Id + " (" + empleado.Usuario + ")");
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al guardar el empleado de la base de datos.", "Guardando empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButtonDescartarCambios_Click(object sender, EventArgs e)
        {
            CargarEmpleado(empleado);
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            FormBase.Instancia.MostrarNinguno();
            FormBase.Instancia.MostrarAnterior();
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

        private void simpleButtonEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (Program.EmpleadoIdentificado.Id == empleado.Id)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("No puedes eliminarte a ti mismo.", "Eliminando empleado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (DevExpress.XtraEditors.XtraMessageBox.Show("Se va a eliminar el empleado. ¿Desea continuar?", "Eliminando empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = empleado.Id;
                if (empleado.Eliminar())
                {
                    FormBase.Instancia.FormVerEmpleados.EliminarEmpleado(empleado);
                    FormBase.Instancia.MostrarNinguno();
                    FormBase.Instancia.MostrarAnterior();
                    FormBase.Instancia.ActualizarEmpleado(empleado, true);

                    Registro.WriteLine("Eliminado un empleado: " + id + " (" + empleado.Usuario + ")");
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al eliminar el empleado de la base de datos.", "Eliminando empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureEditFoto_Click(object sender, EventArgs e)
        {
            if (pictureEditFoto.Image != null)
                new FormVerImagen(pictureEditFoto.Image).Show();
        }
    }
}
