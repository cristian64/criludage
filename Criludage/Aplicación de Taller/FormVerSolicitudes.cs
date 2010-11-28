using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;

namespace Aplicación_de_Taller
{
    public partial class FormVerSolicitudes : UserControl
    {
        public FormVerSolicitudes()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        public object procesarSolicitud(object objeto)
        {
            Solicitud solicitud = objeto as Solicitud;
            dataGridViewSolicitudes.Rows.Add(
                solicitud.Id,
                solicitud.Descripcion,
                solicitud.Fecha,
                solicitud.Estado,
                solicitud.PrecioMax,
                solicitud.NegociadoAutomatico,
                solicitud.FechaEntrega,
                solicitud.Propuestas.Count,
                solicitud.PropuestaAceptada != null
                );
            dataGridViewSolicitudes.Show();
            return null;
        }
    }
}
