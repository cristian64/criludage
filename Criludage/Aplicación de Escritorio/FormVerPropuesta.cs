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

            textEditId.Text = propuesta.ToString();
            textEditIdDesguace.Text = propuesta.IdDesguace.ToString();
            textEditIdSolicitud.Text = propuesta.IdSolicitud.ToString();
            textEditIdDesguace.Text = propuesta.IdDesguace.ToString();
            textEditEstado.Text = propuesta.Estado.ToString();
            textEditPrecio.Text = propuesta.Precio.ToString();
            memoEditDescripcion.Text = propuesta.Descripcion;
            memoEditInformacionAdicional.Text = propuesta.InformacionAdicional;
            dateEditFechaEntrega.DateTime = solicitud.FechaEntrega;
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
            FormBase.Instancia.MostrarMensaje("Viendo detalles del desguace nº" + propuesta.IdDesguace, "Módulo no implementado");
        }
    }
}
