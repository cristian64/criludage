using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Biblioteca_Común;

namespace Aplicación_de_Taller
{
    public partial class FormVerSolicitudes : UserControl
    {
        private DataTable dataTable;

        public FormVerSolicitudes()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            // Se crea el DataSource que va a utilizarse y se definen las columnas.
            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Descripción", typeof(String));
            dataTable.Columns.Add("Fecha", typeof(DateTime));
            dataTable.Columns.Add("Estado", typeof(String));
            dataTable.Columns.Add("Precio máximo", typeof(decimal));
            dataTable.Columns.Add("Negociado automático", typeof(bool));
            dataTable.Columns.Add("Fecha de entrega", typeof(DateTime));
            dataTable.Columns.Add("Nº de propuestas", typeof(int));
            gridControlSolicitudes.DataSource = dataTable;
        }

        /// <summary>
        /// Añade una solicitud al GridView que contiene las solicitudes.
        /// </summary>
        /// <param name="solicitud">Solicitud que se va a añadir.</param>
        public void ProcesarSolicitud(Solicitud solicitud)
        {
            try
            {
                dataTable.Rows.Add(
                    new object[] {
                        solicitud.Id,
                        solicitud.Descripcion,
                        solicitud.Fecha,
                        solicitud.Estado,
                        solicitud.PrecioMax,
                        solicitud.NegociadoAutomatico,
                        solicitud.FechaEntrega,
                        solicitud.ContarPropuestas()
                        }
                    );
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
            }
        }

        private void gridViewSolicitudes_DoubleClick(object sender, EventArgs e)
        {
            int[] fila = gridViewSolicitudes.GetSelectedRows();
            if (fila.Length > 0)
                //TODO: que cargue el formulario VerSolicitud con la solicitud nº tal
                FormBase.GetInstancia().MostrarMensaje("Viendo la solicitud nº " + Convert.ToString(gridViewSolicitudes.GetRowCellValue(fila[0], "ID")), "Módulo no implementado");
        }
    }
}
