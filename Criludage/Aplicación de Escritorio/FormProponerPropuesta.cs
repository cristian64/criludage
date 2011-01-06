using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicación_de_Escritorio
{
    public partial class FormProponerPropuesta : UserControl
    {
        private Solicitud solicitud;
        public FormProponerPropuesta(Solicitud solicitud)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            CargarSolicitud(solicitud);
        }

        /// <summary>
        /// Carga una solicitud en el formulario.
        /// </summary>
        /// <param name="solicitud">Solicitud a la que va referida la propuesta que se va a proponer.</param>
        public void CargarSolicitud(Solicitud solicitud)
        {
            this.solicitud = solicitud;
            //TODO:
        }
    }
}
