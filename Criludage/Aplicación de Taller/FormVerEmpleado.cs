using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicación_de_Taller
{
    public partial class FormVerEmpleado : UserControl
    {
        private Empleado empleado;

        public FormVerEmpleado()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

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
            if (MessageBox.Show("Se va a eliminar el empleado. ¿Desea continuar?", "Eliminando empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (empleado.Eliminar())
                {
                    FormBase.GetInstancia().FormVerEmpleados.EliminarEmpleado(empleado);
                    FormBase.GetInstancia().MostrarAnterior();
                    //TODO: eliminar el nombre del usuario en el dataTable de las solicitudes y en el datatable de las propuestas
                    //porque hasta que no se recargue desde la base de datos va a estar mal
                }
                else
                {
                    MessageBox.Show("Se produjo un error al eliminar el empleado de la base de datos.", "Eliminando empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButtonEditarEmpleado_Click(object sender, EventArgs e)
        {
            FormBase.GetInstancia().MostrarMensaje("Editando: " + empleado.Usuario, ""); // TODO:
        }
    }
}
