using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Biblioteca_de_Entidades_de_Negocio;

namespace Aplicación_de_Desguace
{
    public partial class FormVerSolicitudes : UserControl
    {
        public FormVerSolicitudes()
        {
            InitializeComponent();
        }

        public object añadirSolicitud(object obj)
        {
            System.Console.WriteLine("llamadica al metodico");

            try
            {
                Solicitud solicitud = obj as Solicitud;

                dataGridViewSolicitudes.Rows.Add(solicitud.Id,
                                                solicitud.Descripcion,
                                                solicitud.Fecha,
                                                solicitud.Estado,
                                                solicitud.PrecioMax,
                                                solicitud.FechaEntrega
                                                );

                System.Console.WriteLine("---> " + dataGridViewSolicitudes.Rows[dataGridViewSolicitudes.Rows.Count - 1].ToString());

                dataGridViewSolicitudes.Update();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Excepcion freca: " + e.ToString());
            }

            return null;
        }
    }
}
