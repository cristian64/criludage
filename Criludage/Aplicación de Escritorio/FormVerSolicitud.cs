﻿using System;
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
        private DataTable dataTable;

        /// <summary>
        /// Constructor sobrecargado que carga una solicitud en el formulario.
        /// </summary>
        /// <param name="solicitud">Solicitud que se va a cargar.</param>
        public FormVerSolicitud(Solicitud solicitud)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            CargarSolicitud(solicitud);

            // Se crea el DataSource que va a utilizarse y se definen las columnas.
            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Descripción", typeof(String));
            dataTable.Columns.Add("Estado", typeof(String));
            dataTable.Columns.Add("Precio", typeof(decimal));
            dataTable.Columns.Add("Fecha de entrega", typeof(DateTime));
            gridControlPropuestas.DataSource = dataTable;

            // Mostramos y ocultamos según el tipo de aplicación.
            int tamanoFilas = 0;
            if (Program.TipoAplicacion == Program.TiposAplicacion.TALLER)
            {
                // Se elimina la fila que indica el cliente (puesto que si somos el taller, somos nosotros mismos).
                tamanoFilas += (int) tableLayoutPanel1.RowStyles[1].Height;
                tableLayoutPanel1.RowStyles[1].Height = 0;
                tableLayoutPanel1.Controls.Remove(panel9);
                tableLayoutPanel1.Controls.Remove(panel10);

                simpleButtonProponerPropuesta.Visible = false;
            }
            else
            {
                tamanoFilas += (int)tableLayoutPanel1.RowStyles[3].Height;
                tableLayoutPanel1.RowStyles[3].Height = 0;
                tableLayoutPanel1.Controls.Remove(panel4);
                tableLayoutPanel1.Controls.Remove(panel12);

                tamanoFilas += (int)tableLayoutPanel1.RowStyles[8].Height;
                tableLayoutPanel1.RowStyles[8].Height = 0;
                tableLayoutPanel1.Controls.Remove(panel5);
                tableLayoutPanel1.Controls.Remove(panel16);

                tamanoFilas += (int)tableLayoutPanel1.RowStyles[9].Height;
                tableLayoutPanel1.RowStyles[9].Height = 0;
                tableLayoutPanel1.Controls.Remove(panel18);
                tableLayoutPanel1.Controls.Remove(panel12);
            }
            // Subimos los elementos que están por debajo y reducimos el tamaño de la tabla según la cantidad
            tableLayoutPanel1.Height -= tamanoFilas;
            gridControlPropuestas.Location = new Point(gridControlPropuestas.Location.X, gridControlPropuestas.Location.Y - tamanoFilas);
            gridControlPropuestas.Height += tamanoFilas;
            labelControlSubtitulo.Location = new Point(labelControlSubtitulo.Location.X, labelControlSubtitulo.Location.Y - tamanoFilas);
        }

        /// <summary>
        /// Carga una solicitud en el formulario.
        /// </summary>
        /// <param name="solicitud">Solicitud que se va a cargar.</param>
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
                ProcesarPropuesta(i);
            }
        }

        /// <summary>
        /// Añade una propuesta al GridView que contiene las propuestas.
        /// </summary>
        /// <param name="solicitud">Propuesta que se va a añadir.</param>
        public void ProcesarPropuesta(Propuesta propuesta)
        {
            try
            {
                dataTable.Rows.Add(
                    new object[] {
                        propuesta.Id,
                        propuesta.Descripcion,
                        propuesta.FechaEntrega,
                        propuesta.Estado,
                        propuesta.Precio
                        }
                    );
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
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

        private void gridControlPropuestas_DoubleClick(object sender, EventArgs e)
        {
            FormBase.GetInstancia().MostrarMensaje("Ver propuesta... Mañana", "Módulo no implementado");
        }
    }
}
