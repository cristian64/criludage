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
        /// <summary>
        /// Instancia del formulario para evitar tiempos de espera.
        /// Así, puede ir actualizándose el formulario incluso cuando no se muestra.
        /// </summary>
        private FormVerSolicitudes formVerSolicitudes;

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
                            formVerSolicitudes.procesarSolicitud(solicitud);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("consumirSolicitudes()");
                System.Console.WriteLine(e.Message);
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

        public FormBase()
        {
            InitializeComponent();
            formVerSolicitudes = new FormVerSolicitudes();

            // Se crea el consumidor de solicitudes y el hilo que consultará cada 1 segundo los mensajes pendientes.
            consumidorSolicitudes = new Consumidor(Settings.Default.servidor, Settings.Default.topic);
            hiloConsumidorSolicitudes = new Thread(consumirSolicitudes);
            hiloConsumidorSolicitudes.Start();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            mostrarVerSolicitudes();
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

        public void mostrarVerSolicitudes()
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formVerSolicitudes);
        }

        public void mostrarSolicitarPieza()
        {
            FormSolicitarPieza formSolicitarPieza = new FormSolicitarPieza(this);
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formSolicitarPieza);
        }

        private void barButtonItemSolicitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mostrarSolicitarPieza();
        }

        private void barButtonItemVerSolicitudes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mostrarVerSolicitudes();
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
    }
}
