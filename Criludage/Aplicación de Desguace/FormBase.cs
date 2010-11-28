using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicación_de_Desguace
{
    public partial class FormBase : Form
    {

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
