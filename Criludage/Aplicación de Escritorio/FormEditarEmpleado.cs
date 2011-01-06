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
    public partial class FormEditarEmpleado : UserControl
    {
        private Empleado empleado;

        public FormEditarEmpleado(Empleado empleado)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            CargarEmpleado(empleado);
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
                    empleado.Contrasena = Program.Sha1(textEditContrasena.Text);
                empleado.Foto = pictureEditFoto.Image;

                if (empleado.Guardar())
                {
                    FormBase.Instancia.MostrarNinguno();
                    FormBase.Instancia.FormVerEmpleados.ProcesarEmpleado(empleado);
                    FormBase.Instancia.FormVerEmpleados.SeleccionarEmpleado(empleado);
                    FormBase.Instancia.MostrarVerEmpleados();
                    //TODO: mismo problema que al eliminar. si estaba el empleado cargado en otra
                    // ventana del historial de navegacion, hay problemas
                    //tambien hay que actualizar sus campos en el datagridview, en vez de añadirlo otra vez
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
                if (empleado.Eliminar())
                {
                    FormBase.Instancia.FormVerEmpleados.EliminarEmpleado(empleado);
                    FormBase.Instancia.MostrarNinguno();
                    FormBase.Instancia.MostrarAnterior();
                    //TODO: eliminar el nombre del usuario en el dataTable de las solicitudes y en el datatable de las propuestas
                    //porque hasta que no se recargue desde la base de datos va a estar mal
                    //TODO: ¿y si el empleado estaba cargado en otro formulario e intento eliminarlo en ese otro formulario tambien?
                    //hay que recorrer todo el historial de navegación y eliminar los formularios que tengan el empleado cargado...
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al eliminar el empleado de la base de datos.", "Eliminando empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
