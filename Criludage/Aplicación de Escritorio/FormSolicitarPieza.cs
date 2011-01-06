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

            // Se establece el nombre del empleado identificado.
            hyperLinkEditEmpleado.Text = Program.EmpleadoIdentificado.Nombre;
        }

        private void limpiarFormulario()
        {
            // La fecha de entrega unos días más tarde del día actual.
            dateEditFechaEntrega.DateTime = DateTime.Now.AddDays(1);

            dxErrorProvider.SetError(dateEditFechaEntrega, "");
            
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

            if (DateTime.Now > dateEditFechaEntrega.DateTime) //TODO: tener en cuenta la hora tambien, no solo el dia
            {
                dxErrorProvider.SetError(dateEditFechaEntrega, "La fecha debe ser posterior a la fecha actual");
                correcto = false;
            }
            else
            {
                dxErrorProvider.SetError(dateEditFechaEntrega, "");
            }

            if (correcto)
            {
                Solicitud solicitud = new Solicitud();
                solicitud.Id = new Random(DateTime.Now.Millisecond).Next();
                solicitud.IdCliente = 0; // TODO: establecer el identificador del cliente actual
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
                solicitud.FechaEntrega = dateEditFechaEntrega.DateTime; // TODO: hay que tener en cuenta timeEditFechaEntrega
                solicitud.PrecioMax = (float)calcEditPrecio.Value;
                solicitud.IdEmpleado = Program.EmpleadoIdentificado.Id;
                solicitud.InformacionAdicional = memoEditInformacionAdicional.Text;

                // Se envía la solicitud al servidor.
                solicitud.Id = FormBase.GetInstancia().InterfazRemota.solicitarPieza(solicitud.ENSolicitud);
                if (solicitud.Id > 0)
                {
                    // Se guarda la solicitud en la base de datos.
                    if (solicitud.Guardar())
                    {
                        // Si todo ha ido bien, se inserta la solicitud en el GridView y pasamos a ver la solicitud.
                        FormBase.GetInstancia().FormVerSolicitudes.ProcesarSolicitud(solicitud);
                        FormBase.GetInstancia().MostrarVerSolicitudes();
                        limpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al guardar la solicitud de la base de datos.", "Guardando solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Se produjo un error al enviar la solicitud al servidor.", "Guardando solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            FormBase.GetInstancia().MostrarAnterior();
        }

        private void hyperLinkEditEmpleado_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            FormBase.GetInstancia().MostrarVerEmpleado(Program.EmpleadoIdentificado);
        }

        private void simpleButtonLimpiarFormulario_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }
    }
}
