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
        private static int ContadorSolicitudes = 0;
        private FormBase formBase;

        public FormSolicitarPieza(FormBase formBase)
        {
            InitializeComponent();

            this.formBase = formBase;

            // Hace que el UserControl se ajuste al padre que lo contiene; es decir, al formulario base.
            Dock = DockStyle.Fill;

            // Se rellena el ComboBox con los posibles valores del enumerado y se selecciona el primero.
            foreach (SGC.ENEstadosPieza item in Enum.GetValues(typeof(SGC.ENEstadosPieza)))
                comboBoxEstado.Items.Add(item);
            comboBoxEstado.Text = comboBoxEstado.Items[0].ToString();

            // Se establece el día de entrega unos días más tarde.
            dateTimePickerFechaEntrega.Value = dateTimePickerFechaEntrega.Value.AddDays(4);

            // Contador de índices. Provisional...
            textBoxId.Text = "" + (++ContadorSolicitudes);            
        }

        private void buttonEnviarSolicitud_Click(object sender, EventArgs e)
        {
            SGC.ENSolicitud solicitud = new SGC.ENSolicitud();
            solicitud.Id = int.Parse(textBoxId.Text);
            solicitud.Descripcion = textBoxDescripcion.Text;
            solicitud.NegociadoAutomatico = radioButtonAutomatico.Checked;
            solicitud.Estado = (SGC.ENEstadosPieza) comboBoxEstado.SelectedItem;
            solicitud.Fecha = dateTimePickerFecha.Value;
            solicitud.FechaEntrega = dateTimePickerFechaEntrega.Value; // TODO: hay que tener en cuenta dateTimePickerHoraEntrega
            solicitud.PrecioMax = (float) numericUpDownPrecio.Value;

            SGC.InterfazRemota interfazRemota = new SGC.InterfazRemota();
            interfazRemota.solicitarPieza(solicitud, "nombre del usuario", "contraseña del usuario...");

            formBase.mostrarVerSolicitudes();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            formBase.mostrarVerSolicitudes();
        }
    }
}
