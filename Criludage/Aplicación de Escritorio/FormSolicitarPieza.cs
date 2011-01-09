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
    public partial class FormSolicitarPieza : UserControl
    {
        public FormSolicitarPieza()
        {
            InitializeComponent();

            // Hace que el UserControl se ajuste al padre que lo contiene; es decir, al formulario base.
            Dock = DockStyle.Fill;

            // Se rellena el ComboBox con los posibles valores del enumerado.
            foreach (SGC.ENEstadosPieza item in Enum.GetValues(typeof(SGC.ENEstadosPieza)))
                comboBoxEditEstado.Properties.Items.Add(item);

            // Se limpia el formulario.
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            // La fecha de entrega unos días más tarde del día actual.
            dateEditFechaEntrega.DateTime = DateTime.Now.AddDays(7);
            dateEditFechaRespuesta.DateTime = DateTime.Now.Add(new TimeSpan(0, 5, 0));

            dxErrorProvider.SetError(dateEditFechaEntrega, "");
            dxErrorProvider.SetError(dateEditFechaRespuesta, "");
            
            // El resto de valores se establecen por defecto.
            calcEditPrecio.Value = new Decimal(0.0f);
            comboBoxEditEstado.Text = comboBoxEditEstado.Properties.Items[0].ToString();
            memoEditDescripcion.Text = "";
            memoEditInformacionAdicional.Text = "";
            radioGroupNegociado.SelectedIndex = 0;
        }

        private void simpleButtonEnviarSolicitud_Click(object sender, EventArgs e)
        {
            bool correcto = true;

            dxErrorProvider.SetError(dateEditFechaEntrega, "");
            dxErrorProvider.SetError(dateEditFechaRespuesta, "");

            if (DateTime.Now > dateEditFechaEntrega.DateTime)
            {
                dxErrorProvider.SetError(dateEditFechaEntrega, "La fecha de entrega debe ser posterior a la fecha actual");
                correcto = false;
            }

            if (DateTime.Now > dateEditFechaRespuesta.DateTime)
            {
                dxErrorProvider.SetError(dateEditFechaRespuesta, "La fecha de respuesta debe ser posterior a la fecha actual");
                correcto = false;
            }

            if (correcto)
            {
                Solicitud solicitud = new Solicitud();
                solicitud.Id = new Random(DateTime.Now.Millisecond).Next();
                solicitud.IdCliente = Program.ClienteIdentificado.Id;
                solicitud.Descripcion = memoEditDescripcion.Text;
                solicitud.NegociadoAutomatico = radioGroupNegociado.SelectedIndex == 1;
                try
                {
                    solicitud.Estado = (SGC.ENEstadosPieza)Enum.Parse(typeof(SGC.ENEstadosPieza), comboBoxEditEstado.SelectedItem.ToString());
                }
                catch (Exception)
                {
                    solicitud.Estado = SGC.ENEstadosPieza.USADA;
                }
                solicitud.Fecha = DateTime.Now;
                solicitud.FechaEntrega = dateEditFechaEntrega.DateTime;
                solicitud.FechaRespuesta = dateEditFechaRespuesta.DateTime;
                solicitud.PrecioMax = (float)calcEditPrecio.Value;
                solicitud.IdEmpleado = Program.EmpleadoIdentificado.Id;
                solicitud.InformacionAdicional = memoEditInformacionAdicional.Text;

                // Se envía la solicitud al servidor.
                solicitud.Id = Program.InterfazRemota.SolicitarPieza(solicitud.ENSolicitud);
                if (solicitud.Id > 0)
                {
                    // Se guarda la solicitud en la base de datos.
                    if (solicitud.Guardar())
                    {
                        // Si todo ha ido bien, se inserta la solicitud en el GridView y pasamos a ver la solicitud.
                        FormBase.Instancia.MostrarNinguno();
                        FormBase.Instancia.FormVerSolicitudes.ProcesarSolicitud(solicitud);
                        FormBase.Instancia.FormVerSolicitudes.SeleccionarSolicitud(solicitud);
                        FormBase.Instancia.MostrarVerSolicitudes();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al guardar la solicitud de la base de datos.", "Guardando solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al enviar la solicitud al servidor.", "Guardando solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            FormBase.Instancia.MostrarNinguno();
            FormBase.Instancia.MostrarAnterior();
        }

        private void simpleButtonLimpiarFormulario_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }
    }
}
