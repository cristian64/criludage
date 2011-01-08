using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Aplicación_de_Escritorio
{
    public partial class FormPrimeraVez : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormPrimeraVez()
        {
            InitializeComponent();
        }

        private void barButtonItemSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItemAcercaDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormAcercaDe().Show();
        }

        private void wizardControl_CancelClick(object sender, CancelEventArgs e)
        {
            Close();
        }

        private void wizardControl_FinishClick(object sender, CancelEventArgs e)
        {
            Program.InicioSesion = true;
            Close();
        }
    }
}