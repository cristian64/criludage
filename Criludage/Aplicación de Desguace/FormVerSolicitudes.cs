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
            Solicitud solicitud = (Solicitud)obj;

            dataGridViewSolicitudes.Rows.Add(solicitud.Id,
                                            solicitud.Descripcion,
                                            solicitud.Fecha,
                                            solicitud.Estado,
                                            solicitud.PrecioMax,
                                            solicitud.FechaEntrega
                                            );

            return null;
        }
    }
}
