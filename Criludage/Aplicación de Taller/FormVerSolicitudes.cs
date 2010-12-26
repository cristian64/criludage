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
            CheckForIllegalCrossThreadCalls = false;
        }

        public void procesarSolicitud(Solicitud solicitud)
        {
            try
            {
                dataGridViewSolicitudes.Rows.Add(
                    solicitud.Id,
                    solicitud.Descripcion,
                    solicitud.Fecha,
                    solicitud.Estado,
                    solicitud.PrecioMax,
                    solicitud.NegociadoAutomatico,
                    solicitud.FechaEntrega
                    );
            }
            catch (Exception e)
            {
                System.Console.WriteLine("procesarSolicitud(Solicitud solicitud)");
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
