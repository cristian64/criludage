using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Aplicación_de_Escritorio
{
    public partial class FormVerSolicitud : UserControl
    {
        private Solicitud solicitud;
        private Empleado empleado;

        public FormVerSolicitud(Solicitud solicitud)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            CargarSolicitud(solicitud);

            // Mostramos y ocultamos según el tipo de aplicación.
            if (Program.TipoAplicacion == Program.TiposAplicacion.TALLER)
            {

            }
            else
            {

            }
        }

        public void CargarSolicitud(Solicitud solicitud)
        {
            this.solicitud = solicitud;
            empleado = Empleado.Obtener(solicitud.IdEmpleado);

            textEditId.Text = solicitud.Id.ToString();
            textEditIdCliente.Text = solicitud.IdCliente.ToString();
            textEditEstado.Text = solicitud.Estado.ToString();
            textEditPrecio.Text = solicitud.PrecioMax.ToString();
            memoEditDescripcion.Text = solicitud.Descripcion;
            memoEditInformacionAdicional.Text = solicitud.InformacionAdicional;
            if (empleado != null)
            {
                hyperLinkEditEmpleado.Text = empleado.Nombre;
            }
            else
            {
                hyperLinkEditEmpleado.Text = "";
                hyperLinkEditEmpleado.Visible = false;
            }
            dateEditFecha.DateTime = solicitud.Fecha;
            dateEditFechaEntrega.DateTime = solicitud.FechaEntrega;
            radioGroupNegociado.SelectedIndex = solicitud.NegociadoAutomatico ? 1 : 0;

            ArrayList propuestas = solicitud.ObtenerPropuestas();
            foreach (Propuesta i in propuestas)
            {
                //ProcesarPropuesta(i);
            }
        }

        private void hyperLinkEditCliente_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            FormBase.GetInstancia().MostrarMensaje("Viendo detalles del cliente nº" + solicitud.IdCliente, "Módulo no implementado");
        }

        private void hyperLinkEditEmpleado_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            if (empleado != null)
                FormBase.GetInstancia().MostrarVerEmpleado(empleado);
        }

        private void simpleButtonProponerPropuesta_Click(object sender, EventArgs e)
        {
            FormBase.GetInstancia().MostrarMensaje("Proponiendo propuesta a la solicitud nº " + solicitud.Id, "Módulo no implementado");
        }
    }
}
