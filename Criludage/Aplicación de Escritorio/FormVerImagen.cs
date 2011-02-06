using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aplicación_de_Escritorio
{
    public partial class FormVerImagen : DevExpress.XtraEditors.XtraForm
    {
        public FormVerImagen(Image imagen)
        {
            InitializeComponent();
            pictureEditFoto.Image = imagen;
        }

        private void pictureEditFoto_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}