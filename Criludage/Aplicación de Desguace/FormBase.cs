using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Biblioteca_Común;

namespace Aplicación_de_Desguace
{
    public partial class FormBase : Form
    {

        private Consumidor consumidor; 
        private FormVerSolicitudes formVerSolicitudes;

        public FormBase()
        {
            InitializeComponent();
            formVerSolicitudes = new FormVerSolicitudes();
            formVerSolicitudes.Dock = DockStyle.Fill;

            consumidor = new Consumidor("tcp://79.108.133.115:61616", "pollaca", formVerSolicitudes.añadirSolicitud);
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            panelContenido.Controls.Add(formVerSolicitudes);
        }
    }
}
