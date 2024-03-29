﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Biblioteca_Común;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace Aplicación_de_Escritorio
{
    public partial class FormVerSolicitudes : UserControl
    {
        private DataTable dataTable;

        public FormVerSolicitudes()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            timer.Start();

            // Se crea el DataSource que va a utilizarse y se definen las columnas.
            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Descripción", typeof(String));
            dataTable.Columns.Add("Fecha", typeof(DateTime));
            dataTable.Columns.Add("Fecha de respuesta", typeof(DateTime));
            dataTable.Columns.Add("Negociado automático", typeof(bool));
            dataTable.Columns.Add("Estado", typeof(String));
            dataTable.Columns.Add("Precio máximo", typeof(decimal));
            dataTable.Columns.Add("Fecha de entrega", typeof(DateTime));
            gridControlSolicitudes.DataSource = dataTable;

            // Se muestra la hora en las columnas de tipo fecha.
            foreach (GridColumn c in gridViewSolicitudes.Columns)
                if (c.ColumnType == typeof(DateTime))
                    c.DisplayFormat.FormatString = "G";

            // Se cargan las solicitudes de la base de datos.
            ArrayList solicitudes = Solicitud.ObtenerTodas();
            foreach (Solicitud i in solicitudes)
            {
                ProcesarSolicitud(i);
            }
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
                        solicitud.FechaRespuesta,
                        solicitud.NegociadoAutomatico,
                        solicitud.Estado,
                        solicitud.PrecioMax,
                        solicitud.FechaEntrega
                        }
                    );
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Selecciona la solicitud en el GridView.
        /// </summary>
        /// <param name="solicitud">Empleado que va a seleccionarse.</param>
        public void SeleccionarSolicitud(Solicitud solicitud)
        {
            // Se desmarcan todos los empleados.
            while (gridViewSolicitudes.SelectedRowsCount > 0)
            {
                int[] seleccionadas = gridViewSolicitudes.GetSelectedRows();
                gridViewSolicitudes.UnselectRow(seleccionadas[0]);
            }

            // Se busca el empleado y se selecciona.
            for (int i = 0; i < gridViewSolicitudes.RowCount; i++)
            {
                if (solicitud.Id == (int) gridViewSolicitudes.GetRowCellValue(i, "ID"))
                {
                    gridViewSolicitudes.SelectRow(i);
                    break;
                }
            }
        }

        private void gridViewSolicitudes_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewSolicitudes.SelectedRowsCount > 0)
            {
                int[] seleccionados = gridViewSolicitudes.GetSelectedRows();
                Solicitud solicitud = Solicitud.Obtener((int) gridViewSolicitudes.GetRowCellValue(seleccionados[0], "ID"));
                if (solicitud != null)
                {
                    FormBase.Instancia.MostrarVerSolicitud(solicitud);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al cargar la solicitud desde la base de datos.", "Viendo solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridViewSolicitudes_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DateTime fechaRespuesta = (DateTime) gridViewSolicitudes.GetRowCellValue(e.RowHandle, gridViewSolicitudes.Columns["Fecha de respuesta"]);
                if (fechaRespuesta > DateTime.Now)
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
        }

        private void gridViewSolicitudes_RowCountChanged(object sender, EventArgs e)
        {
            foreach (GridColumn c in (sender as GridView).Columns)
                c.BestFit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gridViewSolicitudes.LayoutChanged();
        }
    }
}
