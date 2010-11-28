using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;

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

            // Aspectos de diseño que no se permiten desde la vista de diseño.
            Dock = DockStyle.Fill;
            comboBoxEstado.Items.Add(EstadosPieza.USADA);
            comboBoxEstado.Text = comboBoxEstado.Items[0].ToString();
            comboBoxEstado.Items.Add(EstadosPieza.NO_FUNCIONA);
            comboBoxEstado.Items.Add(EstadosPieza.MUY_USADA);
            comboBoxEstado.Items.Add(EstadosPieza.NUEVA);
            comboBoxEstado.Items.Add(EstadosPieza.POCO_USADA);
            textBoxId.Text = "" + (++ContadorSolicitudes);
            dateTimePickerFechaEntrega.Value = dateTimePickerFechaEntrega.Value.AddDays(4);
        }

        private void buttonEnviarSolicitud_Click(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();
            solicitud.Id = int.Parse(textBoxId.Text);
            solicitud.Descripcion = textBoxDescripcion.Text;
            solicitud.NegociadoAutomatico = radioButtonAutomatico.Checked;
            solicitud.Estado = EstadosPieza.USADA;
            solicitud.Fecha = dateTimePickerFecha.Value;
            solicitud.FechaEntrega = dateTimePickerFechaEntrega.Value;
            solicitud.PrecioMax = (float) numericUpDownPrecio.Value;

            Productor productor = new Productor("tcp://192.168.0.192:61616", "pollaca");
            productor.Enviar(solicitud);

            formBase.mostrarVerSolicitudes();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            formBase.mostrarVerSolicitudes();
        }
    }
}
