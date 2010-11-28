using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicación_de_Taller
{
    public partial class FormVerSolicitudes : UserControl
    {
        public FormVerSolicitudes()
        {
            InitializeComponent();

            // ESTO ES DE PRUEBA
            dataGridViewSolicitudes.Rows.Add("000001", "Esto es de prueba", new DateTime().ToString(), "NUEVA", "100€", true, new DateTime().ToString(), 17, false);

            //
        }
    }
}
