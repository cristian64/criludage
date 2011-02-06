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
            pictureEditFoto.Image = empleado.Foto;
        }

        private void pictureEditFoto_Click(object sender, EventArgs e)
        {
            if (pictureEditFoto.Image != null)
                new FormVerImagen(pictureEditFoto.Image).Show();
        }
    }
}
