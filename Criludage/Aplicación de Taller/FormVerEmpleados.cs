using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Aplicación_de_Taller
{
    public partial class FormVerEmpleados : UserControl
    {
        private DataTable dataTable;

        public FormVerEmpleados()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            // Se crea el DataSource que va a utilizarse y se definen las columnas.
            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nombre de usuario", typeof(String));
            dataTable.Columns.Add("Nombre completo", typeof(String));
            dataTable.Columns.Add("Correo electrónico", typeof(String));
            dataTable.Columns.Add("NIF", typeof(String));
            dataTable.Columns.Add("¿Es administrador?", typeof(bool));
            gridControlEmpleados.DataSource = dataTable;

            // Se cargan todos los empleados de la base de datos.
            ArrayList empleados = Empleado.ObtenerTodos();
            foreach (Empleado i in empleados)
            {
                ProcesarEmpleado(i);
            }
        }

        /// <summary>
        /// Añade un empleado al GridView.
        /// </summary>
        /// <param name="empleado">Empleado que se va a insertar.</param>
        public void ProcesarEmpleado(Empleado empleado)
        {
            try
            {
                dataTable.Rows.Add(
                    new object[] {
                        empleado.Id,
                        empleado.Usuario,
                        empleado.Nombre,
                        empleado.CorreoElectronico,
                        empleado.Nif,
                        empleado.Administrador
                        }
                    );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Selecciona el empleado en el GridView.
        /// </summary>
        /// <param name="empleado">Empleado que va a seleccionarse.</param>
        public void SeleccionarEmpleado(Empleado empleado)
        {
            // Se desmarcan todos los empleados.
            while (gridViewEmpleados.SelectedRowsCount > 0)
            {
                int[] seleccionadas = gridViewEmpleados.GetSelectedRows();
                gridViewEmpleados.UnselectRow(seleccionadas[0]);
            }

            // Se busca el empleado y se selecciona.
            for (int i = 0; i < gridViewEmpleados.RowCount; i++)
            {
                if (empleado.Id == (int) gridViewEmpleados.GetRowCellValue(i, "ID"))
                {
                    gridViewEmpleados.SelectRow(i);
                    break;
                }
            }
        }

        private void gridControlEmpleados_DoubleClick(object sender, EventArgs e)
        {
            int[] fila = gridViewEmpleados.GetSelectedRows();
            if (fila.Length > 0)
                //TODO: que cargue el formulario VerEmpleado con la solicitud nº tal
                FormBase.GetInstancia().MostrarMensaje("Viendo empleado nº " + Convert.ToString(gridViewEmpleados.GetRowCellValue(fila[0], "ID")), "Módulo no implementado");
        }
    }
}
