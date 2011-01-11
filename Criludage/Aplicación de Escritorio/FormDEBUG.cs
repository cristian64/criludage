using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;

namespace Aplicación_de_Escritorio
{
    public partial class FormDEBUG : DevExpress.XtraEditors.XtraForm
    {
        public FormDEBUG()
        {
            InitializeComponent();

            foreach (SettingsProperty i in Configuracion.Default.Properties)
            {
                Console.WriteLine(i.Name + " " + i.DefaultValue);
                Console.WriteLine(i.Name + " " + Configuracion.Default[i.Name]);
                Console.WriteLine("_______________________________________________________________");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Configuracion.Default.Reset();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Configuracion.Default.Save();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}