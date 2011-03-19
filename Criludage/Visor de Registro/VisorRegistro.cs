using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Collections;

namespace Visor_de_Registro
{
    public partial class VisorRegistro : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dataTable;
        private int ultimo;

        public VisorRegistro()
        {
            InitializeComponent();

            // Se crea el DataSource que va a utilizarse y se definen las columnas.
            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Fecha", typeof(DateTime));
            dataTable.Columns.Add("Tipo", typeof(String));
            dataTable.Columns.Add("Usuario", typeof(String));
            dataTable.Columns.Add("Descripción", typeof(String));
            gridControlRegistro.DataSource = dataTable;

            // Se muestra la hora en las columnas de tipo fecha.
            foreach (GridColumn c in gridViewRegistro.Columns)
                if (c.ColumnType == typeof(DateTime))
                    c.DisplayFormat.FormatString = "G";

            ultimo = -1;
            timer_Tick(null, null);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Extrae las últimos mensajes de log y los añades a la vista.
            ArrayList registros = Registro.ObtenerDesde(ultimo);
            foreach (Registro i in registros)
            {
                try
                {
                    dataTable.Rows.Add(
                        new object[] {
                        i.Id,
                        i.Fecha,
                        i.Tipo,
                        i.Usuario,
                        i.Descripcion
                        }
                        );

                    ultimo = i.Id;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.StackTrace);
                }
            }

            // Baja el scroll hasta el final si se ha añadido algún mensaje.
            if (registros.Count > 0)
                gridViewRegistro.TopRowIndex = int.MaxValue;
        }

        private void gridViewRegistro_RowCountChanged(object sender, EventArgs e)
        {
            foreach (GridColumn c in (sender as GridView).Columns)
                c.BestFit();
        }

        private void barCheckItemRefrescar_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barCheckItemRefrescar.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
    }
}
