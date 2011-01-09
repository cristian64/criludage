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

            // Traemos la aplicación al frente.
            BringToFront();
            Activate();
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
            bool correcto = true;

            // TODO: Enviar datos al servidor y registrar el usuario

            if (correcto)
            {
                Program.InicioSesion = true;
                Close();
            }
        }

        private void checkEditYaRegistrado_CheckedChanged(object sender, EventArgs e)
        {
            textEditContrasena2.Enabled = !checkEditYaRegistrado.Checked;
            textEditCorreoElectronico.Enabled = !checkEditYaRegistrado.Checked;
            dropDownButtonTipoAplicacion.Enabled = !checkEditYaRegistrado.Checked;
        }

        private void barButtonItemDesguace_ItemClick(object sender, ItemClickEventArgs e)
        {
            dropDownButtonTipoAplicacion.Text = "Desguace";
            dropDownButtonTipoAplicacion.Image = barButtonItemDesguace.Glyph;
            Program.TipoAplicacion = Program.TiposAplicacion.DESGUACE;
        }

        private void barButtonItemTaller_ItemClick(object sender, ItemClickEventArgs e)
        {
            dropDownButtonTipoAplicacion.Text = "Taller";
            dropDownButtonTipoAplicacion.Image = barButtonItemTaller.Glyph;
            Program.TipoAplicacion = Program.TiposAplicacion.TALLER;
        }

        private void dropDownButtonTipoAplicacion_Click(object sender, EventArgs e)
        {
            if (dropDownButtonTipoAplicacion.Text.Equals("Taller"))
            {
                barButtonItemDesguace_ItemClick(null, null);
            }
            else
            {
                barButtonItemTaller_ItemClick(null, null);
            }
        }
    }
}