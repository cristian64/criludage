using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.XtraEditors;
using System.Collections;

namespace Aplicación_de_Escritorio
{
    public partial class FormAcercaDe : DevExpress.XtraEditors.XtraForm
    {
        public FormAcercaDe()
        {
            InitializeComponent();
            asignarPosiciones();
        }

        private void asignarPosiciones()
        {
            ArrayList autores = new ArrayList(new object[] {
                "Jorge Calvo Zaragoza",
                "Cristian Aguilera Martínez",
                "Damián Moya Pérez",
                "Luis Vivas Tejuelo"
            });

            Random random = new Random(DateTime.Now.Millisecond);
            int primero = random.Next(4);
            int segundo = random.Next(3);
            int tercero = random.Next(2);
            int cuarto = random.Next(1);

            labelControl1.Text = (string)autores[primero];
            autores.RemoveAt(primero);
            labelControl2.Text = (string)autores[segundo];
            autores.RemoveAt(segundo);
            labelControl3.Text = (string)autores[tercero];
            autores.RemoveAt(tercero);
            labelControl4.Text = (string)autores[cuarto];
            autores.RemoveAt(cuarto);
        }

        private void simpleButtonAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}