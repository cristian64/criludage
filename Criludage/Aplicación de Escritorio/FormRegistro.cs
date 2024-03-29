﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Aplicación_de_Escritorio
{
    public partial class FormRegistro : UserControl
    {
        public FormRegistro()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            richEditControl.Font = Configuracion.Default.fuente;
            richEditControl.Appearance.Text.ForeColor = Configuracion.Default.color;

            try
            {
                StreamReader streamReader = new StreamReader(Registro.NombreFichero);
                while (!streamReader.EndOfStream)
                    WriteLine(streamReader.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public void WriteLine(String cadena)
        {
            richEditControl.Text = cadena + "\n" + richEditControl.Text;
        }

        public void Limpiar()
        {
            richEditControl.Text = "";
            try
            {
                FileInfo fileInfo = new FileInfo(Registro.NombreFichero);
                fileInfo.Delete();
            }
            catch (Exception)
            {

            }
        }

        public void ElegirFuente()
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richEditControl.Font = fontDialog.Font;
                Configuracion.Default.fuente = fontDialog.Font;
                Configuracion.Default.Save();
            }
        }

        public void ElegirColor()
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richEditControl.Appearance.Text.ForeColor = colorDialog.Color;
                Configuracion.Default.color = colorDialog.Color;
                Configuracion.Default.Save();
            }
        }
    }
}
