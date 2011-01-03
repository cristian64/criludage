using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Biblioteca_Común;
using System.Xml;

namespace Aplicación_de_Taller
{
    public partial class FormBase : Form
    {
        private static FormBase instancia = null;
        public static FormBase GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new FormBase();
            }
            return instancia;
        }

        /// <summary>
        /// Instancia de la interfaz remota.
        /// </summary>
        public SGC.InterfazRemota InterfazRemota;

        /// <summary>
        /// Instancia del formulario para evitar tiempos de espera.
        /// Así, puede ir actualizándose el formulario incluso cuando no se muestra.
        /// </summary>
        private FormVerSolicitudes formVerSolicitudes;
        private FormSolicitarPieza formSolicitarPieza;
        private FormVerEmpleados formVerEmpleados;

        /// <summary>
        /// Es el consumidor que se ejecuta en otro hilo, recibiendo los mensajes y procesándolos.
        /// </summary>
        private Consumidor consumidorSolicitudes;
        private Thread hiloConsumidorSolicitudes;
        private void consumirSolicitudes()
        {
            try
            {
                while (true)
                {
                    String xml = consumidorSolicitudes.Recibir(1);
                    if (xml != null)
                    {
                        SGC.ENSolicitud solicitud = CreateENSolicitudFromXML(xml);
                        if (solicitud != null)
                        {
                            // Se realiza un upcasting desde ENSolicitud a Solicitud y se añade la solicitud a la tabla.
                            formVerSolicitudes.ProcesarSolicitud(new Solicitud(solicitud));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Crea un objeto ENSolicitud (clase obtenida desde el servicio web) a partir de una cadena Xml.
        ///  Habrá que mantener este método conforme modifica ENSolicitud.
        /// </summary>
        /// <param name="xml">Cadena que contiene el Xml.</param>
        /// <returns>Devuelve la solicitud con el valor de los parámetros según el Xml recibido.</returns>
        private static SGC.ENSolicitud CreateENSolicitudFromXML(String xml)
        {
            SGC.ENSolicitud solicitud = new SGC.ENSolicitud();

            // Se crea el documento Xml.
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            // Se parsea la entrada.
            XmlNode nodo = xmlDocument.FirstChild.NextSibling.ChildNodes.Item(0);
            while (nodo != null)
            {
                switch (nodo.Name)
                {
                    case "Id":
                    {
                        solicitud.Id = int.Parse(nodo.InnerText);
                        break;
                    }
                    case "IdCliente":
                    {
                        solicitud.IdCliente = int.Parse(nodo.InnerText);
                        break;
                    }
                    case "Descripcion":
                    {
                        solicitud.Descripcion = nodo.InnerText;
                        break;
                    }
                    case "Estado":
                    {
                        solicitud.Estado = (SGC.ENEstadosPieza) Enum.Parse(typeof(SGC.ENEstadosPieza), nodo.InnerText);
                        break;
                    }
                    case "Fecha":
                    {
                        solicitud.Fecha = DateTime.Parse(nodo.InnerText);
                        break;
                    }
                    case "FechaEntrega":
                    {
                        solicitud.FechaEntrega = DateTime.Parse(nodo.InnerText);
                        break;
                    }
                    case "NegociadoAutomatico":
                    {
                        solicitud.NegociadoAutomatico = nodo.InnerText.Equals("true") ? true : false;
                        break;
                    }
                    case "PrecioMax":
                    {
                        solicitud.PrecioMax = float.Parse(nodo.InnerText.Replace(".", ","));
                        break;
                    }
                }
                nodo = nodo.NextSibling;
            }

            return solicitud;
        }

        private FormBase()
        {
            InitializeComponent();

            // Se introducen los botones referentes a los empleados en un único menú desplegable.
            // Desde el diseñador no se puede hacer, por lo que salen todos visibles.
            this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemVerEmpleados);
            this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemAnadirEmpleado);
            this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemAnadirAdministrador);
            this.ribbonPageGroupAdministracion.ItemLinks.Remove(this.barButtonItemVerEmpleados);
            this.ribbonPageGroupAdministracion.ItemLinks.Remove(this.barButtonItemAnadirEmpleado);
            this.ribbonPageGroupAdministracion.ItemLinks.Remove(this.barButtonItemAnadirAdministrador);

            InterfazRemota = new SGC.InterfazRemota();
            formVerSolicitudes = new FormVerSolicitudes();
            formSolicitarPieza = new FormSolicitarPieza();
            formVerEmpleados = new FormVerEmpleados();

            // Se crea el consumidor de solicitudes y el hilo que consultará cada 1 segundo los mensajes pendientes.
            consumidorSolicitudes = new Consumidor(Settings.Default.servidor, Settings.Default.topic);
            hiloConsumidorSolicitudes = new Thread(consumirSolicitudes);
            hiloConsumidorSolicitudes.Start();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            MostrarVerSolicitudes();
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Saliendo de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                hiloConsumidorSolicitudes.Abort();
            }
        }

        public void MostrarVerSolicitudes()
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formVerSolicitudes);
        }

        public void MostrarSolicitarPieza()
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formSolicitarPieza);
        }

        public void MostrarVerEmpleados()
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formVerEmpleados);
        }

        private void barButtonItemSolicitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarSolicitarPieza();
        }

        private void barButtonItemVerSolicitudes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarVerSolicitudes();
        }

        /// <summary>
        /// Muestra un mensaje que se desvanece con el tiempo.
        /// Ejemplo: MostrarMensaje("Solicitudes archivadas", "Todavía no se ha implementado este módulo.");
        /// </summary>
        /// <param name="titulo">Título para el mensaje. Por ejemplo "Solicitud recibida".</param>
        /// <param name="mensaje">Mensaje descriptivo.</param>
        public void MostrarMensaje(String titulo, String mensaje)
        {
            alertControl.Show(this, titulo, mensaje);
        }

        private void barButtonItemVerEmpleados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarVerEmpleados();
        }

        private void barButtonItemAnadirEmpleado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarMensaje("Añadiendo un empleado", "Módulo sin implementar"); //TODO
        }

        private void barButtonItemAnadirAdministrador_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarMensaje("Añadiendo un administrador", "Módulo sin implementar"); //TODO
        }
    }
}
