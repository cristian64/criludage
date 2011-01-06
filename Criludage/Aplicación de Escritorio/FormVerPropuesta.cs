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
    public partial class FormVerPropuesta : UserControl
    {
        private Propuesta propuesta;

        public FormVerPropuesta(Propuesta propuesta)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            CargarPropuesta(propuesta);
        }

        /// <summary>
        /// Se carga una propuesta en el formulario.
        /// </summary>
        /// <param name="propuesta">Propuesta que se va a mostrar.</param>
        public void CargarPropuesta(Propuesta propuesta)
        {
            this.propuesta = propuesta;
            //TODO: cargar los datos de la propuesta en el formulario
        }
    }
}
