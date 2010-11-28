using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicación_de_Taller
{
    public partial class FormBase : Form
    {
        /// <summary>
        /// Instancia del formulario para evitar tiempos de espera.
        /// Así, puede ir actualizándose el formulario incluso cuando no se muestra.
        /// </summary>
        private FormVerSolicitudes formVerSolicitudes;

        public FormBase()
        {
            InitializeComponent();
            formVerSolicitudes = new FormVerSolicitudes();
            formVerSolicitudes.Dock = DockStyle.Fill;
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            panelContenido.Controls.Add(formVerSolicitudes);
        }
    }
}
