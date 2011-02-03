using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using System.Collections;

namespace Aplicación_de_Escritorio
{
    public partial class FormHistorialCompras : UserControl
    {
        private DataTable dataTable;

        public FormHistorialCompras()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            // Se crea el DataSource que va a utilizarse y se definen las columnas.
            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Descripción", typeof(String));
            dataTable.Columns.Add("Fecha de entrega", typeof(DateTime));
            dataTable.Columns.Add("Estado", typeof(String));
            dataTable.Columns.Add("Precio", typeof(decimal));
            gridControlPropuestas.DataSource = dataTable;

            // Se muestra la hora en las columnas de tipo fecha.
            foreach (GridColumn c in gridViewPropuestas.Columns)
                if (c.ColumnType == typeof(DateTime))
                    c.DisplayFormat.FormatString = "G";

            // Se cargan las propuestas confirmadas de la base de datos.
            ArrayList propuestas = Propuesta.ObtenerConfirmadas();
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

        private void gridControlPropuestas_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewPropuestas.SelectedRowsCount > 0)
            {
                int[] seleccionados = gridViewPropuestas.GetSelectedRows();
                Propuesta propuesta = Propuesta.Obtener((int)gridViewPropuestas.GetRowCellValue(seleccionados[0], "ID"));
                if (propuesta != null)
                {
                    FormBase.Instancia.MostrarVerPropuesta(propuesta);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al cargar la propuesta desde la base de datos.", "Viendo solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
