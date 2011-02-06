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
    public partial class FormVerPropuesta : UserControl
    {
        private Propuesta propuesta;
        private Solicitud solicitud;
        private Empleado empleado;

        public FormVerPropuesta(Propuesta propuesta)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            CargarPropuesta(propuesta);

            // Mostramos y ocultamos según el tipo de aplicación.
            if (Program.TipoAplicacion == Program.TiposAplicacion.DESGUACE)
            {
                // Se elimina la fila que indica el desguace (puesto que si somos el desguace, somos nosotros mismos).
                tableLayoutPanel1.RowStyles[2].Height = 0;
                tableLayoutPanel1.Controls.Remove(panel9);
                tableLayoutPanel1.Controls.Remove(panel5);

                labelControl12.Visible = simpleButtonConfirmarCompra.Visible = false;
            }
            else
            {
                tableLayoutPanel1.RowStyles[7].Height = 0;
                tableLayoutPanel1.Controls.Remove(panel10);
                tableLayoutPanel1.Controls.Remove(panel16);

                tableLayoutPanel1.RowStyles[8].Height = 0;
                tableLayoutPanel1.Controls.Remove(panel17);
                tableLayoutPanel1.Controls.Remove(panel18);
            }
        }

        /// <summary>
        /// Se carga una propuesta en el formulario.
        /// </summary>
        /// <param name="propuesta">Propuesta que se va a mostrar.</param>
        public void CargarPropuesta(Propuesta propuesta)
        {
            this.propuesta = propuesta;
            empleado = Empleado.Obtener(propuesta.IdEmpleado);
            solicitud = Solicitud.Obtener(propuesta.IdSolicitud);

            textEditId.Text = propuesta.Id.ToString();
            textEditIdDesguace.Text = propuesta.IdDesguace.ToString();
            textEditIdSolicitud.Text = propuesta.IdSolicitud.ToString();
            textEditIdDesguace.Text = propuesta.IdDesguace.ToString();
            textEditEstado.Text = propuesta.Estado.ToString();
            textEditPrecio.Text = propuesta.Precio.ToString();
            memoEditDescripcion.Text = propuesta.Descripcion;
            memoEditInformacionAdicional.Text = propuesta.InformacionAdicional;
            dateEditFechaEntrega.DateTime = propuesta.FechaEntrega;
            pictureEditFoto.Image = propuesta.Foto2;
            if (empleado != null)
            {
                hyperLinkEditEmpleado.Text = empleado.Nombre;
                hyperLinkEditEmpleado.Visible = true;
            }
            else
            {
                hyperLinkEditEmpleado.Text = "";
                hyperLinkEditEmpleado.Visible = false;
            }

            if (propuesta.Confirmada)
                simpleButtonConfirmarCompra.Enabled = false;
            else
                labelControl12.Visible = false;
        }

        /// <summary>
        /// Si un empleado ha sido modificado y es el empleado que realizó la propuesta, se actualiza la propuesta.
        /// </summary>
        /// <param name="empleado">Empleado que se ha modificado.</param>
        public void ActualizarEmpleado(Empleado empleado)
        {
            if (this.empleado != null && empleado.Usuario.Equals(this.empleado.Usuario))
            {
                CargarPropuesta(propuesta);
            }
        }

        /// <summary>
        /// Actualiza la propuesta si coincide con la propuesta que está actualmente cargada en el formulario.
        /// </summary>
        /// <param name="solicitud">Solicitud que se quiere actualizar.</param>
        public void ActualizarPropuesta(Propuesta propuesta)
        {
            if (this.propuesta.Id == propuesta.Id)
            {
                CargarPropuesta(propuesta);
            }
        }

        private void hyperLinkEditEmpleado_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            if (empleado != null)
                FormBase.Instancia.MostrarVerEmpleado(empleado);
        }

        private void hyperLinkEditSolicitud_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            FormBase.Instancia.MostrarVerSolicitud(solicitud);
        }

        private void hyperLinkEditDesguace_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            Desguace desguace = Desguace.Obtener(propuesta.IdDesguace);
            if (desguace != null)
                FormBase.Instancia.MostrarVerClienteDesguace(desguace);
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al cargar el desguace desde el servicio.", "Viendo desguace", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void simpleButtonConfirmarCompra_Click(object sender, EventArgs e)
        {
            if (Program.InterfazRemota.ConfirmarPropuesta(propuesta.ENPropuesta, Configuracion.Default.usuario, Configuracion.Default.contrasena))
            {
                if (propuesta.MarcarConfirmada())
                {
                    FormBase.Instancia.FormHistorialCompras.ProcesarPropuesta(propuesta);
                    FormBase.Instancia.ActualizarPropuesta(propuesta);
                    labelControl12.Visible = true;
                    simpleButtonConfirmarCompra.Enabled = false;
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se ha confirmado la compra correctamente. Se ha enviado un email al desguace.", "Confirmando compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (!propuesta.Confirmada)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al confirmar la compra.", "Confirmando compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureEditFoto_Click(object sender, EventArgs e)
        {
            if (pictureEditFoto.Image != null)
                new FormVerImagen(pictureEditFoto.Image).Show();
        }
    }
}
