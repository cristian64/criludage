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
    public partial class FormProponerPropuesta : UserControl
    {
        private Solicitud solicitud;
        public FormProponerPropuesta(Solicitud solicitud)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            // Se rellena el ComboBox con los posibles valores del enumerado.
            foreach (SGC.ENEstadosPieza item in Enum.GetValues(typeof(SGC.ENEstadosPieza)))
                comboBoxEditEstado.Properties.Items.Add(item);

            CargarSolicitud(solicitud);
        }

        /// <summary>
        /// Carga una solicitud en el formulario.
        /// </summary>
        /// <param name="solicitud">Solicitud a la que va referida la propuesta que se va a proponer.</param>
        public void CargarSolicitud(Solicitud solicitud)
        {
            limpiarFormulario();
            this.solicitud = solicitud;
            textEditIdSolicitud.Text = Convert.ToString(solicitud.Id);
        }

        private void limpiarFormulario()
        {
            // La fecha de entrega unos días más tarde del día actual.
            dateEditFechaEntrega.DateTime = DateTime.Now.AddDays(7);
            dxErrorProvider.SetError(dateEditFechaEntrega, "");

            // El resto de valores se establecen por defecto.
            textEditIdSolicitud.Text = "";
            calcEditPrecio.Value = new Decimal(0.0f);
            comboBoxEditEstado.Text = comboBoxEditEstado.Properties.Items[0].ToString();
            memoEditDescripcion.Text = "";
            memoEditInformacionAdicional.Text = "";
            pictureEditFoto.Image = null;
        }

        private void simpleButtonEnviarPropuesta_Click(object sender, EventArgs e)
        {
            bool correcto = true;

            dxErrorProvider.SetError(dateEditFechaEntrega, "");
            if (DateTime.Now > dateEditFechaEntrega.DateTime)
            {
                dxErrorProvider.SetError(dateEditFechaEntrega, "La fecha de entrega debe ser posterior a la fecha actual");
                correcto = false;
            }

            if (correcto)
            {
                Propuesta propuesta = new Propuesta();
                propuesta.IdDesguace = Program.DesguaceIdentificado.Id;
                propuesta.IdEmpleado = Program.EmpleadoIdentificado.Id;
                propuesta.IdSolicitud = solicitud.Id;
                propuesta.Descripcion = memoEditDescripcion.Text;
                propuesta.InformacionAdicional = memoEditInformacionAdicional.Text;
                propuesta.Foto2 = pictureEditFoto.Image;
                propuesta.FechaEntrega = dateEditFechaEntrega.DateTime;
                propuesta.Precio = (float)calcEditPrecio.Value;
                try
                {
                    propuesta.Estado = (SGC.ENEstadosPieza)Enum.Parse(typeof(SGC.ENEstadosPieza), comboBoxEditEstado.SelectedItem.ToString());
                }
                catch (Exception)
                {
                    propuesta.Estado = SGC.ENEstadosPieza.USADA;
                }

                // Se envía la propuesta al servidor.
                try
                {
                    propuesta.Id = Program.InterfazRemota.ProponerPieza(propuesta.ENPropuesta, Configuracion.Default.usuario, Configuracion.Default.contrasena);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                if (propuesta.Id > 0)
                {
                    // Se guarda la propuesta en la base de datos.
                    if (propuesta.Guardar())
                    {
                        // Si todo ha ido bien, se abre la solicitud.
                        FormBase.Instancia.MostrarNinguno();
                        FormBase.Instancia.ActualizarSolicitud(solicitud);
                        FormBase.Instancia.MostrarVerSolicitud(solicitud);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al guardar la propuesta de la base de datos.", "Guardando propuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al enviar la propuesta al servidor.", "Guardando propuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButtonLimpiarFormulario_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            FormBase.Instancia.MostrarNinguno();
            FormBase.Instancia.MostrarAnterior();
        }

        private void pictureEditElegirFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialogFoto.ShowDialog() == DialogResult.OK)
            {
                pictureEditFoto.Image = new Bitmap(openFileDialogFoto.FileName);
            }
        }

        private void pictureEditQuitarFoto_Click(object sender, EventArgs e)
        {
            pictureEditFoto.Image = null;
        }

        private void hyperLinkEditSolicitud_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            FormBase.Instancia.MostrarVerSolicitud(solicitud);
        }
    }
}
