﻿using System;
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
            gridSolicitudes.Rows.Add("Esto es de prueba", new DateTime().ToString(), true);

            //
        }
    }
}
