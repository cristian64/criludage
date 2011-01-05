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
    public partial class FormVerEmpleado : UserControl
    {
        private Empleado empleado;

        /// <summary>
        /// Crea un nuevo UserControl que muestra el empleado indicado.
        /// </summary>
        /// <param name="empleado">Empleado que se va a cargar.</param>
        public FormVerEmpleado(Empleado empleado)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            CargarEmpleado(empleado);
        }

        /// <summary>
        /// Carga un empleado en el UserControl.
        /// </summary>
        /// <param name="empleado">Empleado que se va a cargar.</param>
        public void CargarEmpleado(Empleado empleado)
        {
            this.empleado = empleado;
            textEditId.Text = empleado.Id.ToString();
            textEditUsuario.Text = empleado.Usuario;
            textEditNombre.Text = empleado.Nombre;
            textEditNif.Text = empleado.Nif;
            textEditCorreoElectronico.Text = empleado.CorreoElectronico;
            radioGroupAdministrador.SelectedIndex = empleado.Administrador ? 1 : 0;
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
                    FormBase.GetInstancia().FormVerEmpleados.EliminarEmpleado(empleado);
                    FormBase.GetInstancia().MostrarNinguno();
                    FormBase.GetInstancia().MostrarAnterior();
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

        private void simpleButtonEditarEmpleado_Click(object sender, EventArgs e)
        {
            FormBase.GetInstancia().MostrarMensaje("Editando: " + empleado.Usuario, ""); // TODO:
        }
    }
}
