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
    public partial class FormSolicitarPieza : UserControl
    {
        public FormSolicitarPieza()
        {
            InitializeComponent();

            // Hace que el UserControl se ajuste al padre que lo contiene; es decir, al formulario base.
            Dock = DockStyle.Fill;

            // Se rellena el ComboBox con los posibles valores del enumerado y se selecciona el primero.
            foreach (SGC.ENEstadosPieza item in Enum.GetValues(typeof(SGC.ENEstadosPieza)))
                comboBoxEditEstado.Properties.Items.Add(item);
            comboBoxEditEstado.Text = comboBoxEditEstado.Properties.Items[0].ToString();

            // La fecha de entrega unos días más tarde del día actual.
            dateEditFechaEntrega.DateTime = DateTime.Now.AddDays(1);
            timeEditFechaEntrega.Time = DateTime.Now;

            // Se establece el nombre del empleado identificado.
            Empleado empleado = Empleado.Obtener(3); //TODO: usar el empleado que será una variable global en algún sitio
            hyperLinkEditEmpleado.Text = empleado.Nombre;
        }

        private void simpleButtonEnviarSolicitud_Click(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();
            solicitud.Id = new Random(DateTime.Now.Millisecond).Next();
            solicitud.Descripcion = memoEditDescripcion.Text;
            solicitud.NegociadoAutomatico = radioGroupNegociado.SelectedIndex == 1;
            try
            {
                solicitud.Estado = (SGC.ENEstadosPieza) Enum.Parse(typeof(SGC.ENEstadosPieza), comboBoxEditEstado.SelectedItem.ToString());
            }
            catch (Exception)
            {
                FormBase.GetInstancia().MostrarMensaje("Casco por el enumerado", "Pongo USADA por defecto");
                solicitud.Estado = SGC.ENEstadosPieza.USADA;
            }
            solicitud.Fecha = DateTime.Now;
            solicitud.FechaEntrega = dateEditFechaEntrega.DateTime; // TODO: hay que tener en cuenta timeEditFechaEntrega
            solicitud.PrecioMax = (float) calcEditPrecio.Value;
            solicitud.IdEmpleado = 0; // TODO: empleado que este identificado actualmente
            solicitud.InformacionAdicional = memoEditInformacionAdicional.Text;

            FormBase.GetInstancia().InterfazRemota.solicitarPieza(solicitud.ENSolicitud);

            FormBase.GetInstancia().mostrarVerSolicitudes();
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            FormBase.GetInstancia().mostrarVerSolicitudes();
        }

        private void hyperLinkEditEmpleado_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            FormBase.GetInstancia().MostrarMensaje("Viendo empleado", "Todavía no ha sido implementado este módulo"); //TODO
        }
    }
}
