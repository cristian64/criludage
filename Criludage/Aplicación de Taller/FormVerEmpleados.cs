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
                dataTable.Rows.Add(
                    new object[] {
                    i.Id,
                    i.Usuario,
                    i.Nombre,
                    i.CorreoElectronico,
                    i.Nif,
                    i.Administrador
                    }
                    );
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
